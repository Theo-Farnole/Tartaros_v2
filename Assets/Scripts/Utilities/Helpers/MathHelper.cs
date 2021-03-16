namespace Tartaros
{
	using UnityEngine;

	public static class MathHelper
	{
		public static Vector3 CalculateCentroid(Vector3[] points)
		{
			Vector3 centroid = Vector3.zero;

			foreach (var point in points)
			{
				centroid += point;
			}

			centroid /= points.Length;


			return centroid;
		}
	}
}
