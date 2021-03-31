namespace Tartaros.Wave
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class WaveCooldownState : AWaveSpawnerState
	{
		#region Properties
		public float SecondsBetweenWaves => _stateOwner.WaveSpawnerData.SecondsBetweenWaves;
		#endregion Properties

		#region Ctor
		public WaveCooldownState(EnemiesWavesManager stateOwner) : base(stateOwner)
		{
		}
		#endregion Ctor

		#region Fields
		public override void OnStateEnter()
		{
			base.OnStateEnter();

			_stateOwner.StartCoroutine(DelayBeforeNextWave(SecondsBetweenWaves));
		}

		private IEnumerator DelayBeforeNextWave(float delay)
		{
			yield return new WaitForSeconds(delay);
			_stateOwner.StartNewWave();
		}
		#endregion Fields
	}

}