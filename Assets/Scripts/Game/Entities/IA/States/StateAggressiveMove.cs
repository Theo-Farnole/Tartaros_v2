namespace Tartaros.Entities.State
{
	using Tartaros.Entities;
	using Tartaros.Entities.Detection;
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

			_entityMovement.DestinationReached -= DestinationReached;
			_entityMovement.DestinationReached += DestinationReached;
		}

		public override void OnStateExit()
		{
			base.OnStateExit();

			_entityMovement.StopMovement();
			_entityMovement.DestinationReached -= DestinationReached;
		}

		public override void OnUpdate()
		{
			if (_entityDetection.IsNearestOpponentInDetectionRange())
			{
				IAttackable target = _entityDetection.GetNearestAttackableOpponent();
				_stateOwner.GetComponent<EntityFSM>().OrderAttack(target);
			}
		}

		private void DestinationReached(object sender, EntityMovement.DestinationReachedArgs e)
		{
			_stateOwner.GetComponent<EntityFSM>().MarkCurrentStateAsFinish();
		}
	}
}