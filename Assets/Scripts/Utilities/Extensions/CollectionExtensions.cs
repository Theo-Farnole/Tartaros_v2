namespace Tartaros
{
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

		public static bool IsEmpty<T>(this Queue<T> queue) => (queue as ICollection<T>).IsEmpty();

		public static bool ContainsElement<T>(this Queue<T> queue) => (queue as ICollection<T>).ContainsElement();

		public static bool IsEmpty<T>(this T[] array)
		{
			return array.Length == 0;
		}
	}
}
