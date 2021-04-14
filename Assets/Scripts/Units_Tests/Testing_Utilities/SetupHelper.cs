namespace Tartaros.Tests
{
	using Tartaros.Economy;
	using Tartaros.Entities;
	using Tartaros.Entities.Attack;
	using Tartaros.Entities.Detection;
	using Tartaros.ServicesLocator;
	using UnityEngine;

	public static class SetupHelper
	{
		public static Services CreateService()
		{
			return new GameObject("Services").AddComponent<Services>();
		}

		public static EntitiesDetector CreateEntitiesKDTree()
		{
			return new GameObject("Entities KD Tree").AddComponent<EntitiesDetector>();
		}

		public static PlayerSectorResources CreatePlayerSectorResources()
		{
			return new GameObject("Player Sector Resources").AddComponent<PlayerSectorResources>();
		}

		public static PlayerIncomeManager CreateIncomeManager(ISectorResourcesWallet wallet, float tickInvervalInSeconds)
		{
			PlayerIncomeManager playerIncomeManager = new GameObject("Income Manager").AddComponent<PlayerIncomeManager>();

			playerIncomeManager.Data = new PlayerIncomeManagerData(wallet, tickInvervalInSeconds);

			return playerIncomeManager;
		}

		public static Entity CreateEntity(Vector3 position, Team team, EntityType entityType, string name = "Entity")
		{
			GameObject entityObject = new GameObject(name);
			entityObject.transform.position = position;

			Entity entity = entityObject.AddComponent<Entity>();
			entity.Initialize(team, entityType);

			return entity;
		}

		public static EntityDetection AddDetectionBehaviour(Entity entity, float detectionRange)
		{
			EntityDetection entityDetection = entity.gameObject.AddComponent<EntityDetection>();
			entityDetection.EntityDetectionData = new EntityDetectionData(detectionRange);

			return entityDetection;
		}

		public static EntityAttack AddAttackBehaviour(Entity entity, float attackRange)
		{
			EntityAttack entityAttack = entity.gameObject.AddComponent<EntityAttack>();
			entityAttack.EntityAttackData = new EntityAttackData(0, 0, attackRange, null, null);

			return entityAttack;
		}
	}
}
