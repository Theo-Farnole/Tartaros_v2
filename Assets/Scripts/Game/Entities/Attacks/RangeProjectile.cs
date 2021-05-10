namespace Tartaros.Entities.Attack
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class RangeProjectile : MonoBehaviour
	{
		#region Fields
		private readonly float GRAVITY = Physics.gravity.y;
		private const float THRESHOLD_HIT_DISTANCE = 0.3f;

		[SerializeField]
		private float _speed = 1;

		[SerializeField]
		private float _parabolaHeight = 4;

		private Transform _attacker = null;
		private IAttackable _target = null;
		private int _damage = -1;

		private IHitEffect _hitEffect = null;

		private Vector3 _startingPosition = Vector3.zero;
		private Vector3 _velocity = Vector3.zero;
		#endregion Fields

		#region Methods
		public Vector3 Destination => _target.Transform.position;
		#endregion Methods

		#region Methods
		private void Start()
		{
			_startingPosition = transform.position;

			_velocity = PhysicsHelper.GetParabolaInitVelocity(transform.position, Destination, GRAVITY, _parabolaHeight);
		}

		private void Update()
		{
			if (_target.IsInterfaceDestroyed() == true)
			{
				Destroy(gameObject);
				return;
			}

			MoveTowardsTarget();
			IsTargetReach();

			_velocity.y += GRAVITY * Time.deltaTime;
		}

		public void Initialize(Transform attacker, IAttackable target, IHitEffect vfx, int damage)
		{
			_attacker = attacker;
			_target = target;
			_hitEffect = vfx;
			_damage = damage;
		}

		private void MoveTowardsTarget()
		{
			transform.position = PhysicsHelper.GetParabolaNextPosition(transform.position, _velocity, GRAVITY, Time.deltaTime);
			transform.LookAt(PhysicsHelper.GetParabolaNextPosition(transform.position, _velocity, GRAVITY, Time.deltaTime));
		}

		private void IsTargetReach()
		{
			float distanceFromTarget = Vector3.Distance(transform.position, _target.Transform.position);

			if (distanceFromTarget <= THRESHOLD_HIT_DISTANCE)
			{
				OnTargetReach();
			}
		}

		private void OnTargetReach()
		{
			InflictDamageToTarget();

			Destroy(gameObject);
		}

		private void InflictDamageToTarget()
		{
			_hitEffect.ExecuteHitEffect(_target.Transform.position);

			IAttackable attacker = _attacker.GetComponent<IAttackable>();
			_target.TakeDamage(_damage, attacker);
		}
		#endregion Methods
	}
}