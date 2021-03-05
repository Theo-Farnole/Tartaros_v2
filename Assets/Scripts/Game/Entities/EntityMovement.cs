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

        public EntityMovementData EntityMovementData
        {
            get => _entityMovementData;

            set
            {
                _entityMovementData = value;
                _navMeshAgent.speed = _entityMovementData.Speed;
            }
        }
        #endregion

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
                DestinationReached?.Invoke(this, new DestinationReachedArgs());
                StopMovement();
            }
        }

        bool CanMoveToPoint(Vector3 point)
        {
            var _navMeshPath = new NavMeshPath();

            _navMeshAgent.CalculatePath(point, _navMeshPath);

            if (_navMeshPath.status == NavMeshPathStatus.PathInvalid || _navMeshPath.status == NavMeshPathStatus.PathPartial)
            {
                return false;
            }
            else
            {
                return true;
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
                
            }
        }
        public void StopMovement()
        {
            _navMeshAgent.isStopped = true;
        }
        #endregion
    }
}