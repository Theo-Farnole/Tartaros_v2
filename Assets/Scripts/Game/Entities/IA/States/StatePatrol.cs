namespace Tartaros.Entities.State
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using Tartaros.Utilities;
	using Tartaros.Entities;
    using System;

    public class StatePatrol : AEntityState
	{
		private readonly Vector3[] _targetPoints;
		private readonly EntityMovement _entityMovement = null;
		private int _currentIndex = 0;
		private int _maxIndex = 0;

		public StatePatrol(Entity stateOwner, Vector3[] targetPoints) : base(stateOwner)
		{
			_targetPoints = targetPoints;
			_entityMovement = stateOwner.GetComponent<EntityMovement>();
		}

        public override void OnStateEnter()
        {
            base.OnStateEnter();

			MoveToTargetPoint(0);

			_entityMovement.DestinationReached -= DestinationReached;
			_entityMovement.DestinationReached += DestinationReached;
		}

        public override void OnUpdate()
		{

			throw new System.NotImplementedException();
		}

		private void MoveToTargetPoint(int index)
        {
			if (_entityMovement.CanMoveToPoint(_targetPoints[index]))
			{
				_maxIndex = _targetPoints.Length;
				_entityMovement.MoveToPoint(_targetPoints[index]);
			}
		}

		private void ChangeTargetPoint()
        {
			if(_currentIndex < _maxIndex)
            {
				_currentIndex++;
            }
            else
            {
				_currentIndex = 0;
            }

			MoveToTargetPoint(_currentIndex);
		}



        private void DestinationReached(object sender, EntityMovement.DestinationReachedArgs e)
        {
			ChangeTargetPoint();
        }

	}
}