namespace Tartaros.SoundsSystem
{
	using Tartaros.Entities;
	using Tartaros.Selection;
	using Tartaros.ServicesLocator;
	using Tartaros.Wave;
	using UnityEngine;
	using UnityEngine.Rendering;

	/// <summary>
	/// Listen to events, and play appropriate events.
	/// </summary>
	public class SoundsPlayerManager : MonoBehaviour
	{
		private EnemiesWavesManager _waveManager = null;
		private SoundsHandler _soundsHandler = null;
		private ISelection _currentSelection = null;

		private void Awake()
		{
			_waveManager = Services.Instance.Get<EnemiesWavesManager>();
			_soundsHandler = Services.Instance.Get<SoundsHandler>();
			_currentSelection = Services.Instance.Get<CurrentSelection>();
		}

		private void OnEnable()
		{
			_waveManager.WaveSpawnStart -= _waveManager_WaveSpawnStart;
			_waveManager.WaveSpawnStart += _waveManager_WaveSpawnStart;

			_waveManager.WaveFinish -= _waveManager_WaveFinish;
			_waveManager.WaveFinish += _waveManager_WaveFinish;

			_currentSelection.SelectionChanged -= _currentSelection_SelectionChanged;
			_currentSelection.SelectionChanged += _currentSelection_SelectionChanged;
		}

		private void OnDisable()
		{
			_waveManager.WaveFinish -= _waveManager_WaveFinish;
			_waveManager.WaveSpawnStart -= _waveManager_WaveSpawnStart;
			_currentSelection.SelectionChanged -= _currentSelection_SelectionChanged;
		}

		private void _waveManager_WaveSpawnStart(object sender, EnemiesWavesManager.WaveSpawningStartArgs e)
		{
			_soundsHandler.PlayOneShot(Sound.WaveStart);
		}

		private void _waveManager_WaveFinish(object sender, EnemiesWavesManager.WaveIsFinishArgs e)
		{
			_soundsHandler.PlayOneShot(Sound.WaveEnd);
		}
		private void _currentSelection_SelectionChanged(object sender, SelectionChangedArgs e)
		{
			foreach (ISelectable added in e.added)
			{
				_soundsHandler.PlaySelection(added);
			}
		}
	}
}
