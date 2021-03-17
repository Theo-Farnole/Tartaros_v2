namespace Tartaros.Wave
{
    using System;
    using System.Collections;
    using UnityEngine;


    public class EnemiesWavesSpawner : MonoBehaviour, IWaveSpawnable
    {
        public event EventHandler<KilledArgs> Killed;

        public ISpawnPoint[] spawnPoints;
         
    }

}