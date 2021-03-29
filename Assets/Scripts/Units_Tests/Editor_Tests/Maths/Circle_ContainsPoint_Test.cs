namespace Tartaros.Tests
{
	using NUnit.Framework;
	using Tartaros.Math;
	using UnityEngine;

	public class Circle_ContainsPoint_Test
	{
		[Test]
		public void When_PointDontOverlapCircle_Should_ReturnFalse()
		{
			Circle c = new Circle(Vector2.zero, 1);
			Assert.IsFalse(c.ContainsPosition(Vector2.one * 5));
		}

		[Test]
		public void When_PointOverlapCircle_Should_ReturnTrue()
		{
			Circle c = new Circle(Vector2.zero, 1);
			Assert.IsTrue(c.ContainsPosition(Vector2.zero));
		}
	}
}
