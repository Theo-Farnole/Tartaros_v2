namespace Tartaros.Utilities
{
	using Sirenix.OdinInspector;
	using UnityEngine;

	/// <summary>
	/// Display FPS on GUI.
	/// Code from https://wiki.unity3d.com/index.php/FramesPerSecond
	/// </summary>
	public class FPSCounter : MonoBehaviour
	{
		#region Fields
		[SerializeField]
		private bool _displayFPS = true;

		[SerializeField]
		[SuffixLabel("% of the screen's height")]
		private float _fontsize = 5;

		float deltaTime = 0.0f;
		#endregion Fields

		#region Methods
		// must be called from referenced class
		public void Update()
		{
			deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
		}

		public void OnGUI()
		{
			if (!_displayFPS)
				return;

			int w = Screen.width, h = Screen.height;

			GUIStyle style = new GUIStyle();

			Rect rect = new Rect(10, 10, w, h * 2 / 100);
			style.alignment = TextAnchor.UpperLeft;
			style.fontSize = Mathf.RoundToInt(h * _fontsize / 100); // 4 percent of the screen's height
			style.normal.textColor = Color.white;
			float msec = deltaTime * 1000.0f;
			float fps = 1.0f / deltaTime;
			string text = string.Format("{1:0.} fps", msec, fps);
			GUI.Label(rect, text, style);
		}
		#endregion Methods
	}
}


