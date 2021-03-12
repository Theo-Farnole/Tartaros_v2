namespace Tartaros.Entities
{
	using System;
	using Tartaros.Utilities;
	using UnityEngine;
	using Tartaros.OrderGiver;
	using Tartaros.Entities.Movement;
	using Tartaros.Entities.State;
	using Sirenix.OdinInspector;

	public class Entity : MonoBehaviour, IOrderAttackReceiver, IOrderMoveAggresivellyReceiver, IOrderMoveReceiver, IOrderPatrolReceiver, IOrderStopReceiver
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
		void IOrderAttackReceiver.Attack(IAttackable target)
		{
			_entityFSM.SetState(new StateAttack(this, target));
		}

		void IOrderAttackReceiver.AttackAdditive(IAttackable target)
		{
			_entityFSM.EnqueueState(new StateAttack(this, target));
		}

		void IOrderMoveAggresivellyReceiver.MoveAggressively(Vector3 position)
		{
			_entityFSM.SetState(new StateAggressiveMove(this, position));
		}

		void IOrderMoveAggresivellyReceiver.MoveAggressivelyAdditive(Vector3 position)
		{
			_entityFSM.EnqueueState(new StateAggressiveMove(this, position));
		}

		void IOrderMoveReceiver.Move(Vector3 position)
		{
			_entityFSM.SetState(new StateMove(this, position));
		}

		void IOrderMoveReceiver.Move(Transform toFollow)
		{
			_entityFSM.SetState(new StateFollow(this, toFollow));
		}

		void IOrderMoveReceiver.MoveAdditive(Vector3 position)
		{
			_entityFSM.EnqueueState(new StateMove(this, position));
		}

		void IOrderMoveReceiver.MoveAdditive(Transform target)
		{
			_entityFSM.EnqueueState(new StateFollow(this, target));
		}

		void IOrderPatrolReceiver.Patrol(PatrolPoints waypoints)
		{
			_entityFSM.SetState(new StatePatrol(this, waypoints));
		}

		void IOrderPatrolReceiver.PatrolAdditive(PatrolPoints waypoints)
		{
			_entityFSM.EnqueueState(new StatePatrol(this, waypoints));
		}

		void IOrderStopReceiver.Stop()
		{
			_entityFSM.Stop();
		}
		#endregion IOrders
		#endregion Methods
	}
}