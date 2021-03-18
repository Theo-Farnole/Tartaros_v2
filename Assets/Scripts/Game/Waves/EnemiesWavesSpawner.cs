namespace Tartaros.Wave
{
    using System;
    using System.Collections;
    using Tartaros.Utilities;
    using UnityEngine;


    public class EnemiesWavesSpawner : MonoBehaviour
    {
        public class WaveSpawningStartArgs : EventArgs
        {

        }

        public class WaveSpawningFinishedArgs : EventArgs
        {

        }

        public event EventHandler<WaveSpawningStartArgs> WaveSpawnStart;
        public event EventHandler<WaveSpawningFinishedArgs> WaveSpawnFinished;
        // public event EventHandler<KilledArgs> Killed;

        [SerializeField]
        private WavesSpawnerData _waveSpawnerData = null;
        private ISpawnPoint[] _spawnPoints = null;
        private WaveSpawnerFSM _waveFSM = null;
        private int _currentWaveIndex = 0;
        private IWaveSpawnable[] _spawnedEnemies = null;

        public WavesSpawnerData WaveSpawnerData => _waveSpawnerData;
        public ISpawnPoint[] SpawnPoints => _spawnPoints;
        public int CurrentWaveIndex => _currentWaveIndex;
        public IWaveSpawnable[] SpawnedEnemies => _spawnedEnemies;
        public WaveSpawnerFSM WaveFSM => _waveFSM;

        private void Awake()
        {
            _spawnPoints = ObjectsFinder.FindObjectsOfInterface<ISpawnPoint>();
            //TODO: WaveFSM registerService & Call it
        }


        public void InvokeWaveSpawn()
        {
            WaveSpawnStart?.Invoke(this, new WaveSpawningStartArgs());
        }

        public void InvokeWaveFinish()
        {
            WaveSpawnFinished?.Invoke(this, new WaveSpawningFinishedArgs());
        }
    }

}