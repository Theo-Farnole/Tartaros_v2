namespace Tartaros.Entities
{
	using Tartaros.Entities.Attack;
	using Tartaros.Wave;
	using UnityEngine;

	public class EntityAnimator : AEntityBehaviour
	{
		#region Fields
		public static readonly int PARAMETER_IS_MOVING = Animator.StringToHash("isMoving");
		public static readonly int PARAMETER_ATTACK = Animator.StringToHash("attack");
		public static readonly int PARAMETER_IS_ATTACKING = Animator.StringToHash("isAttacking");
		public static readonly int PARAMETER_IS_DEAD = Animator.StringToHash("isDead");
		public static readonly int PARAMETER_IS_CELEBRATING = Animator.StringToHash("celebrate");

		private EntityMovement _entityMovement = null;
		private EntityAttack _entityAttack = null;
		private EnemiesWavesManager _waveManager = null;
		private Animator _animator = null;
		#endregion Fields

		#region Methods
		private void Awake()
		{
			_entityMovement = GetComponent<EntityMovement>();
			_entityAttack = GetComponent<EntityAttack>();
			_animator = GetComponentInChildren<Animator>();
			_waveManager = FindObjectOfType<EnemiesWavesManager>();

		}

		private void OnEnable()
		{
			if (_entityMovement != null)
			{
				_entityMovement.StartMoving -= StartMoving;
				_entityMovement.StartMoving += StartMoving;

				_entityMovement.StopMoving -= StopMoving;
				_entityMovement.StopMoving += StopMoving;

				_waveManager.WaveFinish -= Celebration;
				_waveManager.WaveFinish += Celebration;
			}

			_entityAttack.AttackCasted -= AttackCasted;
			_entityAttack.AttackCasted += AttackCasted;

			Entity.EntityKilled -= EntityKilled;
			Entity.EntityKilled += EntityKilled;

			_entityAttack.StartAttack -= StartAttack;
			_entityAttack.StartAttack += StartAttack;

			_entityAttack.StopAttack -= StopAttack;
			_entityAttack.StopAttack += StopAttack;
		}


		private void OnDisable()
		{
			if (_entityMovement != null)
			{
				_entityMovement.StartMoving -= StartMoving;
				_entityMovement.StopMoving -= StopMoving;
				_waveManager.WaveFinish -= Celebration;
			}
			_entityAttack.AttackCasted -= AttackCasted;
			_entityAttack.StartAttack -= StartAttack;
			_entityAttack.StopAttack -= StopAttack;
			Entity.EntityKilled -= EntityKilled;
		}

		private void Celebration(object sender, EnemiesWavesManager.WaveIsFinishArgs e)
		{
			_animator.SetTrigger(PARAMETER_IS_CELEBRATING);
		}
		private void StopAttack(object sender, EntityAttack.StopAttackArgs e)
		{
			_animator.SetBool(PARAMETER_IS_ATTACKING, false);
		}

		private void StartAttack(object sender, EntityAttack.StartAttackArgs e)
		{
			_animator.SetBool(PARAMETER_IS_ATTACKING, true);
		}

		private void EntityKilled(object sender, Wave.KilledArgs e)
		{
			_animator.SetBool(PARAMETER_IS_DEAD, true);
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
