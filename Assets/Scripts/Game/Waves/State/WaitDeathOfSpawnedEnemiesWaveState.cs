namespace Tartaros.Wave
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class WaitDeathOfSpawnedEnemiesWaveState : AWaveSpawnerState
	{
		#region Fields
		private readonly WavesEnemiesStillAliveManager _stillAliveManager = null;
		#endregion Fields

		#region Ctor
		public WaitDeathOfSpawnedEnemiesWaveState(EnemiesWavesManager stateOwner, WavesEnemiesStillAliveManager stillAliveManager) : base(stateOwner)
		{
			_stillAliveManager = stillAliveManager;
		}
		#endregion Ctor

		#region Methods
		public override void OnStateEnter()
		{
			base.OnStateEnter();
		}

		public override void OnUpdate()
		{
			base.OnUpdate();

			if (IsEverySpawnedEnemiesWaveDead())
			{
				if (_stateOwner.CurrentWaveIndex < _stateOwner.LastWaveIndex)
				{
					_stateOwner.WaveFSM.CurrentState = new WaveCooldownState(_stateOwner);
				}
				else
				{

					_stateOwner.WaveFSM.CurrentState = new WaveFinishedState(_stateOwner);
				}
			}
		}

		private bool IsEverySpawnedEnemiesWaveDead()
		{
			return (_stillAliveManager.GetStillAliveEnemiesCount() == 0);
		}
		#endregion Methods
	}
}