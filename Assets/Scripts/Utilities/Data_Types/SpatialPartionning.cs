namespace Tartaros
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using UnityEngine;

	// Learn more: https://www.habrador.com/tutorials/programming-patterns/19-spatial-partition-pattern/
	// Learn more (bis): http://gameprogrammingpatterns.com/spatial-partition.html
	public class SpatialPartioning
	{
		#region Class
		private class Cell
		{
			private List<Transform> _elements = new List<Transform>();

			public Transform[] Elements => _elements.ToArray();

			public bool Contains(Transform trf)
			{
				return _elements.Contains(trf);
			}

			public void RemoveElement(Transform trf) => _elements.Remove(trf);
			public void AddElement(Transform trf) => _elements.Add(trf);
		}

		public class SameTransformInMultipleCellsException : Exception
		{
			public SameTransformInMultipleCellsException() : base("A transform is present in multiple cells. Call Move method when moving a transform.")
			{ }
		}
		#endregion Classes

		#region Fields
		private CellsGrid2D<Cell> _cellsGrid = null;
		#endregion Fields

		#region Ctor
		public SpatialPartioning(float cellSize)
		{
			_cellsGrid = new CellsGrid2D<Cell>(cellSize);
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

		public void AddElement(Transform trf)
		{
			var cell = _cellsGrid.GetCellAtWorldPosition(trf.position);
			cell.AddElement(trf);

#if UNITY_EDITOR
			CheckForErrors();
#endif
		}

		public void AddElements(Transform[] transforms)
		{
			foreach (var transform in transforms)
			{
				AddElement(transform);
			}
		}

		public void RemoveElement(Transform trf)
		{
			var cell = _cellsGrid.GetCellAtWorldPosition(trf.position);
			cell.AddElement(trf);

#if UNITY_EDITOR
			CheckForErrors();
#endif
		}

		public void Move(Transform trf, Vector3 position)
		{
			var oldCell = _cellsGrid.GetCellAtWorldPosition(trf.position);
			var newCell = _cellsGrid.GetCellAtWorldPosition(position);

			oldCell.RemoveElement(trf);
			newCell.AddElement(trf);
		}

		public Transform[] GetElementsInRadius(Vector3 position, float radius)
		{
			Cell[] cellsInRadius = _cellsGrid.GetCellsInRadius(position, radius);

			return cellsInRadius.SelectMany(x => x.Elements).ToArray();
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
