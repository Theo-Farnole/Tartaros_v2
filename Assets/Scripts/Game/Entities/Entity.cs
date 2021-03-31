namespace Tartaros.Entities
{
	using System;
	using System.Linq;
	using Tartaros.Entities.State;
	using Tartaros.OrderGiver;
	using Tartaros.Orders;
	using Tartaros.Wave;
	using UnityEngine;

	public class Entity : MonoBehaviour, ITeamable, IOrderStopReceiver, IWaveSpawnable
	{
		#region Fields
		[SerializeField]
		private EntityData _entityData = null;

		private Team _team = Team.Player;
		private EntityType _entityType = EntityType.Unit;

		private EntityFSM _entityFSM = null;
		#endregion Fields

		#region Properties
		public EntityData EntityData => _entityData;
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

		public static event EventHandler<EntitySpawnedArgs> AnyEntitySpawned = null;

		public class EntityKilledArgs : EventArgs
		{
			public readonly Entity entity = null;

			public EntityKilledArgs(Entity entity)
			{
				this.entity = entity;
			}
		}

		public static event EventHandler<EntityKilledArgs> AnyEntityKilled = null;

		event EventHandler<KilledArgs> EntityKilled = null;
		event EventHandler<KilledArgs> IWaveSpawnable.Killed { add => EntityKilled += value; remove => EntityKilled -= value; }
		#endregion Events

		#region Methods
		private void Start()
		{
			GenerateRequiredComponents();

			AnyEntitySpawned?.Invoke(this, new EntitySpawnedArgs(this));
		}

		private void OnDestroy()
		{
			EntityKilled?.Invoke(this, new KilledArgs());
			AnyEntityKilled?.Invoke(this, new EntityKilledArgs(this));
		}

		public void Kill()
		{
			Destroy(gameObject);
		}

		public void Initialize(Team team, EntityType entityType)
		{
			_team = team;
			_entityType = entityType;
		}

		public Order[] GenerateAvailablesOrders()
		{
			return GetComponents<IEntityOrderable>()
				.SelectMany(x => x.GenerateOrders(this))
				.ToArray();
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

		void IWaveSpawnable.Attack(IAttackable attackable)
		{
			GetComponent<IOrderAttackReceiver>().Attack(attackable);
		}
		#endregion IOrders
		#endregion Methods
	}
}