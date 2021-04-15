namespace Tartaros.Entities
{
	using System;

	public class HealthChangedArgs : EventArgs
	{ }

	public interface IHealthable
	{
		int CurrentHealth { get; }
		int MaxHealth { get; }
		event EventHandler<HealthChangedArgs> HealthChanged;
		void Heal(int amount);
	}
}
