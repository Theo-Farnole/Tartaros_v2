namespace Tartaros.Entities
{
	using Tartaros.Entities.Attack;
	using Tartaros.Entities.Detection;
	using UnityEngine;

	[System.Serializable]
	public class EntityAttackData : IEntityBehaviourData
	{

		[SerializeField]
		private float _secondsBetweenAttacks = 1;
		[SerializeField]
		private float _attackRange = 1;
		[SerializeField]
		private IAttackMode _attackMode = null;


		public EntityAttackData(float secondsBetweenAttacks, float attackRange, IAttackMode attackMode, IHitEffect hitEffect)
		{
			_secondsBetweenAttacks = secondsBetweenAttacks;
			_attackRange = attackRange;
			_attackMode = attackMode;
		}

		public int Damage => _attackMode.Damage;
		public float SecondsBetweenAttacks => _secondsBetweenAttacks;
		public float AttackRange => _attackRange;
		public IAttackMode AttackMode => _attackMode;


#if UNITY_EDITOR
		void IEntityBehaviourData.SpawnRequiredComponents(GameObject entityRoot)
		{
			entityRoot.GetOrAddComponent<EntityAttack>();
			entityRoot.GetOrAddComponent<EntityDetection>();
			entityRoot.GetOrAddComponent<EntityFSM>();
		}
#endif
	}

}