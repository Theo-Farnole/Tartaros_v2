namespace Tartaros.Animation
{
	using UnityEngine;

	public class ParameterDebugUI : MonoBehaviour
	{
		public const int BUTTON_SIZE = 60;
		public const int TEXT_FIELD_SIZE = 180;

		[SerializeField] private Animator[] _animators = new Animator[0];

		[SerializeField] private string _booleanParameterName = string.Empty;
		[SerializeField] private string _triggerParameterName = string.Empty;


		private void OnGUI()
		{
			GUILayout.BeginVertical(new GUIStyle(GUI.skin.box));
			{
				DrawBooleanGUI();
				DrawTriggerGUI();
			}
			GUILayout.EndVertical();
		}

		private void DrawTriggerGUI()
		{
			GUILayout.BeginHorizontal();
			{
				GUILayout.Label("Trigger");
				_triggerParameterName = GUILayout.TextField(_triggerParameterName, GUILayout.Width(TEXT_FIELD_SIZE));

				if (GUILayout.Button("Trigger", GUILayout.Width(BUTTON_SIZE)))
				{
					foreach (var animator in _animators)
					{
						animator.SetTrigger(_triggerParameterName);
					}
				}
			}
			GUILayout.EndHorizontal();
		}

		private void DrawBooleanGUI()
		{
			GUILayout.BeginHorizontal();
			{
				GUILayout.Label("Boolean");
				_booleanParameterName = GUILayout.TextField(_booleanParameterName, GUILayout.Width(TEXT_FIELD_SIZE));

				if (GUILayout.Button("Active", GUILayout.Width(BUTTON_SIZE)))
				{
					SetBool(_booleanParameterName, true);
				}

				if (GUILayout.Button("Disable", GUILayout.Width(BUTTON_SIZE)))
				{
					SetBool(_booleanParameterName, false);
				}
			}
			GUILayout.EndHorizontal();
		}

		private void SetBool(string name, bool value)
		{
			foreach (var animator in _animators)
			{
				animator.SetBool(name, value);
			}
		}
	}

}