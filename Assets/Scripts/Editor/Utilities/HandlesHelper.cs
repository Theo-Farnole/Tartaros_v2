namespace Tartaros.Editor
{
	using System.Collections.Generic;
	using UnityEditor;
	using UnityEngine;

	public static class HandlesHelper
	{
		private static readonly Color DEFAULT_COLOR = Color.white;
		private static Stack<Color> _handlesColor = new Stack<Color>();

		public static void PushColor(Color color)
		{
			_handlesColor.Push(color);

			Handles.color = color;
		}

		public static void PopColor()
		{
			Handles.color = GetColor();

			Color GetColor()
			{
				if (_handlesColor.Count > 1)
				{
					return _handlesColor.Pop();
				}
				else
				{
					return DEFAULT_COLOR;
				}
			}
		}
	}
}
