namespace TF.CheatsGUI
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Reflection;
	using TF.CheatsGUI.Utilities;
	using UnityEngine;
	using UnityEngine.InputSystem;

	[AddComponentMenu("Cheats/CheatsMenu")]
	internal class CheatsMenu : MonoBehaviour
	{
		#region Fields
		public const string DEBUG_LOG_HEADER = "<color=cyan>Cheats GUI</color> :";
		private const string MENU_TITLE = "Cheats Menu";

		[SerializeField] private Key _toggleCheatMenu = Key.C;
		[Header("GUI SETTINGS")]
		[SerializeField] private RectOffset _margin = new RectOffset();

		[SerializeField]
		private bool _restrictToSomeAssemblies = false;

		[SerializeField]
		private string[] _restrictedAssemblies = new string[0];

		private bool _isCheatsMenuOpen = false;
		private GUI_CheatButton[] _cheatsButton = null;
		private Vector2 _scrollPosition = Vector2.zero;
		#endregion

		#region Properties
		private GUIStyle BackgroundStyle => new GUIStyle(GUI.skin.box)
		{
			margin = _margin
		};
		private GUIStyle MarginStyle => new GUIStyle { margin = _margin };
		private GUIStyle MenuTitleStyle => new GUIStyle(GUI.skin.label) { alignment = TextAnchor.MiddleCenter };
		#endregion

		#region Methods
		#region MonoBehaviour Callbacks
		private void Update()
		{
			HandleToggleCheatsMenuInputs();
		}

		private void OnGUI()
		{
			if (!_isCheatsMenuOpen)
				return;

			if (_cheatsButton == null)
				SetCheatsButton();

			// This first vertical group is only used to have a margin
			GUILayout.BeginVertical(MarginStyle);
			{
				//	// This second vertical group set the background style
				GUILayout.BeginVertical(BackgroundStyle);
				{
					_scrollPosition = GUILayout.BeginScrollView(_scrollPosition, false, false, GUIStyle.none, GUI.skin.verticalScrollbar, GUILayout.ExpandWidth(true));
					{
						GUILayout.BeginVertical();
						{
							GUILayout.Label(MENU_TITLE, MenuTitleStyle);

							if (_cheatsButton.Length == 0)
							{
								GUILayout.Label("No cheats found.");
							}
							else
							{
								int buttonWidth = GetLongestButtonWidth();

								for (int i = 0, length = _cheatsButton.Length; i < length; i++)
								{
									_cheatsButton[i].Draw(GUILayout.Width(buttonWidth));
								}
							}
						}
						GUILayout.EndVertical();
					}
					GUILayout.EndScrollView();
				}
				GUILayout.EndVertical();
			}
			GUILayout.EndVertical();
		}
		#endregion

		#region Public Methods
		public void ToggleCheatsMenu()
		{
			if (_isCheatsMenuOpen) CloseCheatsMenu();
			else OpenCheatMenu();
		}

		public void OpenCheatMenu() => _isCheatsMenuOpen = true;

		public void CloseCheatsMenu() => _isCheatsMenuOpen = false;
		#endregion

		#region Private Methods
		private void SetCheatsButton()
		{
			IEnumerable<Type> typesWithAttributes;

			if (_restrictToSomeAssemblies == true)
			{
				typesWithAttributes = ReflectionHelper.GetTypesWithAttribute<CheatAttribute>(_restrictedAssemblies);
			}
			else
			{
				typesWithAttributes = ReflectionHelper.GetTypesWithAttribute<CheatAttribute>();
			}

			List<GUI_CheatButton> cheatsButton = new List<GUI_CheatButton>();

			foreach (Type type in typesWithAttributes)
			{
				foreach (MethodInfo method in ReflectionHelper.GetMethodsWithAttribute(type, typeof(CheatAttribute)))
				{
					cheatsButton.Add(new GUI_CheatButton(method, method.GetCustomAttribute<CheatAttribute>()));
				}
			}

			_cheatsButton = cheatsButton.ToArray();
		}

		private void HandleToggleCheatsMenuInputs()
		{
			if (AreKeysToToggleCheatsMenuAreDown() == true)
			{
				ToggleCheatsMenu();
			}
		}

		private bool AreKeysToToggleCheatsMenuAreDown()
		{
			return Keyboard.current.shiftKey.isPressed == true && Keyboard.current[_toggleCheatMenu].wasPressedThisFrame;
		}

		private int GetEnabledButtonsCount() => _cheatsButton.Where(x => x.Enabled).Count();

		private int GetLongestButtonWidth() => (int)GUI.skin.button.CalcSize(new GUIContent(GetLongestButtonLabel())).x;

		private string GetLongestButtonLabel() => _cheatsButton.OrderByDescending(x => x.ButtonLabel.Length).Select(x => x.ButtonLabel).FirstOrDefault();
		#endregion
		#endregion
	}
}
