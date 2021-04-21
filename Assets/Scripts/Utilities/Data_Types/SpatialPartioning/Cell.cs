namespace Tartaros.Utilities.SpatialPartioning
{
	using System.Collections.Generic;

	internal class Cell<T> where T : ISpatialPartioningObject
	{
		private List<T> _elements = new List<T>();

		public T[] Elements => _elements.ToArray();

		public bool Contains(T element)
		{
			return _elements.Contains(element);
		}

		public void RemoveElement(T element) => _elements.Remove(element);
		public void AddElement(T element) => _elements.Add(element);
	}
}
