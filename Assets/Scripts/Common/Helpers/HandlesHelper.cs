namespace Tartaros.Editor
{
	using System.Collections.Generic;
	using UnityEditor;
	using UnityEngine;
	using UnityEngine.Rendering;

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

		public static void DrawSolidCircle(Vector3 position, Vector3 up, float radius, Color color)
		{
			Color wireColor = color;
			Color fillColor = color;
			fillColor.a = 0.1f;

			Handles.zTest = CompareFunction.LessEqual;

			PushColor(wireColor);
			{
				Handles.DrawWireDisc(position, up, radius);
			}
			PopColor();

			PushColor(fillColor);
			{
				Handles.DrawSolidDisc(position, up, radius);
			}
			PopColor();
		}

		public static void DrawWireCircle(Vector3 position, Vector3 up, float radius, Color color)
		{
			Color wireColor = color;

			Handles.zTest = CompareFunction.LessEqual;

			PushColor(wireColor);
			{
				Handles.DrawWireDisc(position, up, radius);
			}
			PopColor();
		}
	}
}
