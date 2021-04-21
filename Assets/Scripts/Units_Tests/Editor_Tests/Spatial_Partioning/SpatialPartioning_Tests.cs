namespace Tartaros.Tests.SpartialPartioning
{
	using NUnit.Framework;
	using System.Linq;
	using Tartaros.Utilities.SpatialPartioning;
	using UnityEngine;

	public class SpatialPartioning_Tests
	{
		private class SpatialPartioningObject : MonoBehaviour, ISpatialPartioningObject
		{
			public Vector3 WorldPosition => transform.position;
		}

		private const float CELL_SIZE = 1;
		private const float DETECTION_RADIUS = 1;
		private SpatialPartioning<SpatialPartioningObject> _spatialPartioning = null;

		[SetUp]
		public void SetUp()
		{
			_spatialPartioning = new SpatialPartioning<SpatialPartioningObject>(CELL_SIZE);
		}

		[Test]
		public void When_CallGetElementsInRadius_While_ThereIsOnlyElementsInRadius_Should_ReturnThem()
		{
			SpatialPartioningObject[] inRange = CreateInRange();

			_spatialPartioning.AddElements(inRange);

			var actualTransformInRange = _spatialPartioning.GetElementsInRadius(new Vector3(1.5f, 0, 1.5f), DETECTION_RADIUS);

			Assert.AreEqual(inRange.Length, actualTransformInRange.Length);
			Assert.Contains(inRange[0], actualTransformInRange);
			Assert.Contains(inRange[1], actualTransformInRange);
			Assert.Contains(inRange[2], actualTransformInRange);
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
			SpatialPartioningObject[] outRangeTransforms = CreateOutRange();

			_spatialPartioning.AddElements(outRangeTransforms);

			var actualTransformInRange = _spatialPartioning.GetElementsInRadius(new Vector3(1.5f, 0, 1.5f), 1f);

			Assert.AreEqual(0, actualTransformInRange.Length);
		}

		[Test]
		public void When_GetElementsInRadius_While_ThereIsEnemiesInAndOutRadius_Should_ReturnEnemiesInRadius()
		{
			SpatialPartioningObject[] outRange = CreateOutRange();
			SpatialPartioningObject[] inRange = CreateInRange();

			_spatialPartioning.AddElements(inRange);
			_spatialPartioning.AddElements(outRange);

			var actualTransformInRange = _spatialPartioning.GetElementsInRadius(new Vector3(1.5f, 0, 1.5f), DETECTION_RADIUS);

			Assert.AreEqual(inRange.Length, actualTransformInRange.Length);
			Assert.Contains(inRange[0], actualTransformInRange);
			Assert.Contains(inRange[1], actualTransformInRange);
			Assert.Contains(inRange[2], actualTransformInRange);
		}

		private static SpatialPartioningObject[] CreateOutRange()
		{
			Transform[] outRange = new Transform[]
			{
				new GameObject("Out Range 1", typeof(SpatialPartioningObject)).transform,
				new GameObject("Out Range 2", typeof(SpatialPartioningObject)).transform,
				new GameObject("Out Range 3", typeof(SpatialPartioningObject)).transform,
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


			outRange[0].position = new Vector3(3.5f, 0, 3.5f);
			outRange[1].position = new Vector3(3.5f, 0, 0.5f);
			outRange[2].position = new Vector3(1.5f, 0, 3.5f);

			return outRange.Select(x => x.GetComponent<SpatialPartioningObject>()).ToArray();
		}

		private static SpatialPartioningObject[] CreateInRange()
		{
			Transform[] inRange = new Transform[]
			{
				new GameObject("In Range 1", typeof(SpatialPartioningObject)).transform,
				new GameObject("In Range 2", typeof(SpatialPartioningObject)).transform,
				new GameObject("In Range 3", typeof(SpatialPartioningObject)).transform,
			};


			// represent the position of the in range transform
			// +---+---+---+
			// |   | 2 |   |
			// +-------+---+
			// |   | 0 | 1 |
			// +-------+---+
			// |   |   |   |
			// +---+---+---+


			inRange[0].position = new Vector3(1.5f, 0, 1.5f); // on the same cell
			inRange[1].position = new Vector3(2.5f, 0, 1.5f);
			inRange[2].position = new Vector3(1.5f, 0, 2.5f);

			return inRange.Select(x => x.GetComponent<SpatialPartioningObject>()).ToArray();
		}
	}
}
