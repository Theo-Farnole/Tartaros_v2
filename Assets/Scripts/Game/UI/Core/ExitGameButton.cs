namespace Tartaros.UI
{
	using System;
	using UnityEngine;

	public class ExitGameButton : AButtonActionAttacher
	{
		protected override void OnButtonClick()
		{
#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
#else
			Application.Quit();
#endif
		}
	}
}
