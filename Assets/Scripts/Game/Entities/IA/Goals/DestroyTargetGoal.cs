namespace Tartaros.Entities
{
	using System.Collections;
	using Tartaros.Entities.Attack;
	using UnityEngine;

	public class DestroyTargetGoal : AGoalEntity
	{
		private IAttackable _target = null;
		private float _timeBeforeTargetFlee = 1;
		private float _currentTimeWithoutTouchTarget = 0;
		private bool _completed = false;

		private EntityMovement _entityMovement = null;
		private EntityAttack _entityAttack = null;

		public DestroyTargetGoal(Entity goalOwner, IAttackable target, float timeBeforeTargetFlee) : base(goalOwner)
		{
			_target = target;

			if(_target == null)
			{
				Debug.LogErrorFormat("The attack target of {0} is null. It is not a expected behaviour.", goalOwner);
			}

			_timeBeforeTargetFlee = timeBeforeTargetFlee;

			_entityAttack = goalOwner.GetComponent<EntityAttack>();
			_entityMovement = goalOwner.GetComponent<EntityMovement>();
		}

		public override bool IsCompleted()
		{
			return _completed;
		}

		public override void OnEnter()
		{
			base.OnEnter();

			StopMovement();
		}

		public override void OnUpdate()
		{
			if (IsTargetDead() == true)
			{
				_completed = true;
			}
			else
			{
				if (_entityAttack.IsInRange(_target) == true)
				{
					StopMovement();
					_entityAttack.CastAttackIfPossible(_target);
					RefreshTimeWithoutReachTarget();
				}
				else
				{
					MoveToTarget();
					IncrementTimeWithoutReachTarget();
				}
			}
		}

		private void IncrementTimeWithoutReachTarget()
		{
			_currentTimeWithoutTouchTarget += Time.deltaTime;

			if(_currentTimeWithoutTouchTarget >= _timeBeforeTargetFlee)
			{
				_completed = true;
			}
		}

		private void RefreshTimeWithoutReachTarget()
		{
			_currentTimeWithoutTouchTarget = 0;
		}

		private void StopMovement()
		{
			if (_entityMovement != null)
			{
				_entityMovement.StopMovement();
			}
		}

		private void MoveToTarget()
		{
			if (_entityMovement != null)
			{
				_entityMovement.MoveToPoint(_target.Transform.position);
			}
		}

		private bool IsTargetDead()
		{
			return _target == null || _target.IsAlive == false;
		}
	}
}