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
		private const float THRESHOLD_HIT_DISTANCE = 0.3f;


		[SerializeField]
		private float _speed = 1;
		private GameObject _projectile = null;
		private Transform _attacker = null;
		private IAttackable _target = null;
		private Vector3 _targetPosition = Vector3.zero;
		private int _damage = -1;
		private float _radiusDamage = 1;
		private EntitiesDetectorManager _detector = null;

		private IHitEffect _hitEffect = null;


		private void Update()
		{

			MoveTowardsTarget();
			IsTargetReach();

		}

		public void Initialize(IAttackable target, IHitEffect vfx, int damage, float radiusDamage)
		{
			if(target == null)
			{
				Destroy(gameObject);
				return;
			}
			_projectile = gameObject;
			_hitEffect = vfx;
			_damage = damage;
			_targetPosition = target.Transform.position;
			_radiusDamage = radiusDamage;
			_detector = Services.Instance.Get<EntitiesDetectorManager>();
		}

		private void MoveTowardsTarget()
		{
			_projectile.transform.position += _projectile.transform.forward * _speed * Time.deltaTime;
			_projectile.transform.LookAt(_targetPosition);
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
			_hitEffect.ExecuteHitEffect(_targetPosition);

			var Entities = _detector.GetEveryEntityInRadius(Team.Enemy, _targetPosition, _radiusDamage);

			foreach (var target in Entities)
			{
				//target.GetComponent<IAttackable>();
				target.Kill(); 
			}

		}
	}
}