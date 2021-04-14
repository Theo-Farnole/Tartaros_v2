namespace Tartaros
{
	using UnityEngine;

	public class ForceWindowModeAtStart : MonoBehaviour
	{
		private void Start()
		{
			Screen.fullScreen = false;
			Screen.fullScreenMode = FullScreenMode.Windowed;
		}
	}
}