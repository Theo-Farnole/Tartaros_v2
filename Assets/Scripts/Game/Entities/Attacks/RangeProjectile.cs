namespace Tartaros.Entities.Attack
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class RangeProjectile : MonoBehaviour
	{
		private const float THRESHOLD_HIT_DISTANCE = 0.3f;

		[SerializeField]
		private float _speed = 1;
		private GameObject _projectile = null;
		private Transform _attacker = null;
		private IAttackable _target = null;
		private int _damage = -1;

		private IHitEffect _hitEffect = null;

		private void Update()
		{
			if (_target.IsInterfaceDestroyed() == true)
			{
				Destroy(gameObject);
				return;
			}

			MoveTowardsTarget();
			IsTargetReach();

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
			_projectile.transform.position += _projectile.transform.forward * _speed * Time.deltaTime;
			_projectile.transform.LookAt(_target.Transform);
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
			
			_target.TakeDamage(_damage);
		}
	}
}