namespace Tartaros.Tests
{
	using Tartaros.Math;
	using NUnit.Framework;
	using UnityEngine;

	public class OverlapTests_CircleWithCircle
	{
		[Test]
		public void When_CircleAreOverlap_Should_ReturnTrue()
		{
			Circle c1 = new Circle(new Vector2(5, 5), 1);
			Circle c2 = new Circle(new Vector2(5, 6), 1);

			Assert.IsTrue(CollisionOverlapCalculator.DoOverlap(c1, c2));
		}

		[Test]
		public void When_CirclesAreOverlappingPixelPerfect_Should_ReturnTrue()
		{
			Circle c1 = new Circle(new Vector2(5, 5), 1);
			Circle c2 = new Circle(new Vector2(5, 7), 1);

			Assert.IsTrue(CollisionOverlapCalculator.DoOverlap(c1, c2));
		}

		[Test]
		public void When_CirclesAreOneDiameterFar_Should_ReturnFalse()
		{
			Circle c1 = new Circle(new Vector2(0, 0), 1);
			Circle c2 = new Circle(new Vector2(3, 0), 1);

			Assert.IsFalse(CollisionOverlapCalculator.DoOverlap(c1, c2));

		}

		[Test]
		public void When_CircleAreFarOver_Should_ReturnTrue()
		{
			Circle c1 = new Circle(new Vector2(5, 5), 1);
			Circle c2 = new Circle(new Vector2(5, 8), 1);

			Assert.IsFalse(CollisionOverlapCalculator.DoOverlap(c1, c2));
		}

		[Test]
		public void When_CircleIsInsideOtherCircle_Should_ReturnTrue()
		{
			Circle c1 = new Circle(Vector2.zero, 1);
			Circle c2 = new Circle(Vector2.zero, 0.5f);

			Assert.IsTrue(CollisionOverlapCalculator.DoOverlap(c1, c2));
		}
	}
}
