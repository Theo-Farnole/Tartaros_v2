namespace Tartaros.Tests
{
	using NUnit.Framework;
	using Tartaros.Math;
	using UnityEngine;

	public class OverlapTests_RectangleWithPolygon
	{
		[Test]
		public void When_RectangleIsInsidePolygon_Should_ReturnTrue()
		{
			ConvexPolygon polygon = new ConvexPolygon(new Vector2(4, 4), new Vector2(4, -4), new Vector2(-4, -4), new Vector2(-4, 4));
			Rectangle rectangle = Rectangle.OneSquare;

			Assert.IsTrue(CollisionOverlapCalculator.DoOverlap(polygon, rectangle));
		}

		[Test]
		public void When_RectangleTouchPolygonEdge_Should_ReturnTrue()
		{
			ConvexPolygon polygon = ConvexPolygon.OneSquare;
			Rectangle rectangle = new Rectangle(Vector2.one, Vector2.one);

			Assert.IsTrue(CollisionOverlapCalculator.DoOverlap(polygon, rectangle));
		}

		[Test]
		public void When_RectangleIsFarOverPolygonEdge_Should_ReturnFalse()
		{
			ConvexPolygon polygon = ConvexPolygon.OneSquare;
			Rectangle rectangle = new Rectangle(Vector2.one * 5, Vector2.one);

			Assert.IsFalse(CollisionOverlapCalculator.DoOverlap(polygon, rectangle));
		}
	}
}
