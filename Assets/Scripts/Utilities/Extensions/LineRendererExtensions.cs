namespace Tartaros
{
	using UnityEngine;

	public static class LineRendererExtensions
	{
		public static void SetColor(this LineRenderer lineRenderer, Color color)
		{
			lineRenderer.startColor = color;
			lineRenderer.endColor = color;
		}
	}
}