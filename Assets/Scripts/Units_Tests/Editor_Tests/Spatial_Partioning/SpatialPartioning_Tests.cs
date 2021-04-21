namespace Tartaros.Tests.SpartialPartioning
{
	using NUnit.Framework;
	using System.Reflection;
	using UnityEngine;

	public class SpatialPartioning_Tests
	{
		private const float CELL_SIZE = 1;
		private SpatialPartioning _spatialPartioning = null;

		[SetUp]
		public void SetUp()
		{
			_spatialPartioning = new SpatialPartioning(CELL_SIZE);
		}

		[Test]
		public void When_CallGetElementsInRadius_While_ThereIsOnlyElementsInRadius_Should_ReturnThem()
		{
			Transform[] inRangeTransform = new Transform[]
			{
				new GameObject("In Range 1").transform,
				new GameObject("In Range 2").transform,
				new GameObject("In Range 3").transform,
			};


			// represent the position of the in range transform
			// +---+---+---+
			// |   | 2 |   |
			// +-------+---+
			// |   | 0 | 1 |
			// +-------+---+
			// |   |   |   |
			// +---+---+---+


			inRangeTransform[0].position = new Vector3(1.5f, 0, 1.5f); // on the same cell
			inRangeTransform[1].position = new Vector3(2.5f, 0, 1.5f);
			inRangeTransform[2].position = new Vector3(1.5f, 0, 2.5f);

			var actualTransformInRange = _spatialPartioning.GetElementsInRadius(new Vector3(1.5f, 0, 1.5f), 1f);

			Assert.AreEqual(inRangeTransform.Length, actualTransformInRange.Length);
			Assert.Contains(inRangeTransform[0], actualTransformInRange);
			Assert.Contains(inRangeTransform[1], actualTransformInRange);
			Assert.Contains(inRangeTransform[2], actualTransformInRange);
		}

		public void When_GetCellsInRadius_Should_ReturnNine()
		{

		}
	}
}
