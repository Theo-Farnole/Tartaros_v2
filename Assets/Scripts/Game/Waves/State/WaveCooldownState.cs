namespace Tartaros.Wave
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class WaveCooldownState : AWaveSpawnerState
    {
        public WaveCooldownState(EnemiesWavesSpawner stateOwner) : base(stateOwner)
        {
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();

            _stateOwner.StartCoroutine(DelayBeforeNextWave(_stateOwner.WaveSpawnerData.SecondsBetweenWaves));
        }

        public override void OnStateExit()
        {
            base.OnStateExit();

            _stateOwner.WaveFSM.CurrentState = new WaveSpawningState(_stateOwner);
        }

        public IEnumerator DelayBeforeNextWave(float delay)
        {
            yield return new WaitForSeconds(delay);
            OnStateExit();
        }
    }

}