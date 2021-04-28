namespace Tartaros
{
	using System.Collections;
	using System.Collections.Generic;

	public static class CollectionExtensions
	{
		public static bool IsEmpty<T>(this ICollection<T> collection)
		{
			return collection.Count == 0;
		}

		public static bool ContainsElement<T>(this ICollection<T> collection)
		{
			return collection.Count > 0;
		}

		public static bool IsEmpty<T>(this Queue<T> queue) => queue.Count == 0;

		/// <summary>
		/// Do contains elements ?
		/// </summary>
		public static bool IsPopulated<T>(this Queue<T> queue) => queue.Count > 0;

		public static bool IsEmpty<T>(this T[] array)
		{
			return array.Length == 0;
		}
	}
}
