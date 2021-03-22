namespace Tartaros.Entities.Attack
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class RangeProjectile : MonoBehaviour
    {
        [SerializeField]
        private float _speed = 1;
        private GameObject _projectile = null;
        private Transform _attacker = null;
        private IAttackable _target = null;

        private IHitEffect _hitEffect = null;

        private void Update()
        {
            ProjectileTravel();
        }

        public void Initialize(Transform attacker, IAttackable target, IHitEffect vfx)
        {
            _projectile = gameObject;
            _attacker = attacker;
            _target = target;
            _hitEffect = vfx;
        }

        private void ProjectileTravel()
        {
            Vector3 directionYoTarget = (_attacker.position - _target.Transform.position).normalized;
            _projectile.transform.position = Vector3.forward * _speed;
        }

        private void IsReachTarget()
        {
            float distanceFromTarget = Vector3.Distance(_projectile.transform.position, _target.Transform.position);
            float triggerToTouchTarget = 2f;

            if (distanceFromTarget <= triggerToTouchTarget)
            {
                ReachTarget();
            }
        }

        private void ReachTarget()
        {
            _hitEffect.ExecuteHitEffect(_target.Transform.position);
            EntityAttack entityAttack = _attacker.GetComponent<EntityAttack>();

            _target.TakeDamage(entityAttack.EntityAttackData.Damage);
        }
    }
}