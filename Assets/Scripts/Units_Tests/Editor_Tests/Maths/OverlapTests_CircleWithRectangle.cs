namespace Tartaros.Tests
{
	using NUnit.Framework;
	using Tartaros.Math;
	using UnityEngine;

	public class OverlapTests_CircleWithRectangle
	{
		[Test]
		public void When_EdgesOverlap_Should_ReturnTrue()
		{
			Rectangle rect = new Rectangle(new Vector2(100, 0), Vector2.one);
			Circle circle = new Circle(new Vector2(102, 0), 1);

			Assert.IsTrue(CollisionOverlapCalculator.DoOverlap(rect, circle));
		}

		[Test]
		public void When_Overlap_Should_ReturnTrue()
		{
			Rectangle rect = new Rectangle(new Vector2(100, 0), Vector2.one);
			Circle circle = new Circle(new Vector2(101, 0), 1);

			Assert.IsTrue(CollisionOverlapCalculator.DoOverlap(rect, circle));
		}

		[Test]
		public void When_OverlapOnlyOnX_Should_ReturnFalse()
		{
			Rectangle rect = new Rectangle(new Vector2(100, 100), Vector2.one);
			Circle circle = new Circle(new Vector2(100, 0), 1);

			Assert.IsFalse(CollisionOverlapCalculator.DoOverlap(rect, circle));
		}

		[Test]
		public void When_OverlapOnlyOnY_Should_ReturnFalse()
		{
			Rectangle rect = new Rectangle(new Vector2(0, 100), Vector2.one);
			Circle circle = new Circle(new Vector2(101, 100), 1);

			Assert.IsFalse(CollisionOverlapCalculator.DoOverlap(rect, circle));
		}

		[Test]
		public void When_DontOverlap_Should_ReturnFalse()
		{
			Rectangle rect = new Rectangle(new Vector2(0, 100), Vector2.one);
			Circle circle = new Circle(new Vector2(100, 150), 1);

			Assert.IsFalse(CollisionOverlapCalculator.DoOverlap(rect, circle));
		}

		[Test]
		public void When_CircleIsInsideRectangle_Should_ReturnTrue()
		{
			Rectangle rect = new Rectangle(Vector2.zero, Vector2.one * 5);
			Circle circle = new Circle(Vector2.zero, 1);

			Assert.IsTrue(CollisionOverlapCalculator.DoOverlap(rect, circle));
		}
	}
}
