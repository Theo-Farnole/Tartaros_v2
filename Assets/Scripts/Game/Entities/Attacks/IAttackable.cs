namespace Tartaros.Entities
{
	using UnityEngine;

	public interface IAttackable
	{
		bool IsAlive { get; }

		void TakeDamage(int damage, IAttackable attacker);

		Transform Transform { get; }

		float SizeRadius { get; }
	}
}