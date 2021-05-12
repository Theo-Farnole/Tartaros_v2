namespace Tartaros.Wave
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class WaveCooldownState : AWaveSpawnerState
	{
		#region Fields
		private float _passedSeconds = 0;
		#endregion Fields

		#region Properties
		public float PassedSeconds => _passedSeconds;
		private float SecondsBetweenWaves => _stateOwner.WaveSpawnerData.SecondsBetweenWaves;
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
			_stateOwner.InvokeWaveStartCooldown();			
		}

		public override void OnUpdate()
		{
			base.OnUpdate();

			_passedSeconds += Time.deltaTime;
		}

		private IEnumerator DelayBeforeNextWave(float delay)
		{
			yield return new WaitForSeconds(delay);
			_stateOwner.StartNewWave();
		}
		#endregion Fields
	}

}