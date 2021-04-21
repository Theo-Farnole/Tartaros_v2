namespace Tartaros
{
	using System.Collections.Generic;
	using System.Linq;

	public static class ListExtensions
	{
		public static bool TryAddWithoutDuplicate<T>(this List<T> list, T item)
		{
			if (list.Contains(item) == false)
			{
				list.Add(item);
				return true;
			}
			else
			{
				return false;
			}
		}

		public static bool HasDuplicate<T>(this List<T> list)
		{
			return list.GroupBy(x => x)
			  .Where(g => g.Count() > 1)
			  .Count() > 0;
		}

		public static T[] GetDuplicates<T>(this List<T> list)
		{
			return list.GroupBy(x => x)
			  .Where(g => g.Count() > 1)
			  .Select(y => y.Key)
			  .ToArray();
		}
	}
}
