namespace Tartaros.UI.MainMenu
{
	using System;
	using Tartaros.UI;
	using UnityEngine;
	using UnityEngine.SceneManagement;

	public class PlayButton : AButtonActionAttacher
	{
		[SerializeField] private SceneReference _sceneToLoad = null;
		[SerializeField] private bool _loadAsyncOnStart = true;

		private AsyncOperation _asyncOperation = null;

		private void Start()
		{
			if (_loadAsyncOnStart == true)
			{
				_asyncOperation = SceneManager.LoadSceneAsync(_sceneToLoad.ScenePath);
				_asyncOperation.allowSceneActivation = false;
			}
		}

		protected override void OnButtonClick()
		{
			if (_asyncOperation != null)
			{
				_asyncOperation.allowSceneActivation = true;
			}
			else
			{
				SceneManager.LoadScene(_sceneToLoad);
			}
		}
	}
}
