namespace Tartaros.Tests.Maths
{
	using Tartaros.Math;
	using NUnit.Framework;
	using UnityEngine;

	public class OverlapTests_RectangleWithRectangle
	{
		[Test]
		public void When_RectangleEdgesOverlap_Should_ReturnTrue()
		{
			Rectangle rect1 = new Rectangle(Vector2.zero, Vector2.one);
			Rectangle rect2 = new Rectangle(Vector2.one, Vector2.one);

			Assert.IsTrue(CollisionOverlapCalculator.DoOverlap(rect1, rect2));
		}

		[Test]
		public void When_RectanglesOverlapOnlyOnX_Should_ReturnFalse()
		{
			Rectangle rect1 = new Rectangle(new Vector2(0, 0), Vector2.one);
			Rectangle rect2 = new Rectangle(new Vector2(0, 50), Vector2.one);

			Assert.IsFalse(CollisionOverlapCalculator.DoOverlap(rect1, rect2));
		}

		[Test]
		public void When_RectanglesOverlapOnlyOnY_Should_ReturnFalse()
		{
			Rectangle rect1 = new Rectangle(new Vector2(0, 0), Vector2.one);
			Rectangle rect2 = new Rectangle(new Vector2(50, 0), Vector2.one);

			Assert.IsFalse(CollisionOverlapCalculator.DoOverlap(rect1, rect2));
		}

		[Test]
		public void When_RectanglesOverlapFarOver_Should_ReturnFalse()
		{
			Rectangle rect1 = new Rectangle(new Vector2(0, 50), Vector2.one);
			Rectangle rect2 = new Rectangle(new Vector2(50, 0), Vector2.one);

			Assert.IsFalse(CollisionOverlapCalculator.DoOverlap(rect1, rect2));
		}
	}
}
