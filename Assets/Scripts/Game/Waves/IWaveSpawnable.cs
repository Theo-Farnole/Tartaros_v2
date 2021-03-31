namespace Tartaros.Wave
{
    using System;
	using Tartaros.Entities;

	public class KilledArgs : EventArgs
    {

    }

    public interface IWaveSpawnable
    {
        event EventHandler<KilledArgs> Killed;
        void Attack(IAttackable attackable);
    }
}