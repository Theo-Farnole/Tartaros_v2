namespace Tartaros.Tests
{
	using NUnit.Framework;
	using System.Collections;
	using Tartaros.Entities;
	using Tartaros.Entities.Detection;
	using UnityEngine;
	using UnityEngine.TestTools;

	public class EntityDetection_GetNearestAllyBuilding_Tests
	{
		#region Fields
		private EntityDetection _playerEntDetection = null;
		private Entity _enemyEntity = null;
		#endregion Fields

		#region Methods
		[UnitySetUp]
		public IEnumerator SetUp()
		{
			LogAssert.ignoreFailingMessages = true;

			SetupHelper.CreateService();
			SetupHelper.CreateEntitiesKDTree();

			yield return null;
		}

		[TearDown]
		public void TearDown()
		{
			LogAssert.ignoreFailingMessages = false;
		}

		[UnityTest]
		public IEnumerator When_AllyIsUnit_Should_ReturnNull()
		{
			yield return SetupTwoAllies(EntityType.Unit, EntityType.Unit);

			Assert.AreEqual(null, _playerEntDetection.GetNearestAllyBuilding());
		}


		[UnityTest]
		public IEnumerator When_AllyIsBuilding_Should_ReturnNull()
		{
			yield return SetupTwoAllies(EntityType.Unit, EntityType.Building);

			Assert.AreEqual(_enemyEntity, _playerEntDetection.GetNearestAllyBuilding());
		}


		private IEnumerator SetupTwoAllies(EntityType detectorType, EntityType secondEntityType)
		{
			LogAssert.ignoreFailingMessages = true;

			Entity playerEnt = SetupHelper.CreateEntity(Vector3.zero, Team.Player, detectorType, "Detector");
			_playerEntDetection = SetupHelper.AddDetectionBehaviour(playerEnt, 5);

			_enemyEntity = SetupHelper.CreateEntity(new Vector3(0, 1, 1), Team.Player, secondEntityType, "Second type");

			yield return null;
		}
		#endregion Methods
	}
}