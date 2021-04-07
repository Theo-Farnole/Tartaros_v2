namespace Tartaros.Entities
{
	using System;
	using Tartaros.Entities.Movement;
	using Tartaros.Entities.State;
	using Tartaros.OrderGiver;
	using UnityEngine;
	using UnityEngine.AI;

	public class EntityMovement : MonoBehaviour, IOrderMoveAggresivellyReceiver, IOrderMoveReceiver, IOrderPatrolReceiver
	{
		#region Fields
		private EntityMovementData _entityMovementData = null;
		private NavMeshAgent _navMeshAgent = null;
		private Entity _entity = null;
		private EntityFSM _entityFSM = null;
		#endregion

		#region Properties
		public EntityMovementData EntityMovementData
		{
			get => _entityMovementData;

			set
			{
				_entityMovementData = value;
				_navMeshAgent.speed = _entityMovementData.Speed;
			}
		}
		#endregion Properties

		#region Events
		public class DestinationReachedArgs : EventArgs
		{

		}

		public event EventHandler<DestinationReachedArgs> DestinationReached = null;
		#endregion

		#region Methods
		private void Awake()
		{
			_navMeshAgent = gameObject.AddComponent<NavMeshAgent>();
			_entity = GetComponent<Entity>();
			_entityFSM = GetComponent<EntityFSM>();

			//NavMesh.avoidancePredictionTime = Mathf.Infinity; // overclock the nav mesh calculator
		}

		private void Update()
		{
			if (_navMeshAgent.isStopped == false && _navMeshAgent.HasReachedDestination() == true)
			{
				StopMovement();
				DestinationReached?.Invoke(this, new DestinationReachedArgs());
			}
		}

		public bool CanMoveToPoint(Vector3 point)
		{
			var navMeshPath = new NavMeshPath();

			_navMeshAgent.CalculatePath(point, navMeshPath);			
		
			if (navMeshPath.status == NavMeshPathStatus.PathComplete)
			{
				return true;
			}
			else
			{
				Debug.LogErrorFormat("Cannot move to point {0}.", navMeshPath.status);

				return false;
			}
		}

		public void MoveToPoint(Vector3 point)
		{
			if (CanMoveToPoint(point))
			{
				_navMeshAgent.isStopped = false;
				_navMeshAgent.SetDestination(point);
			}
			else
			{
				Debug.LogErrorFormat("Entity {0} can't move to {1}.", name, point);
			}
		}

		public void StopMovement()
		{
			_navMeshAgent.isStopped = true;
		}

		#region IOrder
		void IOrderMoveAggresivellyReceiver.MoveAggressively(Vector3 position)
		{
			_entityFSM.SetState(new StateAggressiveMove(_entity, position));
		}

		void IOrderMoveAggresivellyReceiver.MoveAggressivelyAdditive(Vector3 position)
		{
			_entityFSM.EnqueueState(new StateAggressiveMove(_entity, position));
		}

		void IOrderMoveReceiver.Move(Vector3 position)
		{
			_entityFSM.SetState(new StateMove(_entity, position));
		}

		void IOrderMoveReceiver.Move(Transform toFollow)
		{
			_entityFSM.SetState(new StateFollow(_entity, toFollow));
		}

		void IOrderMoveReceiver.MoveAdditive(Vector3 position)
		{
			_entityFSM.EnqueueState(new StateMove(_entity, position));
		}

		void IOrderMoveReceiver.MoveAdditive(Transform target)
		{
			_entityFSM.EnqueueState(new StateFollow(_entity, target));
		}

		void IOrderPatrolReceiver.Patrol(PatrolPoints waypoints)
		{
			_entityFSM.SetState(new StatePatrol(_entity, waypoints));
		}

		void IOrderPatrolReceiver.PatrolAdditive(PatrolPoints waypoints)
		{
			_entityFSM.EnqueueState(new StatePatrol(_entity, waypoints));
		}
		#endregion
		#endregion
	}
}