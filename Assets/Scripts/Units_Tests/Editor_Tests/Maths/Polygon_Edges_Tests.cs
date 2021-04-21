namespace Tartaros.Tests.Maths
{
	using NUnit.Framework;
	using Tartaros.Math;
	using UnityEngine;

	public class Polygon_Edges_Tests
	{
		[Test]
		public void When_PolygonHasFourEdges_Should_ReturnFourEdges()
		{
			ConvexPolygon convexPolygon = ConvexPolygon.OneSquare;

			Vector2[] edges = convexPolygon.Normals;
			Assert.AreEqual(4, edges.Length);
		}

		[Test]
		public void When_Polygon_Should_ReturnCorrectEdges()
		{
			ConvexPolygon convexPolygon = ConvexPolygon.OneSquare;
			Vector2[] edges = convexPolygon.Normals;

			Assert.Contains(Vector2.right, edges);
			Assert.Contains(Vector2.up, edges);
			Assert.Contains(Vector2.left, edges);
			Assert.Contains(Vector2.down, edges);
		}
	}
}
