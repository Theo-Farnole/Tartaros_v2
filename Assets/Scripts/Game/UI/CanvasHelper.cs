namespace Tartaros
{
	using System;
	using System.Linq;
	using UnityEngine;

	public static class CanvasHelper
	{
		private static Canvas[] _deactivatedCanvases = null;

		public static void SetActiveAllCanvasInScene(bool active, params Canvas[] canvasesToIgnore)
		{
			if (active == false)
			{
				Canvas[] canvases = GameObject.FindObjectsOfType<Canvas>()
					.Where(canvas => IsCanvasIgnored(canvas))
					.ToArray();

				// check for errors
				if (canvases.Length == 0)
				{
					Debug.LogWarning("Trying to active all canvas in the scene while they are all deactivated or there is no canvas. Method aborted");
					return;
				}

				// when canvas are desactivated, FindObjectsOfType doesn't work
				// so we must register them in a field
				_deactivatedCanvases = canvases;
			}

			// check for errors
			if (_deactivatedCanvases == null)
			{
				if (Time.timeSinceLevelLoad > 0) throw new System.NotSupportedException("Cannot reactive canvas in scene while they have not be deasactivated.");
				else return; // skip the error if it's the first Hide
			}

			foreach (Canvas canvas in _deactivatedCanvases)
			{
				canvas.gameObject.SetActive(active);
			}

			bool IsCanvasIgnored(Canvas canvas)
			{
				return Array.Exists(canvasesToIgnore, x => x == canvas) == false;
			}
		}
	}
}
