namespace Tartaros
{
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.SceneManagement;

	public class LoadSceneOnAwake : MonoBehaviour
	{
		#region Fields
		[SerializeField]
		private SceneReference _sceneToLoad = null;

		[SerializeField]
		private List<SceneReference> _additivesScenes = null;
		#endregion Fields

		#region Methods
		private void Awake()
		{
			SceneManager.LoadScene(_sceneToLoad);

			foreach (var additiveScene in _additivesScenes)
			{
				SceneManager.LoadScene(additiveScene, LoadSceneMode.Additive);
			}
		}
		#endregion Methods
	}
}
