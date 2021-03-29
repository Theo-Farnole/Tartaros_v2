namespace TF.SceneBrowser.Editor
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEditor;
	using UnityEngine;

	internal static class GUIHelper
	{
		public static void DrawSeparator()
		{
			EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
		}

		public static bool DrawColoredButton(string name, Color color, params GUILayoutOption[] layoutOptions)
		{
			GUI.backgroundColor = color;

			bool buttonClicked = GUILayout.Button(name, layoutOptions);

			GUI.backgroundColor = Color.white;

			return buttonClicked;
		}


		private static Stack<Color> _backgroundColorStack = new Stack<Color>();

		public static void PushBackgroundColor(Color color)
		{
			_backgroundColorStack.Push(GUI.backgroundColor);
			GUI.backgroundColor = color;
		}

		public static void PopBackgroundColor()
		{
			GUI.backgroundColor = _backgroundColorStack.Pop();
		}
	}
}
