namespace Tartaros.Wave
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class WaveCooldownState : AWaveSpawnerState
    {
        public WaveCooldownState(EnemiesWavesManager stateOwner) : base(stateOwner)
        {
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();
            Debug.Log("enter_CooldownState");
            _stateOwner.StartCoroutine(DelayBeforeNextWave(_stateOwner.WaveSpawnerData.SecondsBetweenWaves));
        }

        public override void OnStateExit()
        {
            base.OnStateExit();

            Debug.Log("exit_CooldownState");
            //_stateOwner.WaveFSM.CurrentState = new WaveSpawningState(_stateOwner);
        }

        public IEnumerator DelayBeforeNextWave(float delay)
        {
            yield return new WaitForSeconds(delay);
            OnStateExit();
        }
    }

}