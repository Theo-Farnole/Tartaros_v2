namespace Tartaros.Entities.State
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using Tartaros.Utilities;
	using Tartaros.Entities;
	using Tartaros.Entities.Attack;

	public class StateAggressiveMove : AEntityState
	{
		private readonly Vector3 _targetPoint = Vector3.zero;
		private readonly EntityAttack _entityAttack = null;
		private readonly EntityDetection _entityDetection = null;
		private readonly EntityMovement _entityMovement = null; 

		public StateAggressiveMove(Entity stateOwner, Vector3 targetPoint) : base(stateOwner)
		{
			_targetPoint = targetPoint;
		}

		public override void OnStateEnter()
		{
			base.OnStateEnter();

			_entityMovement.MoveToPoint(_targetPoint);
		}

        public override void OnStateExit()
        {
            base.OnStateExit();

			_entityMovement.StopMovement();

			var nearest = _entityDetection.GetNearest(SearchQuary.Enemy | SearchQuary.Unit | SearchQuary.Building);
			IAttackable target = nearest.GetComponent<IAttackable>();
			_stateOwner.GetComponent<EntityFSM>().SetState(new StateAttack(_stateOwner, target));
        }

        public override void OnUpdate()
		{
            if (_entityDetection.IsNearestIsInDetectionRange())
            {
				OnStateExit();
            }
            throw new System.NotImplementedException();
        }
	}
}