namespace Tartaros.Entities.State
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Tartaros.Utilities;
    using Tartaros.Entities;

    public class StateMove : AEntityState
    {
        private readonly Vector3 _targetPoint = Vector3.zero;
        private readonly EntityMovement _entityMovement = null;

        public StateMove(Entity stateOwner, Vector3 targetPoint) : base(stateOwner)
        {
            _targetPoint = targetPoint;
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();

            if (_entityMovement.CanMoveToPoint(_targetPoint))
            {
                _entityMovement.MoveToPoint(_targetPoint);
            }
        }

        public override void OnStateExit()
        {
            base.OnStateExit();

            _entityMovement.StopMovement();
        }

        public override void OnUpdate()
        {
            throw new System.NotImplementedException();
        }
    }
}