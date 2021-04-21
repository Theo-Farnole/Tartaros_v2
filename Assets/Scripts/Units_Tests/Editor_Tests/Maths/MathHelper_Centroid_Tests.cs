namespace Tartaros.Tests.Maths
{
	using NUnit.Framework;
	using UnityEngine;

	public class MathHelper_Centroid_Tests
	{
		[Test]
		public void Centroid_When_AllPointsEqualsZero()
		{
			Vector3[] points = new Vector3[]
			{
				Vector3.zero,
				Vector3.zero
			};

			Vector3 expectedCentroid = Vector3.zero;

			AssertCentroidCalculation(expectedCentroid, points);
		}

		[Test]
		public void Centroid_Test_01()
		{
			Vector3[] points = new Vector3[]
			{
				new Vector3(1, 1, 0),
				new Vector3(-1, -1, 0)
			};

			Vector3 expectedCentroid = Vector3.zero;

			AssertCentroidCalculation(expectedCentroid, points);
		}

		[Test]
		public void Centroid_Test_02()
		{
			Vector3[] points = new Vector3[]
			{
				new Vector3(1, 1, 0),
				new Vector3(1, 1, 0)
			};

			Vector3 expectedCentroid = new Vector3(1, 1, 0);

			AssertCentroidCalculation(expectedCentroid, points);
		}

		[Test]
		public void Centroid_Test_03()
		{
			Vector3[] points = new Vector3[]
			{
				new Vector3(1, 1, 0),
				new Vector3(1, 3, 0),
				new Vector3(3, 1, 0),
				new Vector3(3, 3, 0),
			};

			Vector3 expectedCentroid = new Vector3(2, 2, 0);

			AssertCentroidCalculation(expectedCentroid, points);
		}

		private void AssertCentroidCalculation(Vector3 expectedCentroid, Vector3[] points)
		{
			Vector3 centroid = MathHelper.CalculateCentroid(points);
			NUnit.Framework.Assert.AreEqual(expectedCentroid, centroid);
		}
	}
}