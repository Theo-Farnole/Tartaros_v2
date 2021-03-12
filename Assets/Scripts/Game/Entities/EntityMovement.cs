namespace Tartaros.Entities
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using Tartaros.Entities;
	using UnityEngine.AI;
	using System;

	public class EntityMovement : MonoBehaviour
	{
		#region Fields
		private EntityMovementData _entityMovementData = null;
		private NavMeshAgent _navMeshAgent = null;
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
			
			return navMeshPath.status == NavMeshPathStatus.PathComplete;
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
		#endregion
	}
}