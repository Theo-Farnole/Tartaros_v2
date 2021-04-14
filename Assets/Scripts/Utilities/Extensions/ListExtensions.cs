namespace Tartaros
{
	using System.Collections.Generic;

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
	}
}
