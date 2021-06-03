namespace Tartaros.SoundSystem
{
	using Tartaros.ServicesLocator;
	using Tartaros.Wave;
	using UnityEngine;

	/// <summary>
	/// Listen to events, and play appropriate events.
	/// </summary>
	public class SoundsPlayerManager : MonoBehaviour
	{
		private EnemiesWavesManager _waveManager = null;
		private SoundsHandler _soundsHandler = null;

		private void Awake()
		{
			_waveManager = Services.Instance.Get<EnemiesWavesManager>();
			_soundsHandler = Services.Instance.Get<SoundsHandler>();
		}

		private void OnEnable()
		{
			_waveManager.WaveSpawnStart -= _waveManager_WaveSpawnStart;
			_waveManager.WaveSpawnStart += _waveManager_WaveSpawnStart;

			_waveManager.WaveFinish -= _waveManager_WaveFinish;
			_waveManager.WaveFinish += _waveManager_WaveFinish;
		}

		private void OnDisable()
		{
			_waveManager.WaveFinish -= _waveManager_WaveFinish;
			_waveManager.WaveSpawnStart -= _waveManager_WaveSpawnStart;
		}

		private void _waveManager_WaveSpawnStart(object sender, EnemiesWavesManager.WaveSpawningStartArgs e)
		{
			_soundsHandler.PlayOneShot(SoundsSystem.Sound.WaveStart);
		}

		private void _waveManager_WaveFinish(object sender, EnemiesWavesManager.WaveIsFinishArgs e)
		{
			_soundsHandler.PlayOneShot(SoundsSystem.Sound.WaveEnd);
		}

	}
}
