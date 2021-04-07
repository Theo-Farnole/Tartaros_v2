namespace Tartaros.Entities.Attack
{
	using Sirenix.Serialization;
	using System.Collections;
	using UnityEngine;

	public class MeleeAttackMode : IAttackMode
	{
		[OdinSerialize]
		private IHitEffect _vfxPrefab = null;

		string IAttackMode.DisplayTypeUI => "Melee";

		void IAttackMode.Attack(Transform attacker, IAttackable target)
		{
			if(_vfxPrefab != null)
			{
				_vfxPrefab.ExecuteHitEffect(target.Transform.position);
			}

			EntityAttack entityAttack = attacker.GetComponent<EntityAttack>();
			target.TakeDamage(entityAttack.EntityAttackData.Damage);
		}
	}
}