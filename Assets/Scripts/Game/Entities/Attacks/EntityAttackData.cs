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
		private float _secondsBetweenAttacks = 1;
		[SerializeField]
		private float _attackRange = 1;
		[SerializeField]
		private IAttackMode _attackMode = null;


		public EntityAttackData(int damage, float secondsBetweenAttacks, float attackRange, IAttackMode attackMode, IHitEffect hitEffect)
		{
			_damage = damage;
			_secondsBetweenAttacks = secondsBetweenAttacks;
			_attackRange = attackRange;
			_attackMode = attackMode;
		}

		public int Damage => _damage;
		public float SecondsBetweenAttacks => _secondsBetweenAttacks;
		public float AttackRange => _attackRange;
		public IAttackMode AttackMode => _attackMode;


		public void SpawnRequiredComponents(GameObject entityRoot)
		{
			EntityAttack entityAttack = entityRoot.AddComponent<EntityAttack>();
			entityAttack.EntityAttackData = this;
		}
	}

}