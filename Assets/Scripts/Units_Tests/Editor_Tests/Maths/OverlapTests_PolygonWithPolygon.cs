namespace Tartaros.Tests.Maths
{
	using NUnit.Framework;
	using Tartaros.Math;
	using UnityEngine;

	public class OverlapTests_PolygonWithPolygon
	{
		[Test]
		public void When_PolygonIsInsideBiggerPolygon_Should_ReturnTrue()
		{
			ConvexPolygon p1 = new ConvexPolygon(new Vector2(4, 4), new Vector2(4, -4), new Vector2(-4, -4), new Vector2(-4, 4));
			ConvexPolygon p2 = ConvexPolygon.OneSquare;

			Assert.IsTrue(CollisionOverlapCalculator.DoOverlap(p1, p2));
		}

		[Test]
		public void When_PolygonTouchPoliger_Should_ReturnTrue()
		{
			ConvexPolygon p1 = new ConvexPolygon(new Vector2(0, 1), new Vector2(1, 0), new Vector2(0, -1), new Vector2(-1, -1), new Vector2(-2, 0), new Vector2(-1, 1));
			ConvexPolygon p2 = new ConvexPolygon(new Vector2(0, 0), new Vector2(-1, 1), new Vector2(0, 2), new Vector2(1, 2), new Vector2(2, 1), new Vector2(1, 0));

			Assert.IsTrue(CollisionOverlapCalculator.DoOverlap(p1, p2));
		}

		[Test]
		public void When_PolygonFarOverPolygon_Should_ReturnFalse()
		{
			ConvexPolygon p1 = new ConvexPolygon(new Rectangle(Vector2.zero, Vector2.one));
			ConvexPolygon p2 = new ConvexPolygon(new Rectangle(Vector2.one * 5, Vector2.one));

			Assert.IsFalse(CollisionOverlapCalculator.DoOverlap(p1, p2));
		}
	}
}
