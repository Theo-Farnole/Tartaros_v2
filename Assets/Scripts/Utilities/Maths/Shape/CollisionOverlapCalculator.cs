namespace Tartaros.Math
{
	using UnityEngine;

	public static class CollisionOverlapCalculator
	{
		public static bool DoCircleOverlap(Circle shape1, Circle shape2)
		{
			float distance = Vector2.Distance(shape1.position, shape2.position);
			float distanceMin = shape1.radius + shape2.radius;

			return distance <= distanceMin;
		}
	}
}
