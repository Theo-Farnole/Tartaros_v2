namespace Tartaros.Utilities.SpatialPartioning
{
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
				throw new SameTransformInMultipleCellsException();
			}
		}

		public void AddElement(T element)
		{
			if (element is null) throw new System.ArgumentNullException(nameof(element));

			var cell = _cellsGrid.GetCellAtWorldPosition(element.WorldPosition);
			cell.AddElement(element);

#if UNITY_EDITOR
			CheckForErrors();
#endif
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
			cell.AddElement(element);

#if UNITY_EDITOR
			CheckForErrors();
#endif
		}

		public void Move(T element, Vector3 position)
		{
			var oldCell = _cellsGrid.GetCellAtWorldPosition(element.WorldPosition);
			var newCell = _cellsGrid.GetCellAtWorldPosition(position);

			oldCell.RemoveElement(element);
			newCell.AddElement(element);

			element.WorldPosition = position;
		}

		public T[] GetElementsInRadius(Vector3 position, float radius)
		{
			Cell<T>[] cellsInRadius = _cellsGrid.GetCellsInRadius(position, radius);

			List<T> elementsInRadius = new List<T>();
			float radiusSqr = radius * radius;

			foreach (Cell<T> cell in cellsInRadius)
			{
				foreach (T element in cell.Elements)
				{
					if (MathHelper.DistanceSq(element.WorldPosition, position) <= radiusSqr)
					{
						elementsInRadius.Add(element);
					}
				}
			}

			return elementsInRadius.ToArray();
		}

		private bool IsThereSameTransformInMultipleCells()
		{
			// https://stackoverflow.com/questions/18547354/c-sharp-linq-find-duplicates-in-list
			return _cellsGrid.AllCells
				.SelectMany(x => x.Elements)
				.GroupBy(x => x)
				.Where(g => g.Count() > 1)
				.Count() > 0;
		}
		#endregion Methods
	}
}
