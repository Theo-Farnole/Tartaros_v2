namespace Tartaros
{
	using System.Collections.Generic;

	public static class QueueExtensions
	{
		/// <summary>
		/// WARNING: this method break the principe of a queue. Are you sure that there is not better way ?
		/// </summary>
		public static T Last<T>(this Queue<T> q)
		{
			return q.ToArray()[0];
		}
	}
}
