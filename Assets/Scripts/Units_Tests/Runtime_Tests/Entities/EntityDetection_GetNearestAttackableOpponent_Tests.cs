namespace Tartaros.Tests
{
	using NUnit.Framework;
	using System.Collections;
	using Tartaros.Entities;
	using Tartaros.Entities.Detection;
	using UnityEngine;
	using UnityEngine.TestTools;

	public class EntityDetection_GetNearestAttackableOpponent_Tests
	{
		private const int DETECTION_RANGE = 5;
		private EntityDetection _entityDetection = null;

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

		[UnityTest]
		public IEnumerator When_MultipleEnemiesAreInRange_Should_ReturnNearestEnemy()
		{
			LogAssert.ignoreFailingMessages = true;

			var enemies = new Entity[]
			{
				SetupHelper.CreateEntity(new Vector3(0, 0, 1), Team.Enemy, EntityType.Unit, "Enemy 1"),
				SetupHelper.CreateEntity(new Vector3(0, 0, 5), Team.Enemy, EntityType.Unit, "Enemy 2")
			};

			foreach (Entity enemy in enemies)
			{
				SetupHelper.AddAttackBehaviour(enemy, 5);
			}

			yield return null;

			Assert.AreEqual(enemies[0] as IAttackable, _entityDetection.GetNearestAttackableOpponent());
		}
	}
}
