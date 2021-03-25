namespace Tartaros.Math
{
	using UnityEngine;

	public static class CollisionOverlapCalculator
	{
		public static bool DoOverlap(Circle c1, Circle c2)
		{
			float distance = Vector2.Distance(c1.position, c2.position);
			float distanceMin = c1.radius + c2.radius;

			return distance <= distanceMin;
		}

		public static bool DoOverlap(Rectangle rect1, Rectangle rect2)
		{
			return (rect1.X <= rect2.X + rect2.Width && rect1.X + rect1.Width >= rect2.X && rect1.Y <= rect2.Y + rect2.Height && rect1.Height + rect1.Y >= rect2.Y);
		}

		public static bool DoOverlap(Rectangle rect, Circle circle)
		{
			return DoOverlap(circle, rect);
		}

		public static bool DoOverlap(Circle circle, Rectangle rect)
		{
			return circle.ContainsPosition(rect.BottomRight) || circle.ContainsPosition(rect.TopLeft) || circle.ContainsPosition(rect.Min) || circle.ContainsPosition(rect.Max);
		}

		public static bool DoOverlap(ConvexPolygon polygon, Circle circle)
		{
			return DoOverlap(circle, polygon);
		}

		public static bool DoOverlap(Circle circle, ConvexPolygon polygon)
		{
			foreach (Vector2 point in polygon.vertices)
			{
				if (circle.ContainsPosition(point) == true)
				{
					return true;
				}
			}

			return false;
		}
	}
}
