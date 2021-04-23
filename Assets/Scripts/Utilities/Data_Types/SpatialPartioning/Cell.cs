namespace Tartaros.Utilities.SpatialPartioning
{
	using System.Collections.Generic;
	using Tartaros.Math;
	using UnityEngine;

	public class Cell<T> where T : class, ISpatialPartioningObject
	{
		private List<T> _elements = new List<T>(100);

		private readonly Vector2 _coords = Vector2.zero;
		private readonly CellsGrid2D<Cell<T>> _grid = null;
		private readonly float _cellSize = -1;

		public T[] Elements => _elements.ToArray();
		public Vector2 Position => _coords;

		public Cell(Vector2 coords, CellsGrid2D<Cell<T>> grid)
		{
			_coords = coords;
			_grid = grid;
			_cellSize = _grid.CellSize;
		}


		public bool Contains(T element)
		{
			return _elements.Contains(element);
		}

		public void RemoveElement(T element) => _elements.Remove(element);
		public void AddElement(T element) => _elements.Add(element);

		public bool Overlap(Vector2 circleCoords, float circleRadius)
		{
			return CollisionOverlapCalculator.circleRect(circleCoords.x, circleCoords.y, circleRadius, _coords.x, _coords.y, _cellSize, _cellSize);
		}

		public List<T> GetElementsInRadius(Vector2 coords, float radius)
		{
			if (IsCellCompletelyInRadius(coords, radius) == true)
			{
				return _elements;
			}
			else
			{
				var worldPosition = _grid.GetWorldPositionFromCoords(coords);

				List<T> output = new List<T>(_elements.Count);

				// is cell partial in radius, we must check each elements
				for (int elementIndex = 0, elementsLength = _elements.Count; elementIndex < elementsLength; elementIndex++)
				{
					T element = _elements[elementIndex];

					if (Vector3.Distance(element.WorldPosition, worldPosition) <= radius)
					{
						output.Add(element);
					}
				}

				return output;
			}
		}

		public IEnumerable<T> EnumerateElementsInRadius(Vector2 coords, float radius)
		{
			if (IsCellCompletelyInRadius(coords, radius) == true)
			{
				for (int i = 0, length = _elements.Count; i < length; i++)
				{
					yield return _elements[i];

				}
			}
			else
			{
				Vector3 worldPosition = _grid.GetWorldPositionFromCoords(coords);

				// is cell partial in radius, we must check each elements
				for (int elementIndex = 0, elementsLength = _elements.Count; elementIndex < elementsLength; elementIndex++)
				{
					T element = _elements[elementIndex];

					if (Vector3.Distance(element.WorldPosition, worldPosition) <= radius)
					{
						yield return element;
					}
				}
			}
		}

		private bool IsCellCompletelyInRadius(Vector2 coords, float radius)
		{
			float cx = coords.x;
			float cy = coords.y;

			float rw = _cellSize;
			float rh = _cellSize;

			float rx = _coords.x;
			float ry = _coords.y;


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
			return (distance <= radius);
		}
	}
}
