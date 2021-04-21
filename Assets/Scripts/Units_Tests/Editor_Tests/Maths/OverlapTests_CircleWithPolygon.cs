namespace Tartaros.Tests.Maths
{
	using NUnit.Framework;
	using Tartaros.Math;
	using UnityEngine;

	public class OverlapTests_CircleWithPolygon
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

		private static ConvexPolygon CreateSquarePolygon()
		{
			return new ConvexPolygon(Vector2.one, new Vector2(1, -1), new Vector2(-1, -1), new Vector2(-1, 1));
		}
	}
}
