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

	[DisallowMultipleComponent]
	[RequireComponent(typeof(NavMeshAgent), typeof(EntityFSM))]
	public class EntityMovement : AEntityBehaviour, IOrderMoveAggresivellyReceiver, IOrderMoveReceiver, IOrderPatrolReceiver, IOrderable
	{
		#region Fields
		private EntityMovementData _entityMovementData = null;
		private NavMeshAgent _navMeshAgent = null;
		private EntityFSM _entityFSM = null;
		private int _navMeshArea = -1;
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

		public int NavMeshArea 
		{
			get => _navMeshAgent.areaMask = _navMeshArea;
			set
			{
				SetAreaMask(value);
			}
		}

		private void SetAreaMask(int value)
		{
			int mask = 0;
			mask += 1 << NavMesh.GetAreaFromName("Walkable");
			mask += 0 << NavMesh.GetAreaFromName("Not walkable");
			mask += 1 << NavMesh.GetAreaFromName("Jump");
			mask += 1 << value;

			_navMeshAgent.areaMask = mask;
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
			_navMeshAgent = gameObject.GetOrAddComponent<NavMeshAgent>();
			_entityFSM = GetComponent<EntityFSM>();

			EntityMovementData = Entity.GetBehaviourData<EntityMovementData>();
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
			return NavMeshHelper.IsNavPathComplete(_navMeshAgent, point);
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