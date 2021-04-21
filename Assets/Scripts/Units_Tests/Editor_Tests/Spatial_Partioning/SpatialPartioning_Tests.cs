namespace Tartaros.Tests.SpartialPartioning
{
	using NUnit.Framework;
	using System.Reflection;
	using UnityEngine;

	public class SpatialPartioning_Tests
	{
		private const float CELL_SIZE = 1;
		private const float DETECTION_RADIUS = 1;
		private SpatialPartioning _spatialPartioning = null;

		[SetUp]
		public void SetUp()
		{
			_spatialPartioning = new SpatialPartioning(CELL_SIZE);
		}

		[Test]
		public void When_CallGetElementsInRadius_While_ThereIsOnlyElementsInRadius_Should_ReturnThem()
		{
			Transform[] inRangeTransforms = CreateInRangeTransform();

			_spatialPartioning.AddElements(inRangeTransforms);

			var actualTransformInRange = _spatialPartioning.GetElementsInRadius(new Vector3(1.5f, 0, 1.5f), DETECTION_RADIUS);

			Assert.AreEqual(inRangeTransforms.Length, actualTransformInRange.Length);
			Assert.Contains(inRangeTransforms[0], actualTransformInRange);
			Assert.Contains(inRangeTransforms[1], actualTransformInRange);
			Assert.Contains(inRangeTransforms[2], actualTransformInRange);
		}


		[Test]
		public void When_GetElementsInRadius_While_ThereIsNoEnemy_Should_ReturnEmpty()
		{
			var transformInRange = _spatialPartioning.GetElementsInRadius(new Vector3(1.5f, 0, 1.5f), 1f);

			Assert.AreEqual(0, transformInRange.Length);
		}

		[Test]
		public void When_GetElementsInRadius_While_ThereIsOnlyEnemiesOutRadius_Should_ReturnEmpty()
		{
			Transform[] outRangeTransforms = CreateOutRangeTransform();

			_spatialPartioning.AddElements(outRangeTransforms);

			var actualTransformInRange = _spatialPartioning.GetElementsInRadius(new Vector3(1.5f, 0, 1.5f), 1f);

			Assert.AreEqual(0, actualTransformInRange.Length);
		}

		[Test]
		public void When_GetElementsInRadius_While_ThereIsEnemiesInAndOutRadius_Should_ReturnEnemiesInRadius()
		{
			Transform[] outRangeTransforms = CreateOutRangeTransform();
			Transform[] inRangeTransforms = CreateInRangeTransform();

			_spatialPartioning.AddElements(inRangeTransforms);
			_spatialPartioning.AddElements(outRangeTransforms);

			var actualTransformInRange = _spatialPartioning.GetElementsInRadius(new Vector3(1.5f, 0, 1.5f), DETECTION_RADIUS);

			Assert.AreEqual(inRangeTransforms.Length, actualTransformInRange.Length);
			Assert.Contains(inRangeTransforms[0], actualTransformInRange);
			Assert.Contains(inRangeTransforms[1], actualTransformInRange);
			Assert.Contains(inRangeTransforms[2], actualTransformInRange);
		}

		private static Transform[] CreateOutRangeTransform()
		{
			Transform[] outRangeTransforms = new Transform[]
						{
				new GameObject("Out Range 1").transform,
				new GameObject("Out Range 2").transform,
				new GameObject("Out Range 3").transform,
						};


			// represent the position of transform
			// X is the center
			// +---+---+---+---+
			// |   | 2 |   | 0 |
			// +-------+---+---+
			// |   |   |   |   |
			// +-------+---+---+
			// |   | X |   |   |
			// +---+---+---+---+
			// |   |   |   | 1 |
			// +---+---+---+---+
			//
			// 0=(4;4) | 1=(4;0) | 2=(2;4)


			outRangeTransforms[0].position = new Vector3(3.5f, 0, 3.5f);
			outRangeTransforms[1].position = new Vector3(3.5f, 0, 0.5f);
			outRangeTransforms[2].position = new Vector3(1.5f, 0, 3.5f);
			return outRangeTransforms;
		}

		private static Transform[] CreateInRangeTransform()
		{
			Transform[] inRangeTransforms = new Transform[]
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


			inRangeTransforms[0].position = new Vector3(1.5f, 0, 1.5f); // on the same cell
			inRangeTransforms[1].position = new Vector3(2.5f, 0, 1.5f);
			inRangeTransforms[2].position = new Vector3(1.5f, 0, 2.5f);
			return inRangeTransforms;
		}
	}
}
