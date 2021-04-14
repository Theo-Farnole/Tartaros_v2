namespace Tartaros
{
	using UnityEngine;

	// from
	// https://hyunkell.com/blog/rts-style-unit-selection-in-unity-5/

	public static class GUIRectDrawer
	{
		#region Fields
		private static Texture2D _whiteTexture;
		#endregion Fields

		#region Properties
		public static Texture2D WhiteTexture
		{
			get
			{
				if (_whiteTexture == null)
				{
					_whiteTexture = new Texture2D(1, 1);
					_whiteTexture.SetPixel(0, 0, Color.white);
					_whiteTexture.Apply();
				}

				return _whiteTexture;
			}
		}
		#endregion Properties

		#region Methods
		public static Rect GetScreenRect(Vector3 screenPosition1, Vector3 screenPosition2)
		{
			// Move origin from bottom left to top left
			screenPosition1.y = Screen.height - screenPosition1.y;
			screenPosition2.y = Screen.height - screenPosition2.y;
			// Calculate corners
			var topLeft = Vector3.Min(screenPosition1, screenPosition2);
			var bottomRight = Vector3.Max(screenPosition1, screenPosition2);
			// Create Rect
			return Rect.MinMaxRect(topLeft.x, topLeft.y, bottomRight.x, bottomRight.y);
		}

		public static Bounds GetViewportBounds(Camera camera, Vector3 screenPosition1, Vector3 screenPosition2)
		{
			var v1 = camera.ScreenToViewportPoint(screenPosition1);
			var v2 = camera.ScreenToViewportPoint(screenPosition2);
			var min = Vector3.Min(v1, v2);
			var max = Vector3.Max(v1, v2);
			min.z = camera.nearClipPlane;
			max.z = camera.farClipPlane;
			//min.z = 0.0f;
			//max.z = 1.0f;

			var bounds = new Bounds();
			bounds.SetMinMax(min, max);

			return bounds;
		}

		public static void DrawScreenRect(Rect rect, Color color)
		{
			GUI.color = color;
			GUI.DrawTexture(rect, WhiteTexture);
			GUI.color = Color.white;
		}

		public static void DrawScreenRectBorder(Rect rect, float thickness, Color color)
		{
			// Top
			DrawScreenRect(new Rect(rect.xMin, rect.yMin, rect.width, thickness), color);
			// Left
			DrawScreenRect(new Rect(rect.xMin, rect.yMin, thickness, rect.height), color);
			// Right
			DrawScreenRect(new Rect(rect.xMax - thickness, rect.yMin, thickness, rect.height), color);
			// Bottom
			DrawScreenRect(new Rect(rect.xMin, rect.yMax - thickness, rect.width, thickness), color);
		}
		#endregion Methods
	}
}
