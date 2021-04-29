namespace Tartaros.Entities.State
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	
	using Tartaros.Entities;
	using Tartaros.Entities.Attack;

	public class StateAttack : AEntityState
	{
		private readonly IAttackable _target = null;
		private readonly EntityAttack _entityAttack = null;
		private readonly EntityMovement _entityMovement = null;

		public StateAttack(Entity stateOwner, IAttackable target) : base(stateOwner)
		{
			_target = target;

			if (_target == null)
			{
				Debug.LogErrorFormat("The attack target of {0} is null. It is not a expected behaviour.", stateOwner);
			}

			_entityMovement = stateOwner.GetComponent<EntityMovement>();
			_entityAttack = stateOwner.GetComponent<EntityAttack>();
		}

		public override void OnStateExit()
		{
			base.OnStateExit();

			StopMovement();
		}

		public override void OnUpdate()
		{
			Debug.Log("state attack");

			if (IsTargetDead() == true)
			{
				_stateOwner.GetComponent<EntityFSM>().MarkCurrentStateAsFinish();
				Debug.Log("Target dead");
			}
			else
			{
				if (_entityAttack.IsInRange(_target) == true)
				{
					StopMovement();
					_entityAttack.CastAttackIfPossible(_target);
				}
				else
				{
					MoveToTarget();
				}
			}
		}

		private bool IsTargetDead()
		{
			return _target == null || _target.IsAlive == false;
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
	}
}