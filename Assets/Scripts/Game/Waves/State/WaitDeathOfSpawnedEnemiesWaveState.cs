namespace Tartaros.Wave
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class WaitDeathOfSpawnedEnemiesWaveState : AWaveSpawnerState
    {

        private WavesEnemiesStillAliveManager _stillAliveManager = null;
        public WaitDeathOfSpawnedEnemiesWaveState(EnemiesWavesSpawner stateOwner, WavesEnemiesStillAliveManager stillAliveManager) : base(stateOwner)
        {
            _stillAliveManager = stillAliveManager;
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();

        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            if (IsEverySpawnedEnemiesWaveDead())
            {
                
            }
        }

        public override void OnStateExit()
        {
            base.OnStateExit();

            _stateOwner.WaveFSM.CurrentState = new WaveCooldownState(_stateOwner);
        }

        private bool IsEverySpawnedEnemiesWaveDead()
        {
            return (_stillAliveManager.GetStillAliveEnemiesCount() == 0);
        }
    }
}