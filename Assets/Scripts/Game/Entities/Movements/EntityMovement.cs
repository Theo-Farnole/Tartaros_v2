namespace Tartaros.Entities
{
	using System;
	using System.Collections.Generic;
	using Tartaros.Entities.Movement;
	using Tartaros.Entities.State;
	using Tartaros.OrderGiver;
	using Tartaros.Orders;
	using UnityEngine;
	using UnityEngine.AI;

	[RequireComponent(typeof(SteeringBehaviourAgent), typeof(EntityFSM))]
	public class EntityMovement : AEntityBehaviour, IOrderMoveAggresivellyReceiver, IOrderMoveReceiver, IOrderPatrolReceiver, IOrderable
	{
		#region Fields
		private EntityMovementData _entityMovementData = null;
		private SteeringBehaviourAgent _steeringBehaviourAgent = null;
		private EntityFSM _entityFSM = null;
		#endregion

		#region Properties
		public EntityMovementData EntityMovementData
		{
			get => _entityMovementData;

			set
			{
				_entityMovementData = value;
				_steeringBehaviourAgent.MaxSpeed = _entityMovementData.Speed;
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
			DestroyObsoleteComponents();

			_steeringBehaviourAgent = gameObject.GetOrAddComponent<SteeringBehaviourAgent>();
			_entityFSM = GetComponent<EntityFSM>();

			EntityMovementData = Entity.GetBehaviourData<EntityMovementData>();

			//NavMesh.avoidancePredictionTime = Mathf.Infinity; // overclock the nav mesh calculator
		}

		private void DestroyObsoleteComponents()
		{
			if (gameObject.TryGetComponent(out NavMeshAgent agent))
			{
				Destroy(agent);
			}
		}

		private void Update()
		{
			if (_steeringBehaviourAgent.IsStopped == false && _steeringBehaviourAgent.DestinationReached() == true)
			{
				StopMovement();
				DestinationReached?.Invoke(this, new DestinationReachedArgs());
			}
		}

		public bool CanMoveToPoint(Vector3 point)
		{
			point = NavMeshHelper.AdjustPositionToFitNavMesh(point);

			NavMeshPath navMeshPath = _steeringBehaviourAgent.CalculatePath(point);

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
				_steeringBehaviourAgent.Destination = point.GetVector2FromXZ();
			}
			else
			{
				Debug.LogErrorFormat("Entity {0} can't move to {1}.", name, point);
			}
		}

		public void StopMovement()
		{
			_steeringBehaviourAgent.Stop();			
		}

		#region IOrder
		void IOrderMoveAggresivellyReceiver.MoveAggressively(Vector3 position)
		{
			_entityFSM.OrderMoveAggressively(position);
		}

		void IOrderMoveAggresivellyReceiver.MoveAggressivelyAdditive(Vector3 position)
		{
			_entityFSM.EnqueueOrderMoveAggressively(position);
		}

		void IOrderMoveReceiver.Move(Vector3 position)
		{
			_entityFSM.OrderMove(position);
		}

		void IOrderMoveReceiver.Follow(Transform toFollow)
		{
			_entityFSM.OrderFollow(toFollow);
		}

		void IOrderMoveReceiver.EnqueueMove(Vector3 position)
		{
			_entityFSM.EnqueueOrderMove(position);
		}

		void IOrderMoveReceiver.EnqueueFollow(Transform target)
		{
			_entityFSM.EnqueueOrderFollow(target);
		}

		void IOrderPatrolReceiver.Patrol(PatrolPoints waypoints)
		{
			_entityFSM.OrderPatrol(waypoints);
		}

		void IOrderPatrolReceiver.EnqueuePatrol(PatrolPoints waypoints)
		{
			_entityFSM.OrderPatrol(waypoints);
		}

		public Order[] GenerateOrders()
		{
			List<Order> orders = new List<Order>();

			orders.Add(new MoveOrder(this));
			orders.Add(new MoveAgressivelyOrder(this));
			orders.Add(new PatrolOrder(this));
			return orders.ToArray();
		}
		#endregion
		#endregion
	}
}