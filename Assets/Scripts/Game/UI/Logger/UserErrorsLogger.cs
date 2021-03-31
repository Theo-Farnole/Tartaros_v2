namespace Tartaros
{
	using System.Collections.Generic;
	using System.Linq;
	using Tartaros.ServicesLocator;
	using UnityEngine;

	public class UserErrorsLogger : MonoBehaviour
	{
		#region Class
		private class Error
		{
			public string message = null;
			public float destroyTimeInSeconds = -1f;

			public Error(string message, float lifetimeInSeconds)
			{
				this.message = message;
				destroyTimeInSeconds = Time.time + lifetimeInSeconds;
			}

			public bool ShouldBeDestroy()
			{
				return Time.time > destroyTimeInSeconds;
			}
		}
		#endregion Class

		#region Fields
		[SerializeField]
		private float _messageDurationInSeconds = 3;

		[SerializeField]
		private bool _alsoDebugInConsole = true;

		[ShowInRuntime]
		private List<Error> _errors = new List<Error>();
		#endregion Fields

		#region Properties
		private GUIStyle MarginStyle => new GUIStyle { margin = new RectOffset(20, 20, 20, 20) };
		#endregion Properties

		#region Methods
		private void Awake()
		{
			Services.Instance.RegisterService(this);
		}

		private void Update()
		{
			RemoveOldErrors();
		}

		private void OnGUI()
		{
			GUILayout.BeginVertical(MarginStyle);
			{
				foreach (var error in _errors)
				{
					DrawError(error);
				}
			}
			GUILayout.EndVertical();
		}

		private void DrawError(Error error)
		{
			GUILayout.Label(error.message);
		}

		private void RemoveOldErrors()
		{
			_errors = _errors
				.Where(x => x.ShouldBeDestroy() == false)
				.ToList();
		}

		public void Log(string text, params object[] args)
		{
			var message = string.Format(text, args);
			var error = new Error(message, _messageDurationInSeconds);
			_errors.Add(error);

			if (_alsoDebugInConsole == true)
			{
				Debug.Log(message);
			}
		}
		#endregion Methods
	}
}
