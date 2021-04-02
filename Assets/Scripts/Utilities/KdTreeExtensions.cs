namespace Tartaros
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using UnityEngine;

	public static class KdTreeExtensions
	{
		public static T[] FindItemsInRadius<T>(this KdTree<T> kdTree, Vector3 position, float radius) where T : Component
		{
			var output = new List<T>();

			IEnumerable<T> itemsSortByDistance = kdTree.FindClose(position);

			foreach (T item in itemsSortByDistance)
			{
				if (IsInRadius(position, item.transform.position))
				{
					output.Add(item);
				}
			}

			return output.ToArray();

			bool IsInRadius(Vector3 p1, Vector3 p2)
			{
				return Vector3.Distance(p1, p2) <= radius;
			}
		}
	}
}
