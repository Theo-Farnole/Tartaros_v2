namespace Tartaros.Entities.State
{
	using Tartaros.Entities;
	using UnityEngine;

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
		{ }

		private void DestinationReached(object sender, EntityMovement.DestinationReachedArgs e)
		{
			_stateOwner.GetComponent<EntityFSM>().MarkCurrentStateAsFinish();
		}

	}
}