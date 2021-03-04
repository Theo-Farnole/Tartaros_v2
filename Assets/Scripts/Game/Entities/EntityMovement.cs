namespace Tartaros.Entities
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Tartaros.Entities;
    using System;

    public class EntityMovement : MonoBehaviour
    {

        #region Fields
        private EntityMovementData _entityMovementData = null;

        private Vector3 _destination = Vector3.zero;
        #endregion

        #region Events
        public class DestinationReachedArgs : EventArgs
        {

        }

        public event EventHandler<DestinationReachedArgs> DestinationReached = null;
        #endregion

        #region Methods
        private void Update()
        {
            
        }

        bool CanMoveToPoint(Vector3 point)
        {
            throw new System.NotImplementedException();
        }

        void MoveToPoint(Vector3 point)
        {
            throw new System.NotImplementedException();
        }
        void StopMovement()
        {
            throw new System.NotImplementedException();
        } 
        #endregion
    }
}