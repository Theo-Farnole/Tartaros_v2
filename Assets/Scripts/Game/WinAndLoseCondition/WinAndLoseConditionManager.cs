namespace Tartaros
{
	using System.Collections;
	using System.Collections.Generic;
	using Tartaros.Wave;
	using UnityEngine;

	public class WinAndLoseConditionManager : MonoBehaviour
	{
		[SerializeField] private bool _loadSceneOrNot = false;
		[SerializeField] private string _winSceneName = null;
		[SerializeField] private string _loseSceneName = null;

		private GameObject _temple = null;
		private EnemiesWavesManager _waveManager = null;
		private bool _isGameLose = false;
		private LoadNewScene _loadNewScene = null;
		
		private void Awake()
		{
			_temple = FindObjectOfType<WavesEnemiesTarget>().gameObject;
			_waveManager = FindObjectOfType<EnemiesWavesManager>();
			_loadNewScene = new LoadNewScene();
		}

		private void OnEnable()
		{
			_waveManager.WavesFinish -= WavesFinished;
			_waveManager.WavesFinish += WavesFinished;
		}

		private void Update()
		{
			if (_isGameLose == false && _temple == null)
			{
				GameIsLose();
			}
		}

		private void WavesFinished(object sender, EnemiesWavesManager.EveryWaveAreFinishedArgs e)
		{
			Debug.Log("Game is win");

			if(_loadSceneOrNot == true)
			{
				_loadNewScene.LoadScene(_winSceneName);
			}
		}

		private void GameIsLose()
		{
			Debug.Log("game is lose");
			_isGameLose = true;

			if (_loadSceneOrNot == true)
			{
				_loadNewScene.LoadScene(_loseSceneName);
			}
		}
	}
}