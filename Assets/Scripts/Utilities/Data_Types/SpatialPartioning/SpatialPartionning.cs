namespace Tartaros.Utilities.SpatialPartioning
{
	using System.Collections.Generic;
	using System.Linq;
	using UnityEngine;

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
			List<T> elementsInRadius = new List<T>();
			Vector2 coords = _cellsGrid.GetCoordsFromWorldPosition(position);

			#region V2
			var cells = _cellsGrid.AllCells;

			for (int i = 0, length = cells.Length; i < length; i++)
			{
				Cell<T> cell = cells[i];

				if (cell.Overlap(coords, radius))
				{
					elementsInRadius.AddRange(cell.GetElementsInRadius(coords, radius));
				}
			}

			return elementsInRadius.ToArray();
			#endregion



			#region V1
			Cell<T>[] cellsInRadius = _cellsGrid.GetCellsInRadius(position, radius);



			for (int cellIndex = 0, cellsLength = cellsInRadius.Length; cellIndex < cellsLength; cellIndex++)
			{
				Cell<T> cell = cellsInRadius[cellIndex];

				elementsInRadius.AddRange(cell.GetElementsInRadius(coords, radius));
			}

			//if (elementsInRadius.HasDuplicate() == true)
			//{
			//	throw new SameElementInMultipleCellsException(elementsInRadius.GetDuplicates()[0]);
			//}

			return elementsInRadius.ToArray();
			#endregion
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
