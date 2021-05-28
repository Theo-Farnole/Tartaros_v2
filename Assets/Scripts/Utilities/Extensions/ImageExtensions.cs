namespace Tartaros
{
	using UnityEngine;
	using UnityEngine.UI;

	public static class ImageExtensions
	{
		public static void SetAlpha(this Image image, float alpha)
		{
			Color color = image.color;
			color.a = alpha;
			image.color = color;
		}
	}
}
