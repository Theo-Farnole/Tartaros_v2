namespace Tartaros.Wave
{
    using System;
    using UnityEngine;
    using Tartaros.Entities;

	public class KilledArgs : EventArgs
    {

    }

    public interface IWaveSpawnable
    {
        event EventHandler<KilledArgs> Killed;
        void Attack(IAttackable attackable, Vector3[] waypoints);
    }
}