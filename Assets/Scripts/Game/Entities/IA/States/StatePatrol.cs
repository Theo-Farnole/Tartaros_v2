namespace Tartaros.Entities.State
{
	using Tartaros.Entities;
	using Tartaros.Entities.Attack;
	using Tartaros.Entities.Detection;
	using Tartaros.Entities.Movement;
	using UnityEngine;

	public partial class StatePatrol : AEntityState
	{
		private readonly PatrolPoints _patrolPoints = null;
		private readonly EntityMovement _entityMovement = null;
		private readonly EntityAttack _entityAttack = null;
		private int _currentIndex = 0;
		private int _maxIndex = 0;

		private bool CanTryAttackNearest => _entityAttack != null;

		public StatePatrol(Entity stateOwner, PatrolPoints patrolPoints) : base(stateOwner)
		{
			_patrolPoints = patrolPoints;
			_entityMovement = stateOwner.GetComponent<EntityMovement>();
			_entityAttack = stateOwner.GetComponent<EntityAttack>();
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
			base.OnUpdate();

			if (CanTryAttackNearest == true)
			{
				_entityAttack.TryOrderAttackNearestOpponent();
			}
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
			if (_currentIndex < _maxIndex - 1)
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