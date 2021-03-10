namespace Tartaros.Tests
{
	using NUnit.Framework;
	using System.Collections;
	using Tartaros.Entities;
	using Tartaros.Entities.Detection;
	using Tartaros.ServicesLocator;
	using UnityEngine;
	using UnityEngine.TestTools;

	public class EntityDetection_Tests
	{
		#region Fields
		private EntitiesKDTrees _entitiesKDTrees = null;
		private EntityDetection _playerEntDetection = null;
		private Entity _enemyEntity = null;
		#endregion Fields

		#region Methods
		[UnitySetUp]
		public IEnumerator SetUp()
		{
			LogAssert.ignoreFailingMessages = true;

			new GameObject("Services").AddComponent<Services>();
			_entitiesKDTrees = new GameObject("Entities KD Tree").AddComponent<EntitiesKDTrees>();

			yield return null;
		}

		[TearDown]
		public void TearDown()
		{
			LogAssert.ignoreFailingMessages = false;
		}

		[UnityTest]
		public IEnumerator GetNearestOpponentUnit_When_OpponentUnit_Should_ReturnTrue()
		{
			yield return SetupPlayerAndEnemy(EntityType.Unit, EntityType.Unit);

			Assert.AreEqual(_enemyEntity, _playerEntDetection.GetNearestOpponentUnit());
		}


		[UnityTest]
		public IEnumerator GetNearestOpponentUnit_When_OpponentBuilding_Should_ReturnNull()
		{
			yield return SetupPlayerAndEnemy(EntityType.Unit, EntityType.Building);

			Assert.AreEqual(null, _playerEntDetection.GetNearestOpponentUnit());
		}


		private IEnumerator SetupPlayerAndEnemy(EntityType playerType, EntityType enemyType)
		{			
			LogAssert.ignoreFailingMessages = true;

			Entity playerEnt = EntitiesTestsSetupHelper.CreateEntity(Vector3.zero, Team.Player, playerType, "Player");
			_playerEntDetection = EntitiesTestsSetupHelper.AddDetectionBehaviour(playerEnt, 5);

			_enemyEntity = EntitiesTestsSetupHelper.CreateEntity(new Vector3(0, 1, 1), Team.Enemy, enemyType, "Enemy");

			yield return null;			
		}		
		#endregion Methods
	}
}