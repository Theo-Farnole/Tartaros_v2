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

		public bool ContainsWorldPosition(Vector3 position)
		{
			return ContainsPoint2D(new Vector2(position.x, position.z));
		}

		public bool ContainsPoint2D(Vector2 point)
		{
			return MathHelper.IsPointInPolygon(points, point);
		}
	}
}