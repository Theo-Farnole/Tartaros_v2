namespace Tartaros
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Tartaros.Math;
	using Tartaros.Utilities.SpatialPartioning;
	using UnityEngine;

	public class CellsGrid2D<TCell>
	{
		#region Fields
		private float _cellSize = 1;

		private Dictionary<Vector2, TCell> _cellsByPosition = new Dictionary<Vector2, TCell>();
		#endregion Fields

		#region Properties
		public TCell[] AllCells => _cellsByPosition.Values.ToArray();
		public float CellSize => _cellSize;
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
		public void DebugDraw(Color color, float duration = 0)
		{
			foreach (var kvp in _cellsByPosition)
			{
				var cellCoords = kvp.Key;
				var cellWorldPosition = GetWorldPositionFromCoords(cellCoords);

				var halfHeight = Vector3.forward * _cellSize / 2;
				var halfWidth = Vector3.right * _cellSize / 2;

				Vector3 topLeft = cellWorldPosition + halfHeight - halfWidth;
				Vector3 topRight = cellWorldPosition + halfHeight + halfWidth;
				Vector3 bottomRight = cellWorldPosition - halfHeight + halfWidth;
				Vector3 bottomLeft = cellWorldPosition - halfHeight - halfWidth;

				Debug.DrawLine(topLeft, topRight, color, duration);
				Debug.DrawLine(topRight, bottomRight, color, duration);
				Debug.DrawLine(bottomRight, bottomLeft, color, duration);
				Debug.DrawLine(bottomLeft, topLeft, color, duration);
			}
		}

		public IEnumerable<TCell> GetCellsInRadius(Vector3 worldPosition, float radius)
		{
			Vector3 topLeftPosition = worldPosition + new Vector3(-radius, 0, radius);
			Vector3 bottomRightPosition = worldPosition + new Vector3(radius, 0, -radius);

			Vector2 topLeftCoords = GetCoordsFromWorldPosition(topLeftPosition);
			Vector2 bottomRightCoords = GetCoordsFromWorldPosition(bottomRightPosition);

			// from left to right
			for (float x = topLeftCoords.x; x <= bottomRightCoords.x; x++)
			{
				// from bottom to top
				for (float y = bottomRightCoords.y; y <= topLeftCoords.y; y++)
				{
					Vector2 coords = new Vector2(x, y);
					yield return GetCellAtCoord(coords);
				}
			}
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

		public Vector3 GetWorldPositionFromCoords(Vector2 coords)
		{
			return new Vector3(coords.x * _cellSize, 0, coords.y * _cellSize);
		}

		private void AddCellFromWorldPosition(Vector3 position)
		{
			Vector2 coords = GetCoordsFromWorldPosition(position);

			AddCellFromCoords(coords);
		}

		private void AddCellFromCoords(Vector2 coords)
		{
			try
			{
				_cellsByPosition.Add(coords, (TCell)Activator.CreateInstance(typeof(TCell), coords, this));
			}
			catch (MissingMethodException e)
			{
				// TODO TF: let user create own action to create new cell
				throw new System.NotSupportedException("The constructor TCell is not valid. The constructor needs to be updated.");
			}
		}
		#endregion Methods
	}
}
