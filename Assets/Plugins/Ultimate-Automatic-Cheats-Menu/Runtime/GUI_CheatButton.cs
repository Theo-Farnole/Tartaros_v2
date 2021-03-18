namespace TF.CheatsGUI
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Reflection;
	using UnityEngine;

	internal class GUI_CheatButton
	{
		#region Fields
		private static readonly Type[] SUPPORTED_PARAMETER_TYPE = new Type[] { typeof(int), typeof(float), typeof(string), typeof(bool) };
		private readonly MethodInfo _methodInfo = null;
		private readonly CheatMethodAttribute _cheatMethodAttribute = null;

		private bool _enabled = true;
		private string _overridedButtonLabel = null;

		private Dictionary<ParameterInfo, object> _parametersValues = null;
		#endregion

		#region Properties
		public bool Enabled
		{
			get => _enabled;
			set
			{
				if (DoMethodInfoHasUnsupportedParametersType(_methodInfo, SUPPORTED_PARAMETER_TYPE))
				{
					Debug.LogWarningFormat("You can't force enabling of button '{0}' because drawing methods with parameters is not supported.", ButtonLabel);
					_enabled = false;

					return;
				}

				if (_methodInfo.IsStatic == false)
				{
					Debug.LogWarningFormat("You can't force enabling of button {1} because method '{0}' must be static to displayed.", _methodInfo.Name, ButtonLabel);
					_enabled = false;

					return;
				}

				_enabled = value;
			}
		}

		public string ButtonLabel
		{
			get => _overridedButtonLabel ?? _methodInfo.Name;
			set => _overridedButtonLabel = value;
		}
		#endregion

		#region ctor
		public GUI_CheatButton(MethodInfo methodInfo, CheatMethodAttribute cheatMethodAttribute)
		{
			_methodInfo = methodInfo ?? throw new ArgumentNullException();
			_cheatMethodAttribute = cheatMethodAttribute ?? throw new ArgumentNullException();

			if (_cheatMethodAttribute.OverridedButtonLabel != null)
			{
				_overridedButtonLabel = _cheatMethodAttribute.OverridedButtonLabel;
			}

			if (DoMethodInfoHasUnsupportedParametersType(_methodInfo, SUPPORTED_PARAMETER_TYPE))
			{
				Debug.LogWarningFormat("Button for method '{0}' will not be drawn: attribute 'CheatMethod' doesn't support method with parameters.", _methodInfo.Name);
				_enabled = false;
			}

			if (_methodInfo.IsStatic == false)
			{
				Debug.LogWarningFormat("Method '{0}' must be static to displayed.", _methodInfo.Name);
				_enabled = false;
			}

			InitializeParametersValues();
		}
		#endregion

		#region Methods
		public void Draw(params GUILayoutOption[] options)
		{
			UpdateEnabledState();

			if (_enabled == false)
				return;

			bool clickedOnButton;

			GUILayout.BeginHorizontal();
			{
				clickedOnButton = GUILayout.Button(ButtonLabel, options);
				DrawParameters();
			}
			GUILayout.EndHorizontal();

			if (clickedOnButton)
			{
				Apply(_parametersValues.Values.ToArray());
			}

			void DrawParameters()
			{
				ParameterInfo[] dictionaryKeys = _parametersValues.Keys.ToArray();

				GUILayout.BeginVertical();
				for (int i = 0, length = dictionaryKeys.Length; i < length; i++)
				{
					ParameterInfo key = dictionaryKeys[i];

					if (_parametersValues[key] == null)
					{
						Debug.LogErrorFormat("Parameter {0}'s type isn't supported. Button's parameter'll not be draw.", key.Name);
						return;
					}

					string output;
					GUILayout.BeginHorizontal();
					{

						GUILayout.Label(key.Name, GUILayout.Width(50));
						GUILayout.Space(10);
						output = GUILayout.TextField(_parametersValues[key].ToString(), GUILayout.Width(100));

						//GUILayout.FlexibleSpace();
					}
					GUILayout.EndHorizontal();

					if (key.ParameterType == typeof(int))
					{
						if (int.TryParse(output, out int result))
							_parametersValues[key] = result;
						else
						{
							// TODO TF: log error
						}
					}
					else if (key.ParameterType == typeof(float))
					{
						if (float.TryParse(output, out float result))
							_parametersValues[key] = result;
						else
						{
							// TODO TF: log error
						}
					}
					else if (key.ParameterType == typeof(bool))
					{
						if (bool.TryParse(output, out bool result))
							_parametersValues[key] = result;
						else
						{
							// TODO TF: log error
						}
					}
					else if (key.ParameterType == typeof(string))
					{
						_parametersValues[key] = output;
					}
					else
					{
						Debug.LogError("Key parameter is unsupported");
					}
				}
				GUILayout.EndVertical();

			}
		}

		private void Apply(params object[] parameters)
		{
			_methodInfo.Invoke(null, parameters);
		}

		private void UpdateEnabledState()
		{
			if (_cheatMethodAttribute.ShowIfExpressionIsTrue == null)
				return;

			_enabled = AttributeExpressionHelper.IsExpressionTrue(_cheatMethodAttribute.ShowIfExpressionIsTrue, _methodInfo.DeclaringType);
		}

		private bool DoMethodInfoHasUnsupportedParametersType(MethodInfo methodInfo, Type[] supportedParametersType)
		{
			ParameterInfo[] parameterInfo = methodInfo.GetParameters();

			int supportedParametersTypeCount = parameterInfo
				.Select(x => x.ParameterType)
				.Where(x => supportedParametersType.Contains(x))
				.Count();

			return parameterInfo.Length != supportedParametersTypeCount;
		}

		private void InitializeParametersValues()
		{
			_parametersValues = new Dictionary<ParameterInfo, object>();

			ParameterInfo[] parameters = _methodInfo.GetParameters();

			for (int i = 0, length = parameters.Length; i < length; i++)
			{
				object defaultValue;

				if (parameters[i].ParameterType == typeof(int)) defaultValue = 0;
				else if (parameters[i].ParameterType == typeof(float)) defaultValue = 0.0f;
				else if (parameters[i].ParameterType == typeof(bool)) defaultValue = true;
				else if (parameters[i].ParameterType == typeof(string)) defaultValue = "";
				else
				{
					Debug.LogWarningFormat("Parameter of type {0} is not supported. (method {1} with label {2})", parameters[i].ParameterType, _methodInfo.Name, ButtonLabel);
					defaultValue = null;
				}

				_parametersValues.Add(parameters[i], defaultValue);
			}
		}
		#endregion
	}
}
