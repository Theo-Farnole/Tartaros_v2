namespace Tartaros.Wave
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class WaveSpawningState : AWaveSpawnerState
    {
        private int _waveIndex = 0;
        private WavesSpawnerData _waveSpawnerData = null;
        private WaveData _waveData = null;
        private ISpawnPoint[] _spawnPoint = null;
        private int _totalWaveEnemies = 0;
        private WavesEnemiesStillAliveManager _stillAliveManger = null; 
        private int _numberOfSpawnPoint = 0;
        private WaveSpawnerFSM _waveFSM = null;

        public WaveSpawningState(EnemiesWavesSpawner stateOwner) : base(stateOwner)
        {
            _waveIndex = stateOwner.CurrentWaveIndex;
            _waveSpawnerData = stateOwner.WaveSpawnerData;
            _waveData = stateOwner.WaveSpawnerData.Wave[_waveIndex];
            _spawnPoint = stateOwner.SpawnPoints;
            _numberOfSpawnPoint = _spawnPoint.Length;
            _stillAliveManger = new WavesEnemiesStillAliveManager();
            _waveFSM = stateOwner.WaveFSM;
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();

            SpawnWave(_stateOwner, _spawnPoint);
           
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (CheckIfSpawnIsFinish())
            {
                OnStateExit();
            }
        }

        public override void OnStateExit()
        {
            base.OnStateExit();

            _waveFSM.CurrentState = new WaitDeathOfSpawnedEnemiesWaveState(_stateOwner, _stillAliveManger);
        }


        public void SpawnWave(MonoBehaviour mb, ISpawnPoint[] spawnPoints)
        {
            foreach (ISpawnPoint spawnPoint in spawnPoints)
            {
                UnitSequence[] unitSequences = _waveData.GetUnitSequences(spawnPoint.Identifier);
                mb.StartCoroutine(SpawnPointsSequences(unitSequences, spawnPoint));
            }
        }
        public IEnumerator SpawnPointsSequences(UnitSequence[] unitSequences, ISpawnPoint spawnPoint)
        {
            foreach (UnitSequence sequence in unitSequences)
            {
                yield return new WaitForSeconds(sequence.SecondsBeforeSpawn);
                yield return SpawnUnits(spawnPoint, sequence);
                _numberOfSpawnPoint--;
            }
        }


        public IEnumerator SpawnUnits(ISpawnPoint spawnPoint, UnitSequence unitSequence)
        {
            for (int i = 0; i < unitSequence.EntitiesCount; i++)
            {
                GameObject spawnedEntity = GameObject.Instantiate(unitSequence.EntityToSpawn.Prefab, spawnPoint.SpawnPoint, Quaternion.identity);
                _stillAliveManger.AddEnemyWave(spawnedEntity.GetComponent<IWaveSpawnable>());
                yield return new WaitForSeconds(unitSequence.SecondsBetweenUnits);
            }
        }

        private bool CheckIfSpawnIsFinish()
        {
            return (_numberOfSpawnPoint == 0);
        }
    }
}