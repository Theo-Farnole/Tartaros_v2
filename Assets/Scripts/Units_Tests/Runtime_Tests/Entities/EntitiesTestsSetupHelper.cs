namespace Tartaros.Tests
{
	using Tartaros.Entities;
	using Tartaros.Entities.Detection;
	using UnityEngine;

	public static class EntitiesTestsSetupHelper
	{
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
