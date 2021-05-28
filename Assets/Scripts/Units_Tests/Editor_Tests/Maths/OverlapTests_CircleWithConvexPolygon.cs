namespace Tartaros.Tests.Collisions
{
	using NUnit.Framework;
	using Tartaros.Math;
	using UnityEngine;

	public class OverlapTests_CircleWithConvexPolygon
	{
		[Test]
		public void When_OverlapCenter_Should_ReturnTrue()
		{
			ConvexPolygon polygon = CreateSquarePolygon();
			Circle circle = new Circle(Vector2.zero, 1);

			Assert.IsTrue(CollisionOverlapCalculator.DoOverlap(polygon, circle));
		}

		[Test]
		public void When_OverlapOneEdge_Should_ReturnTrue()
		{
			ConvexPolygon polygon = CreateSquarePolygon();
			Circle circle = new Circle(new Vector2(2, 1), 1);

			Assert.IsTrue(CollisionOverlapCalculator.DoOverlap(polygon, circle));
		}

		[Test]
		public void When_NoOverlap_Should_ReturnFalse()
		{
			ConvexPolygon polygon = CreateSquarePolygon();
			Circle circle = new Circle(new Vector2(5, 1), 1);

			Assert.IsFalse(CollisionOverlapCalculator.DoOverlap(polygon, circle));
		}

		[Test]
		public void When_OverlapNonConvex_Should_ReturnFalse()
		{
			ConvexPolygon polygon = new ConvexPolygon(
				Vector2.one,
				new Vector2(2, 0),
				new Vector2(2, 2),
				new Vector2(1, 1),
				new Vector2(3, 0)
			);

			Circle circle = new Circle(new Vector2(1, 1.5f), 0.1f);

			Assert.IsTrue(CollisionOverlapCalculator.DoOverlap(polygon, circle));
		}

		private static ConvexPolygon CreateSquarePolygon()
		{
			return new ConvexPolygon(Vector2.one, new Vector2(1, -1), new Vector2(-1, -1), new Vector2(-1, 1));
		}
	}
}
