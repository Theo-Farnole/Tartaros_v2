namespace Tartaros.Tests
{
	using Tartaros.Math;
	using NUnit.Framework;
	using UnityEngine;

	public class CircleOverlap_Tests
	{
		[Test]
		public void When_CircleAreOverlap_Should_ReturnTrue()
		{
			Circle c1 = new Circle(new Vector2(5, 5), 1);
			Circle c2 = new Circle(new Vector2(5, 6), 1);

			Assert.IsTrue(CollisionOverlapCalculator.DoCircleOverlap(c1, c2));
		}

		[Test]
		public void When_CirclesAreOverlappingPixelPerfect_Should_ReturnTrue()
		{
			Circle c1 = new Circle(new Vector2(5, 5), 1);
			Circle c2 = new Circle(new Vector2(5, 7), 1);

			Assert.IsTrue(CollisionOverlapCalculator.DoCircleOverlap(c1, c2));
		}

		[Test]
		public void When_CircleAreFarOver_Should_ReturnTrue()
		{
			Circle c1 = new Circle(new Vector2(5, 5), 1);
			Circle c2 = new Circle(new Vector2(5, 8), 1);

			Assert.IsFalse(CollisionOverlapCalculator.DoCircleOverlap(c1, c2));
		}
	}
}
