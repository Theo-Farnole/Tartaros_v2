namespace Tartaros
{
	using System.Collections;
	using System.Collections.Generic;
	using Tartaros.Wave;
	using UnityEngine;
	using UnityEngine.SceneManagement;

	public class WinAndLoseConditionManager : MonoBehaviour
	{
		#region Fields
		[SerializeField] private bool _loadSceneOnWin = false;
		[SerializeField] private SceneReference _winSceneName = null;
		[SerializeField] private bool _loadSceneOnLose = false;
		[SerializeField] private SceneReference _loseSceneName = null;


		private GameObject _temple = null;
		private EnemiesWavesManager _waveManager = null;
		private bool _isGameOver = false;
		#endregion Fields

		#region Methods
		private void Awake()
		{
			_temple = FindObjectOfType<WavesEnemiesTarget>().gameObject;
			_waveManager = FindObjectOfType<EnemiesWavesManager>();
		}

		private void OnEnable()
		{
			_waveManager.GameFinish -= WavesFinished;
			_waveManager.GameFinish += WavesFinished;
		}

		private void Update()
		{
			if (_isGameOver == false && _temple == null)
			{
				GameIsLose();
			}
		}

		private void WavesFinished(object sender, EnemiesWavesManager.EveryWaveAreFinishedArgs e)
		{
			if (_isGameOver == true) return;

			Debug.Log("Game is win");
			_isGameOver = true;

			if (_loadSceneOnWin == true)
			{
				LoadScene(_winSceneName);
			}
		}

		private void GameIsLose()
		{
			if (_isGameOver == true) return;

			Debug.Log("game is lose");
			_isGameOver = true;

			if (_loadSceneOnLose == true)
			{
				LoadScene(_loseSceneName);
			}
		}

		private void LoadScene(string scenename)
		{
			if (scenename != null)
			{
				SceneManager.LoadScene(scenename);
			}
		}
		#endregion Methods
	}
}