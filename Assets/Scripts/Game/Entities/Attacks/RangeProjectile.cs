namespace Tartaros.Entities.Attack
{
	using UnityEngine;

	public class RangeProjectile : MonoBehaviour
	{
		#region Fields
		private const float THRESHOLD_HIT_DISTANCE = 0.3f;

		private float _speed = 1;

		[SerializeField]
		private float _parabolaHeight = 3;

		private Transform _attacker = null;
		private IAttackable _target = null;
		private int _damage = -1;

		private IHitEffect _hitEffect = null;

		private Vector3 _velocity = Vector3.zero;
		private readonly float GRAVITY = Physics.gravity.y;
		private float _currentLifetime = 0;
		#endregion Fields

		public Vector3 Destination => _target.Transform.position;

		private void Update()
		{
			if (_target.IsInterfaceDestroyed() == true)
			{
				Destroy(gameObject);
				return;
			}

			MoveTowardsTarget();
			IsTargetReach();

			_currentLifetime += Time.deltaTime;
			_velocity.y += GRAVITY * Time.deltaTime;
		}

		public void Initialize(Transform attacker, IAttackable target, IHitEffect vfx, int damage)
		{
			_attacker = attacker;
			_target = target;
			_hitEffect = vfx;
			_damage = damage;

			_velocity = PhysicsHelper.GetParabolaInitVelocity(transform.position, Destination, GRAVITY, _parabolaHeight, 0);
		}

		private void MoveTowardsTarget()
		{
			float deltaTime = Time.deltaTime * _speed;
			transform.position = PhysicsHelper.GetParabolaNextPosition(transform.position, _velocity, GRAVITY, deltaTime);
			transform.LookAt(PhysicsHelper.GetParabolaNextPosition(transform.position, _velocity, GRAVITY, deltaTime));
		}

		private void IsTargetReach()
		{
			float distanceFromTarget = Vector3.Distance(transform.position, Destination);

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

			_target.TakeDamage(_damage);
		}
	}
}