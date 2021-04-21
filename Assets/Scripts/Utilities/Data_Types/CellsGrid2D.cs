namespace Tartaros
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Tartaros.Math;
	using UnityEngine;

	public class CellsGrid2D<TCell>
	{
		#region Fields
		private float _cellSize = 1;

		private Dictionary<Vector2, TCell> _cellsByPosition = new Dictionary<Vector2, TCell>();
		#endregion Fields

		#region Properties
		public TCell[] AllCells => _cellsByPosition.Select(x => x.Value).ToArray();
		#endregion Properties

		#region Ctor
		public CellsGrid2D(float cellSize)
		{
			_cellSize = cellSize;
		}

		public CellsGrid2D(float cellSize, float prewarmCellCount) : this(cellSize)
		{
			for (int x = 0; x < prewarmCellCount; x++)
			{
				for (int y = 0; y < prewarmCellCount; y++)
				{
					Vector2 coords = new Vector2(cellSize * x + cellSize / 2, cellSize * y + cellSize / 2);

					AddCellFromCoords(coords);
				}
			}
		}
		#endregion Ctor

		#region Methods
		public TCell[] GetCellsInRadius(Vector3 position, float radius)
		{
			Circle circle = new Circle(GetCoordsFromWorldPosition(position), radius);
			List<TCell> cellsInRadius = new List<TCell>();


			foreach (var kvp in _cellsByPosition)
			{
				var cellPosition = kvp.Key;
				var rectangle = new Rectangle(cellPosition, new Vector2(_cellSize, _cellSize));				

				if (CollisionOverlapCalculator.DoOverlap(rectangle, circle) == true)
				{
					TCell cell = kvp.Value;
					cellsInRadius.Add(cell);
				}
			}

			return cellsInRadius.ToArray();
		}

		public TCell GetCellAtWorldPosition(Vector3 position)
		{
			Vector2 coords = GetCoordsFromWorldPosition(position);

			return GetCellAtCoord(coords);
		}

		public TCell GetCellAtCoord(Vector2 coords)
		{
			if (_cellsByPosition.ContainsKey(coords) == false)
			{
				AddCellFromCoords(coords);
			}

			return _cellsByPosition[coords];
		}

		public Vector2 GetCoordsFromWorldPosition(Vector3 position)
		{
			float coordsX = Mathf.Round(position.x / _cellSize);
			float coordsY = Mathf.Round(position.z / _cellSize);

			return new Vector2(coordsX, coordsY);
		}

		private void AddCellFromWorldPosition(Vector3 position)
		{
			Vector2 coords = GetCoordsFromWorldPosition(position);

			AddCellFromCoords(coords);
		}

		private void AddCellFromCoords(Vector2 coords)
		{
			_cellsByPosition.Add(coords, Activator.CreateInstance<TCell>());
		}
		#endregion Methods
	}
}
