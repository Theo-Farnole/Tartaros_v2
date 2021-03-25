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
	}
}
