namespace Tartaros
{
	using System;
	using System.Linq;
	using Tartaros.UI;
	using UnityEngine;

	public static class CanvasHelper
	{
		private static APanel[] _desactivatedPanels = null;

		public static void HideAllMenus(params APanel[] panelsToIgnore)
		{
			var panels = UnityEngine.Object.FindObjectsOfType<APanel>()
					.Where(x => IsCanvasIgnored(x) && x.IsShow)
					.ToArray();

			// check for errors
			if (panels.Length == 0)
			{
				Debug.LogWarning("Trying to active all canvas in the scene while they are all deactivated or there is no canvas. Method aborted");
				return;
			}

			// when canvas are desactivated, FindObjectsOfType doesn't work
			// so we must register them in a field
			_desactivatedPanels = panels;

			foreach (var panel in panels)
			{
				panel.Hide();
			}


			bool IsCanvasIgnored(APanel panel)
			{
				return Array.Exists(panelsToIgnore, x => x == panel) == false;
			}
		}

		public static void ShowAllMenus()
		{
			// check for errors
			if (_desactivatedPanels == null)
			{
				if (Time.timeSinceLevelLoad > 0) throw new System.NotSupportedException("Cannot reactive canvas in scene while they have not be deasactivated.");
				else return; // skip the error if it's the first Hide
			}

			foreach (var panel in _desactivatedPanels)
			{
				panel.Show();
			}
		}
	}
}
