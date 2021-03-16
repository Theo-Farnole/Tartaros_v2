namespace Tartaros.Entities.State
{
	using Tartaros.Entities;
	using Tartaros.Entities.Movement;

	public partial class StatePatrol : AEntityState
	{
		private readonly PatrolPoints _patrolPoints = null;
		private readonly EntityMovement _entityMovement = null;
		private int _currentIndex = 0;
		private int _maxIndex = 0;

		public StatePatrol(Entity stateOwner, PatrolPoints patrolPoints) : base(stateOwner)
		{
			_patrolPoints = patrolPoints;
			_entityMovement = stateOwner.GetComponent<EntityMovement>();
		}

		public override void OnStateEnter()
		{
			base.OnStateEnter();

			MoveToTargetPoint(0);

			_entityMovement.DestinationReached -= DestinationReached;
			_entityMovement.DestinationReached += DestinationReached;
		}

		public override void OnStateExit()
		{
			base.OnStateExit();

			_entityMovement.DestinationReached -= DestinationReached;
			_entityMovement.StopMovement();
		}

		private void MoveToTargetPoint(int index)
		{
			if (_entityMovement.CanMoveToPoint(_patrolPoints[index]))
			{
				_maxIndex = _patrolPoints.WaypointsCount;
				_entityMovement.MoveToPoint(_patrolPoints[index]);
			}
		}

		private void SetTargetPointToNext()
		{
			if (_currentIndex < _maxIndex)
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
			SetTargetPointToNext();
		}
	}
}