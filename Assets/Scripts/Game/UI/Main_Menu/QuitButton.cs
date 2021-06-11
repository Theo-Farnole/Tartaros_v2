namespace Tartaros.UI.MainMenu
{
	using Tartaros.UI;

	public class QuitButton : AButtonActionAttacher
	{
		protected override void OnButtonClick()
		{
			QuitGame();
		}

		private static void QuitGame()
		{
#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
#else
         UnityEngine.Application.Quit();
#endif
		}
	}
}
