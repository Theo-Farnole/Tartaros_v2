namespace Tartaros.UI.Alpha
{
	using Sirenix.OdinInspector;
	using Tartaros.Selection;
	using UnityEngine;

	public class AlphaSelectionUI : SerializedMonoBehaviour
	{
		#region Fields
		[SerializeField]
		private ISelection _selection = null;

		[SerializeField]
		private RectOffset _margin = new RectOffset();
		#endregion Fields

		#region Properties
		private GUIStyle BackgroundStyle => new GUIStyle(GUI.skin.box)
		{
			margin = _margin
		};
		private GUIStyle MarginStyle => new GUIStyle { margin = _margin };
		private GUIStyle MenuTitleStyle => new GUIStyle(GUI.skin.label) { alignment = TextAnchor.MiddleCenter };
		#endregion Properties

		#region Methods
		private void OnGUI()
		{
			if (_selection == null) return;
			if (_selection.SelectedSelectables.Length == 0) return;

			BeginArea();
			{
				GUILayout.Label("<b>Selection</b>");

				foreach (ISelectable selected in _selection.SelectedSelectables)
				{
					GUILayout.Label(selected.GameObject.name);
				}
			}
			EndArea();
		}

		private void BeginArea()
		{
			// This first vertical group is only used to have a margin
			GUILayout.BeginVertical(MarginStyle);

			// This second vertical group set the background style
			GUILayout.BeginVertical(BackgroundStyle);
		}

		private static void EndArea()
		{
			GUILayout.EndVertical();

			GUILayout.EndVertical();
		}
		#endregion Methods
	}
}