namespace Tartaros.Wave
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class WavesEnemiesStillAliveManager
    {
        private List<IWaveSpawnable> _stillAliveEnemies = new List<IWaveSpawnable>();

        public int GetStillAliveEnemiesCount()
        {
            return _stillAliveEnemies.Count;
        }

        public void AddEnemyWave(IWaveSpawnable waveSpawnable)
        {
            _stillAliveEnemies.Add(waveSpawnable);
            if(waveSpawnable != null)
            {
                waveSpawnable.Killed -= WaveSpawnable_Killed;
                waveSpawnable.Killed += WaveSpawnable_Killed;
            }
        }

        private void WaveSpawnable_Killed(object sender, KilledArgs e)
        {
            if (sender is IWaveSpawnable waveSpawnable)
            {
                waveSpawnable.Killed -= WaveSpawnable_Killed;
                _stillAliveEnemies.Remove(waveSpawnable);
            }
        }
    }
}