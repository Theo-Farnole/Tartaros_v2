namespace Tartaros.Entities
{
	using UnityEngine;

	public interface IAttackable
	{
		bool IsAlive { get; }

		void TakeDamage(int damage);

		Transform Transform { get; }
	}
}