﻿namespace Tartaros.Entities.Attack
{
	using Sirenix.Serialization;
	using System.Collections;
	using UnityEngine;

	[System.Serializable]
	public class MeleeAttackMode : IAttackMode
	{
		[OdinSerialize]
		private IHitEffect _vfxPrefab = null;
		[SerializeField]
		private int _damage = 1;

		string IAttackMode.DisplayTypeUI => "Melee";

		int IAttackMode.Damage => _damage;

		void IAttackMode.Attack(Transform attacker, IAttackable target)
		{
			if (target is null) throw new System.ArgumentNullException(nameof(target));

			if (_vfxPrefab != null)
			{
				_vfxPrefab.ExecuteHitEffect(target.Transform.position);
			}

			EntityAttack entityAttack = attacker.GetComponent<EntityAttack>();
			IAttackable attackerReference = attacker.GetComponent<IAttackable>();
			target.TakeDamage(entityAttack.EntityAttackData.Damage, attackerReference);
		}
	}
}