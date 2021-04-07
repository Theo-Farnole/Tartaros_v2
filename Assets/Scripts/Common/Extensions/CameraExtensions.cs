namespace Tartaros
{
	using UnityEngine;

	public static class CameraExtensions
	{
		public static bool IsInWorldPointInBounds(this UnityEngine.Camera camera, Bounds bounds, Vector3 position)
		{
			return bounds.Contains(camera.WorldToViewportPoint(position));
		}
	}
}
