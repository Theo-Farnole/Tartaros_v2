namespace Tartaros.Entities
{
	using System;
	using Tartaros.Entities.State;
	using Tartaros.OrderGiver;
	using UnityEngine;

	public class Entity : MonoBehaviour, ITeamable, IOrderStopReceiver
	{
		#region Fields
		[SerializeField]
		private EntityData _entityData = null;

		private Team _team = Team.Player;
		private EntityType _entityType = EntityType.Unit;

		private EntityFSM _entityFSM = null;
		#endregion Fields

		#region Properties
		public Team Team => _team;
		public EntityType EntityType => _entityType;
		Team ITeamable.Team => _team;
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
			_entityFSM = gameObject.AddComponent<EntityFSM>();

			if (_entityData == null)
			{
				Debug.LogErrorFormat("Missing entity data in \"{0}\". Aborting components generation.", name);
				return;
			}

			foreach (IEntityBehaviourData behaviour in _entityData.Behaviours)
			{
				behaviour.SpawnRequiredComponents(gameObject);
			}
		}

		#region IOrders
		void IOrderStopReceiver.Stop()
		{
			_entityFSM.Stop();
		}
		#endregion IOrders
		#endregion Methods
	}
}