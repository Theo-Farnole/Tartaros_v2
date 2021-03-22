namespace Tartaros.Tests
{
	using NUnit.Framework;
	using System;
	using System.Collections;
	using Tartaros.Economy;
	using Tartaros.Entities;
	using Tartaros.Entities.ResourcesGeneration;
	using Tartaros.ServicesLocator;
	using UnityEditor.SceneManagement;
	using UnityEngine;
	using UnityEngine.SceneManagement;
	using UnityEngine.TestTools;

	public class EntityResourcesGeneration_Tests
	{
		#region Fields
		private const float TICK_DURATION = 0.1f;

		private EntityResourcesGeneration _entityResourcesGeneration = null;
		private IPlayerSectorResources _playerWallet = null;
		#endregion Fields

		#region Methods
		[UnitySetUp]
		public IEnumerator SetUp()
		{
			SetupHelper.CreateService();
			SetupHelper.CreateIncomeManager(SectorResourcesWallet.Zero, TICK_DURATION);
			_playerWallet = SetupHelper.CreatePlayerSectorResources();

			Entity entityResources = SetupHelper.CreateEntity(Vector3.zero, Team.Player, EntityType.Unit, "Resources");
			_entityResourcesGeneration = entityResources.gameObject.AddComponent<EntityResourcesGeneration>();

			LogAssert.ignoreFailingMessages = true;

			yield return new WaitForEndOfFrame();
		}

		[UnityTest]
		public IEnumerator ShouldGenerateFood()
		{
			EntityResourcesGenerationData entityData = new EntityResourcesGenerationData(SectorRessourceType.Food, 1);
			_entityResourcesGeneration.Data = entityData;

			const int TICK_COUNT = 1;
			yield return WaitForTick(TICK_COUNT);

			Assert.AreEqual(entityData.ResourcesPerTick, _playerWallet.GetAmount(entityData.ResourcesType));
			Assert.AreEqual(0, _playerWallet.GetAmount(SectorRessourceType.Iron));
			Assert.AreEqual(0, _playerWallet.GetAmount(SectorRessourceType.Stone));
		}

		[UnityTest]
		public IEnumerator ShouldGenerateIronTwice()
		{
			EntityResourcesGenerationData data = new EntityResourcesGenerationData(SectorRessourceType.Iron, 1);
			_entityResourcesGeneration.Data = data;

			const int TICK_COUNT = 2;
			yield return WaitForTick(TICK_COUNT);

			Assert.AreEqual(data.ResourcesPerTick * TICK_COUNT, _playerWallet.GetAmount(data.ResourcesType));
			Assert.AreEqual(0, _playerWallet.GetAmount(SectorRessourceType.Stone));
			Assert.AreEqual(0, _playerWallet.GetAmount(SectorRessourceType.Food));
		}

		[Test]
		public void ShouldNotHaveTimeToGenerateStone()
		{
			EntityResourcesGenerationData data = new EntityResourcesGenerationData(SectorRessourceType.Stone, 1);
			_entityResourcesGeneration.Data = data;

			Assert.AreEqual(0, _playerWallet.GetAmount(SectorRessourceType.Stone));
			Assert.AreEqual(0, _playerWallet.GetAmount(SectorRessourceType.Iron));
			Assert.AreEqual(0, _playerWallet.GetAmount(SectorRessourceType.Food));
		}

		private IEnumerator WaitForTick(int tickCount)
		{
			for (int i = 1; i <= tickCount; i++)
			{
				yield return new WaitForSeconds(TICK_DURATION);
				yield return new WaitForEndOfFrame();
			}
		}
		#endregion Methods
	}
}
