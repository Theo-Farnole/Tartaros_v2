namespace Tartaros.Math
{
	using System.Collections.Generic;
	using UnityEngine;

	public class ConvexPolygon
	{
		public List<Vector2> points = new List<Vector2>();

		public ConvexPolygon(params Vector2[] points)
		{
			this.points = new List<Vector2>(points);
		}	

		public bool ContainsPoint(Vector2 point)
		{
			return MathHelper.IsPointInPolygon(points, point);
		}
	}
}