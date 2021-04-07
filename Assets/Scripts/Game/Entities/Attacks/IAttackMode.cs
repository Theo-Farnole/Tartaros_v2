using UnityEngine;

namespace Tartaros.Entities.Attack
{
	public interface IAttackMode
	{
		/// <summary>
		/// What is display in the UI. 
		/// </summary>
		string DisplayTypeUI { get; }
		void Attack(Transform attacker, IAttackable target);
	}
}