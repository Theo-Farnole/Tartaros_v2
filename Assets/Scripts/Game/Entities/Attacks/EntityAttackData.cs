namespace Tartaros.Entities
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Tartaros.Entities;
    using Tartaros.Entities.Attack;

    public class EntityAttackData : IEntityBehaviourData
    {
        [SerializeField]
        private int _damage = 1;
        [SerializeField]
        private float _attackSpeed = 1;
        [SerializeField]
        private float _attackRange = 1;
        [SerializeField]
        private IAttackMode _attackMode = null;


        public EntityAttackData(int damage, float attackSpeed, float attackRange, IAttackMode attackMode, IHitEffect hitEffect)
        {
            _damage = damage;
            _attackSpeed = attackSpeed;
            _attackRange = attackRange;
            _attackMode = attackMode;
        }

        public int Damage => _damage;
        public float AttackSpeed => _attackSpeed;
        public float AttackRange => _attackRange;
        public IAttackMode AttackMode => _attackMode;


        public void SpawnRequiredComponents(GameObject entityRoot)
        {
			EntityAttack entityAttack = entityRoot.AddComponent<EntityAttack>();
            entityAttack.EntityAttackData = this;
        }
    }

}