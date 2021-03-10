namespace Tartaros.Entities
{
	using System;
	using Tartaros.Utilities;
	using UnityEngine;

	public class Entity : MonoBehaviour
	{
		#region Fields
		[SerializeField]
		private EntityData _entityData = null;

		private Team _team = Team.Player;
		private EntityType _entityType = EntityType.Unit;
		#endregion Fields

		#region Properties
		public Team Team => _team;
		public EntityType entityType => _entityType;
		#endregion Properties

		#region Events
		public class EntitySpawnedArgs : EventArgs
		{
			public readonly Entity entity = null;

			public EntitySpawnedArgs(Entity entity)
			{
				this.entity = entity;
			}
		}

		public static event EventHandler<EntitySpawnedArgs> EntitySpawned = null;

		public class EntityKilledArgs : EventArgs
		{
			public readonly Entity entity = null;

			public EntityKilledArgs(Entity entity)
			{
				this.entity = entity;
			}
		}

		public static event EventHandler<EntityKilledArgs> EntityKilled = null;
		#endregion Events

		#region Methods
		private void Start()
		{
			GenerateRequiredComponents();

			EntitySpawned?.Invoke(this, new EntitySpawnedArgs(this));
		}

		public void Kill()
		{
			EntityKilled?.Invoke(this, new EntityKilledArgs(this));

			Destroy(gameObject);
		}

		public void Initialize(Team team, EntityType entityType)
		{
			_team = team;
			_entityType = entityType;
		}

		void GenerateRequiredComponents()
		{
			foreach (IEntityBehaviourData behaviour in _entityData.Behaviours)
			{
				behaviour.SpawnRequiredComponents(gameObject);
			}
		}
		#endregion Methods
	}
}