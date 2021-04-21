namespace Tartaros.Utilities.SpatialPartioning
{
	using System.Collections.Generic;
	using UnityEngine;

	internal class Cell<T> where T : ISpatialPartioningObject
	{
		private List<T> _elements = new List<T>();
		private Vector2 _coords = Vector2.zero;

		public Vector2 Position => _coords;

		public Cell(Vector2 coords)
		{
			_coords = coords;
		}

		public T[] Elements => _elements.ToArray();

		public bool Contains(T element)
		{
			return _elements.Contains(element);
		}

		public void RemoveElement(T element) => _elements.Remove(element);
		public void AddElement(T element) => _elements.Add(element);
	}
}
