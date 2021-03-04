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

        #region Events
        public class DestinationReachedArgs : EventArgs
        {

        }

        public event EventHandler<DestinationReachedArgs> DestinationReached = null;
        #endregion

        #region Methods
        private void Awake()
        {
            _navMeshAgent = GetComponent<NavMeshAgent>();
            
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
            throw new System.NotImplementedException();
        }

        void MoveToPoint(Vector3 point)
        {
            _navMeshAgent.SetDestination(point);
        }
        void StopMovement()
        {
            _navMeshAgent.isStopped = false;
        }
        #endregion
    }
}