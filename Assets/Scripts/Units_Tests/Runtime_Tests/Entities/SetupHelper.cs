namespace Tartaros.Tests
{
	using Tartaros.Entities;
	using Tartaros.Entities.Detection;
	using Tartaros.ServicesLocator;
	using UnityEngine;

	internal static class SetupHelper
	{
		public static Services CreateService()
		{
			return new GameObject("Services").AddComponent<Services>();
		}

		public static EntitiesKDTrees CreateEntitiesKDTree()
		{
			return new GameObject("Entities KD Tree").AddComponent<EntitiesKDTrees>();
		}

		public static Entity CreateEntity(Vector3 position, Team team, EntityType entityType, string name)
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
	}
}
