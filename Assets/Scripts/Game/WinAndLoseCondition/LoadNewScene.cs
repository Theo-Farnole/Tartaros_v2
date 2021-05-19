namespace Tartaros
{
	using System.Collections;
	using UnityEngine;
	using UnityEngine.SceneManagement;

	public class LoadNewScene
	{
		public void LoadScene(string scenename)
		{
			if (scenename != null)
			{
				SceneManager.LoadScene(scenename);
			}
		}
	}
}