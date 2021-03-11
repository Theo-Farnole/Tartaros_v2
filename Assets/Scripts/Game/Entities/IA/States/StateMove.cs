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

		private void DestinationReached(object sender, EntityMovement.DestinationReachedArgs e)
		{
			Debug.Log("Destination reached");
			_stateOwner.GetComponent<EntityFSM>().MarkCurrentStateAsFinish();
		}

	}
}