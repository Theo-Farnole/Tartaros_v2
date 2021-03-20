namespace Tartaros.Wave
{
    using System;
    using System.Collections;
    using Tartaros.Utilities;
    using UnityEngine;


    public class EnemiesWavesManager : MonoBehaviour
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
        private int _currentWaveIndex = 1;
        private IWaveSpawnable[] _spawnedEnemies = null;

        public WavesSpawnerData WaveSpawnerData => _waveSpawnerData;
        public ISpawnPoint[] SpawnPoints => _spawnPoints;
        public int CurrentWaveIndex => _currentWaveIndex;
        public IWaveSpawnable[] SpawnedEnemies => _spawnedEnemies;
        public WaveSpawnerFSM WaveFSM => _waveFSM;

        private void Awake()
        {
            _spawnPoints = ObjectsFinder.FindObjectsOfInterface<ISpawnPoint>();
            _waveFSM = new WaveSpawnerFSM();
            //TODO: WaveFSM registerService & Call it
        }

        private void OnEnable()
        {
            //WaveFSM.CurrentState = new WaveCooldownState(this);
            WaveFSM.CurrentState = new WaveSpawningState(this);
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