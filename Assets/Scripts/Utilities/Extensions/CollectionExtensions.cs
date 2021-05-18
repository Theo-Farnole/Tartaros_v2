namespace Tartaros
{
	using System.Collections;
	using System.Collections.Generic;
	using System.Linq;
	using UnityEditor;

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

		public static Queue<T> RemoveLastOccurenceOf<T>(this Queue<T> queue, T element)
		{
			List<T> list = queue.ToList();
			list.Reverse();

			// browse it until first occurence + note its index
			int lastOccurenceIndex = -1;

			for (int i = 0, length = list.Count; i < length; i++)
			{
				if (list[i].Equals(element))
				{
					lastOccurenceIndex = i;
					break;
				}
			}

			// occurence found
			if (lastOccurenceIndex >= 0)
			{
				list.RemoveAt(lastOccurenceIndex);
				list.Reverse();

				return new Queue<T>(list);
			}
			else
			{
				return new Queue<T>(queue);
			}
		}
	}
}
