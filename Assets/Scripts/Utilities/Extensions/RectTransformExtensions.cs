namespace Tartaros
{
	using UnityEngine;
	using UnityEngine.UI;

	public static class RectTransformExtensions
	{
		private static readonly Vector2 CENTER = new Vector2(0.5f, 0.5f);

		public static void CenterAnchor(this RectTransform rt)
		{
			rt.anchorMax = CENTER;
			rt.anchorMin = CENTER;
		}

		public static void CenterPivot(this RectTransform rt)
		{
			rt.pivot = CENTER;
		}

		public static Vector2 GetCenterTopPosition(this RectTransform rt)
		{
			Vector2 pivot = rt.pivot;
			rt.CenterPivot();

			Vector2 position = new Vector2(rt.rect.center.x, rt.rect.yMax) + rt.anchoredPosition;

			rt.pivot = pivot;

			return position;
		}
	}
}
