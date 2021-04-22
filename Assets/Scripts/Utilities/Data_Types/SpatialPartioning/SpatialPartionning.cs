﻿namespace Tartaros.Utilities.SpatialPartioning
{
	using Sirenix.Utilities;
	using System.Collections.Generic;
	using System.Linq;
	using UnityEngine;
	using UnityEngine.XR.WSA;

	// Learn more: https://www.habrador.com/tutorials/programming-patterns/19-spatial-partition-pattern/
	// Learn more (bis): http://gameprogrammingpatterns.com/spatial-partition.html
	public class SpatialPartioning<T> where T : class, ISpatialPartioningObject
	{
		#region Fields
		private CellsGrid2D<Cell<T>> _cellsGrid = null;
		#endregion Fields

		#region Ctor
		public SpatialPartioning(float cellSize)
		{
			_cellsGrid = new CellsGrid2D<Cell<T>>(cellSize);
		}
		#endregion Ctor

		#region Methods
		public void CheckForErrors()
		{
			if (IsThereSameTransformInMultipleCells())
			{
				throw new SameElementInMultipleCellsException();
			}
		}

		public void DebugDrawGrid(Color color, float duration = 0) => _cellsGrid.DebugDraw(color, duration);

		public void AddElement(T element)
		{
			if (element is null) throw new System.ArgumentNullException(nameof(element));

			var cell = _cellsGrid.GetCellAtWorldPosition(element.WorldPosition);


			if (cell.Contains(element) == false)
			{
				cell.AddElement(element);
			}
			else
			{
				Debug.LogErrorFormat("Cannot add element {0} to the SpatialPartioning because it is already in it", element.ToString());
			}
		}

		public void AddElements(T[] elements)
		{
			foreach (var transform in elements)
			{
				AddElement(transform);
			}
		}

		public void RemoveElement(T element)
		{
			if (element is null) throw new System.ArgumentNullException(nameof(element));

			var cell = _cellsGrid.GetCellAtWorldPosition(element.WorldPosition);
			cell.RemoveElement(element);
		}

		public void Move(T element, Vector3 position)
		{
			var oldCell = _cellsGrid.GetCellAtWorldPosition(element.WorldPosition);
			var newCell = _cellsGrid.GetCellAtWorldPosition(position);

			if (oldCell != newCell)
			{
				oldCell.RemoveElement(element);
				newCell.AddElement(element);
			}

			element.WorldPosition = position;
		}

		public T[] GetElementsInRadius(Vector3 position, float radius)
		{
			Cell<T>[] cellsInRadius = _cellsGrid.GetCellsInRadius(position, radius);

			List<T> elementsInRadius = new List<T>();

			for (int cellIndex = 0, cellsLength = cellsInRadius.Length; cellIndex < cellsLength; cellIndex++)
			{
				Cell<T> cell = cellsInRadius[cellIndex];

				if (IsCellCompletelyInRadius(position, radius, cell) == true)
				{
					elementsInRadius.AddRange(cell.Elements);
				}
				else
				{
					var cellElements = cell.Elements;

					// is cell partial in radius, we must check each elements
					for (int elementIndex = 0, elementsLength = cell.Elements.Length; elementIndex < elementsLength; elementIndex++)
					{
						T element = cellElements[elementIndex];

						if (Vector3.Distance(element.WorldPosition, position) <= radius)
						{
							elementsInRadius.Add(element);
						}
					}
				}
			}

			if (elementsInRadius.HasDuplicate() == true)
			{
				throw new SameElementInMultipleCellsException(elementsInRadius.GetDuplicates()[0]);
			}

			return elementsInRadius.ToArray();
		}

		private bool IsCellCompletelyInRadius(Vector3 worldPosition, float radius, Cell<T> cell)
		{
			float cx = worldPosition.x;
			float cy = worldPosition.y;

			float rw = _cellsGrid.CellSize;
			float rh = _cellsGrid.CellSize;

			Vector2 coords = _cellsGrid.GetCoordsFromWorldPosition(worldPosition);
			float rx = coords.x;
			float ry = coords.y;


			// temporary variables to set edges for testing
			float testX = cx;
			float testY = cy;

			// which edge is farest?
			if (cx < rx) testX = rx + rw;      // test left edge
			else if (cx > rx + rw) testX = rx;   // right edge
			if (cy < ry) testY = ry + rh;      // top edge
			else if (cy > ry + rh) testY = ry;   // bottom edge

			// get distance from farest edges
			float distX = cx - testX;
			float distY = cy - testY;
			float distance = Mathf.Sqrt((distX * distX) + (distY * distY));

			// if the distance is less than the radius, collision!
			if (distance <= radius)
			{
				return true;
			}
			return false;
		}

		private bool IsThereSameTransformInMultipleCells()
		{
			// https://stackoverflow.com/questions/18547354/c-sharp-linq-find-duplicates-in-list
			return _cellsGrid.AllCells
				.Where(x => x != null)
				.SelectMany(x => x.Elements)
				.GroupBy(x => x)
				.Where(g => g.Count() > 1)
				.Count() > 0;
		}
		#endregion Methods
	}
}
