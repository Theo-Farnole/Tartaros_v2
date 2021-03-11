namespace Tartaros.Tests
{
	using NUnit.Framework;
	using System.Collections;
	using Tartaros.Entities;
	using Tartaros.Entities.Detection;
	using UnityEngine;
	using UnityEngine.TestTools;

	public class EntityDetection_IsNearestOpponentInAttackRange_Tests
	{
		#region Fields
		private const int DETECTION_RANGE = 5;
		private EntityDetection _entityDetection = null;
		#endregion Fields

		#region Methods
		[UnitySetUp]
		public IEnumerator SetUp()
		{
			LogAssert.ignoreFailingMessages = true;

			SetupHelper.CreateService();
			SetupHelper.CreateEntitiesKDTree();

			Entity detectorEntity = SetupHelper.CreateEntity(Vector3.zero, Team.Player, EntityType.Unit, "Player Detector");
			_entityDetection = SetupHelper.AddDetectionBehaviour(detectorEntity, DETECTION_RANGE);

			yield return null;
		}

		[TearDown]
		public void TearDown()
		{
			LogAssert.ignoreFailingMessages = false;
		}

		[Test]
		public void When_ThereIsNoOpponent_Return_False()
		{
			Assert.IsFalse(_entityDetection.IsNearestOpponentInDetectionRange());
		}

		[UnityTest]
		public IEnumerator When_ThereIsOneAlly_Return_False()
		{
			yield return CreateInRangeAlly();

			Assert.IsFalse(_entityDetection.IsNearestOpponentInDetectionRange());
		}

		[UnityTest]
		public IEnumerator When_ThereIsOneEnemyOutOfRange_Return_False()
		{
			yield return CreateOutOfRangeEnemy();

			Assert.IsFalse(_entityDetection.IsNearestOpponentInDetectionRange());
		}


		[UnityTest]
		public IEnumerator When_ThereIsOneEnemyInRange_Return_True()
		{
			yield return CreateInRangeEnemy();

			Assert.IsTrue(_entityDetection.IsNearestOpponentInDetectionRange());
		}

		private static IEnumerator CreateOutOfRangeEnemy()
		{
			LogAssert.ignoreFailingMessages = true;
			SetupHelper.CreateEntity(new Vector3(10, 0, 10), Team.Enemy, EntityType.Unit, "Enemy");

			yield return null;
		}

		private static IEnumerator CreateInRangeEnemy()
		{
			LogAssert.ignoreFailingMessages = true;
			SetupHelper.CreateEntity(Vector3.zero, Team.Enemy, EntityType.Unit, "Enemy");

			yield return null;
		}

		private static IEnumerator CreateInRangeAlly()
		{
			LogAssert.ignoreFailingMessages = true;
			SetupHelper.CreateEntity(Vector3.zero, Team.Player, EntityType.Unit, "Ally");

			yield return null;
		}
		#endregion Methods
	}
}
