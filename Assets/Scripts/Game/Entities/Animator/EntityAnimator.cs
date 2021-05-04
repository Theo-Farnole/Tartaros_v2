namespace Tartaros.Entities
{
	using Tartaros.Entities.Attack;
	using UnityEngine;

	public class EntityAnimator : AEntityBehaviour
	{
		#region Fields
		public static readonly int PARAMETER_IS_MOVING = Animator.StringToHash("isMoving");
		public static readonly int PARAMETER_ATTACK = Animator.StringToHash("attack");
		public static readonly int PARAMETER_DEAD = Animator.StringToHash("isDead");

		private EntityMovement _entityMovement = null;
		private EntityAttack _entityAttack = null;
		private Animator _animator = null;
		#endregion Fields

		#region Methods
		private void Awake()
		{
			_entityMovement = GetComponent<EntityMovement>();
			_entityAttack = GetComponent<EntityAttack>();
			_animator = GetComponent<Animator>();
		}

		private void OnEnable()
		{
			_entityMovement.StartMoving -= StartMoving;
			_entityMovement.StartMoving += StartMoving;

			_entityMovement.StopMoving -= StopMoving;
			_entityMovement.StopMoving += StopMoving;

			_entityAttack.AttackCasted -= AttackCasted;
			_entityAttack.AttackCasted += AttackCasted;

			Entity.EntityKilled -= EntityKilled;
			Entity.EntityKilled += EntityKilled;
		}

		private void OnDisable()
		{
			_entityAttack.AttackCasted -= AttackCasted;
			_entityMovement.StartMoving -= StartMoving;
			_entityMovement.StopMoving -= StopMoving;
			Entity.EntityKilled -= EntityKilled;
		}

		private void EntityKilled(object sender, Wave.KilledArgs e)
		{
			_animator.SetBool(PARAMETER_DEAD, true);
		}

		private void AttackCasted(object sender, EntityAttack.AttackCastedArgs e)
		{
			_animator.SetTrigger(PARAMETER_ATTACK);
		}

		private void StartMoving(object sender, EntityMovement.StartMovingArgs e)
		{
			_animator.SetBool(PARAMETER_IS_MOVING, true);
		}

		private void StopMoving(object sender, EntityMovement.StopMovingArgs e)
		{
			_animator.SetBool(PARAMETER_IS_MOVING, false);
		}
		#endregion Methods
	}
}
