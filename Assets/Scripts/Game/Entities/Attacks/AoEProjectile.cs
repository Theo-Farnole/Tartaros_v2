namespace Tartaros.Entities.Attacks
{
	using System.Collections;
	using System.Collections.Generic;
	using Tartaros.Entities.Attack;
	using Tartaros.Entities.Detection;
	using Tartaros.ServicesLocator;
	using UnityEngine;

	public class AoEProjectile : MonoBehaviour
	{
		private readonly float GRAVITY = Physics.gravity.y;
		
		private const float THRESHOLD_HIT_DISTANCE = 0.7f;
		private const float THRESHOLD_DELAY_MISS_TARGET = 4;

		[SerializeField]
		private float _parabolaHeight = 5;
		[SerializeField]
		private float _speed = 1;
		[SerializeField]
		private GameObject _projectileMesh = null;

		private GameObject _projectile = null;
		private Vector3 _velocity = Vector3.zero;
		private Vector3 _targetPosition = Vector3.zero;
		private Vector3 _destination = default;

		public Vector3 Destination => _destination;

		private float _radiusDamage = 1;
		private EntitiesDetectorManager _detector = null;

		private IHitEffect _hitEffect = null;
		private bool _projectileIsMaxHeight = false;

		private void Update()
		{
			MoveTowardsTarget();
			IsTargetReach();
		}

		public void Initialize(IAttackable target, IHitEffect vfx, int damage, float radiusDamage)
		{
			if(target == null || target.Transform == null)
			{
				Destroy(gameObject);
				return;
			}
			_projectile = gameObject;
			_hitEffect = vfx;

			_targetPosition = target.Transform.position;
			_destination = target.Transform.position;
			_radiusDamage = radiusDamage;
			_detector = Services.Instance.Get<EntitiesDetectorManager>();
			_velocity = PhysicsHelper.GetParabolaInitVelocity(transform.position, Destination, GRAVITY, _parabolaHeight);
		}

		private void MoveTowardsTarget()
		{
			float deltaTime = Time.deltaTime * _speed;

			transform.position = PhysicsHelper.GetParabolaNextPosition(transform.position, _velocity, GRAVITY, deltaTime);
			transform.LookAt(PhysicsHelper.GetParabolaNextPosition(transform.position, _velocity, GRAVITY, deltaTime));

			_velocity.y += GRAVITY * deltaTime;

			if(_projectileIsMaxHeight == false && _velocity.y <= -3f)
			{
				_hitEffect.ExecuteHitEffect(transform.position, transform.rotation);
				_projectileMesh.SetActive(false);
				_projectileIsMaxHeight = true;
			}
		}

		private void IsTargetReach()
		{
			float distanceFromTarget = Vector3.Distance(_projectile.transform.position, _targetPosition);

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
			//_hitEffect.ExecuteHitEffect(_targetPosition);

			var Entities = _detector.GetEveryEntityInRadius(Team.Enemy, _targetPosition, _radiusDamage);

			foreach (var target in Entities)
			{
				target.Kill(); 
			}

		}
	}
}