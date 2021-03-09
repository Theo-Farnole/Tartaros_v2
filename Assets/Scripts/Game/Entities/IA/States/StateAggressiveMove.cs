namespace Tartaros.Entities.State
{
	using Tartaros.Entities;
	using UnityEngine;

	public class StateAggressiveMove : AEntityState
	{
		private readonly Vector3 _targetPoint = Vector3.zero;		
		private readonly EntityDetection _entityDetection = null;
		private readonly EntityMovement _entityMovement = null;

		public StateAggressiveMove(Entity stateOwner, Vector3 targetPoint) : base(stateOwner)
		{
			_targetPoint = targetPoint;
			_entityDetection = stateOwner.GetComponent<EntityDetection>();
			_entityMovement = stateOwner.GetComponent<EntityMovement>();
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
		}

		public override void OnUpdate()
		{
			if (_entityDetection.IsNearestEnemyInDetectionRange())
			{
				IAttackable target = _entityDetection.GetNearestAttackableEnemy();
				_stateOwner.GetComponent<EntityFSM>().SetState(new StateAttack(_stateOwner, target));
			}
		}
	}
}