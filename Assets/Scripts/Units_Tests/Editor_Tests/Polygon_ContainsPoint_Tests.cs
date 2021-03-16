namespace Tartaros.Tests
{
	using NUnit.Framework;
	using Tartaros.Math;
	using UnityEngine;

	public class Polygon_ContainsPoint_Tests
	{
		[Test]
		public void Should_ContainsPointInCenter()
		{
			ConvexPolygon polygon = new ConvexPolygon(
				new Vector3(0, 0),
				new Vector3(0, 2),
				new Vector3(2, 0),
				new Vector3(2, 2)
			);

			Assert.IsTrue(polygon.ContainsPoint(Vector3.one));
		}

		[Test]
		public void Should_NotContainsMinPoint()
		{
			ConvexPolygon polygon = new ConvexPolygon(
				new Vector3(0, 0),
				new Vector3(0, 2),
				new Vector3(2, 0),
				new Vector3(2, 2)
			);

			Assert.IsFalse(polygon.ContainsPoint(Vector3.zero));
		}

		[Test]
		public void Should_NotContainsMaxPoint()
		{
			ConvexPolygon polygon = new ConvexPolygon(
				new Vector3(0, 0),
				new Vector3(0, 2),
				new Vector3(2, 0),
				new Vector3(2, 2)
			);

			Assert.IsFalse(polygon.ContainsPoint(Vector3.one * 2));
		}

		[Test]
		public void Should_NotContainsOutOfPolygonPoint()
		{
			ConvexPolygon polygon = new ConvexPolygon(
				new Vector3(0, 0),
				new Vector3(0, 2),
				new Vector3(2, 0),
				new Vector3(2, 2)
			);

			Assert.IsFalse(polygon.ContainsPoint(Vector3.one * 3));
		}
	}
}