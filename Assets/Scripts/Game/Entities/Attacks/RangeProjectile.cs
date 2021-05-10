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
		private float _speed = 1;
		private GameObject _projectile = null;
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
			_projectile = gameObject;
			_attacker = attacker;
			_target = target;
			_hitEffect = vfx;
			_damage = damage;
		}

		private void MoveTowardsTarget()
		{
			// Compute the next position, with arc added in
			float x0 = _startingPosition.x;
			float x1 = Destination.x;
			float dist = x1 - x0;
			float nextX = Mathf.MoveTowards(transform.position.x, x1, _speed * Time.deltaTime);
			float baseY = Mathf.Lerp(_startingPosition.y, Destination.y, (nextX - x0) / dist);
			float arc = _parabolaHeight * (nextX - x0) * (nextX - x1) / (-0.25f * dist * dist);
			Vector3 nextPos = new Vector3(nextX, baseY + arc, transform.position.z);

			//// Rotate to face the next position, and then move there
			//transform.rotation = LookAt2D(nextPos - transform.position);
			//transform.position = nextPos;

			//float deltaTime = Time.deltaTime * _speed;
			//transform.position = PhysicsHelper.GetParabolaNextPosition(transform.position, _velocity, GRAVITY, deltaTime);
			transform.LookAt(transform.position - nextPos);
			transform.position = nextPos;
		}

		private void IsTargetReach()
		{
			float distanceFromTarget = Vector3.Distance(_projectile.transform.position, _target.Transform.position);

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