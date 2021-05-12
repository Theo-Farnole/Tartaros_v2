namespace Tartaros.Entities.Attack
{
	using UnityEngine;

	public class RangeProjectile : MonoBehaviour
	{
		#region Fields
		private readonly float GRAVITY = Physics.gravity.y;
		private const float THRESHOLD_HIT_DISTANCE = 0.3f;
		private const float THRESHOLD_DELAY_MISS_TARGET = 4;

		[SerializeField]
		private float _speed = 1;

		[SerializeField]
		private float _parabolaHeight = 4;

		private Transform _attacker = null;
		private IAttackable _target = null;
		private int _damage = -1;
		private float _delay = 0;

		private IHitEffect _hitEffect = null;

		private Vector3 _velocity = Vector3.zero;
		private Vector3 _destination = default;
		#endregion Fields

		#region Methods
		public Vector3 Destination => _destination; // _target.Transform.position + Vector3.up*2;
		#endregion Methods

		#region Methods

		private void Update()
		{
			if (_target.IsInterfaceDestroyed() == true)
			{
				Destroy(gameObject);
				return;
			}

			SecurityArrowMiss();

			MoveTowardsTarget();
			IsTargetReach();
		}

		private void SecurityArrowMiss()
		{
			_delay += Time.deltaTime;

			if (_delay >= THRESHOLD_DELAY_MISS_TARGET)
			{
				Destroy(gameObject);
			}
		}

		public void Initialize(Transform attacker, IAttackable target, IHitEffect vfx, int damage)
		{
			_attacker = attacker;
			_target = target;
			_hitEffect = vfx;
			_damage = damage;
			_destination = target.Transform.position;
			_velocity = PhysicsHelper.GetParabolaInitVelocity(transform.position, Destination, GRAVITY, _parabolaHeight);
		}

		private void MoveTowardsTarget()
		{
			float deltaTime = Time.deltaTime * _speed;

			transform.position = PhysicsHelper.GetParabolaNextPosition(transform.position, _velocity, GRAVITY, deltaTime);
			transform.LookAt(PhysicsHelper.GetParabolaNextPosition(transform.position, _velocity, GRAVITY, deltaTime));

			_velocity.y += GRAVITY * deltaTime;
		}

		private void IsTargetReach()
		{
			float distanceFromTarget = Vector3.Distance(transform.position, Destination);

			Debug.DrawLine(transform.position, Destination);

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
			if (_target.IsInterfaceDestroyed() == true)
			{
				Destroy(gameObject);
				return;
			}

			_hitEffect.ExecuteHitEffect(Destination);

			IAttackable attacker = _attacker.GetComponent<IAttackable>();
			_target.TakeDamage(_damage, attacker);
		}
		#endregion Methods
	}
}