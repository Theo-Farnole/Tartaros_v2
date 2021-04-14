namespace Tartaros
{
	public class GenericFSM<T>
	{
		#region Fields
		private AState<T> _currentState = null;
		#endregion Fields

		#region Properties	
		[ShowInRuntime]
		public AState<T> CurrentState
		{
			get => _currentState;

			set
			{
				if (_currentState != null)
				{
					_currentState.OnStateExit();
				}

				_currentState = value;

				if (_currentState != null)
				{
					_currentState.OnStateEnter();
				}
			}
		}

		[ShowInRuntime]
#pragma warning disable IDE0051 // Remove unused private members
		private string CurrentStateType => CurrentState?.GetType().Name ?? "No state";
#pragma warning restore IDE0051 // Remove unused private members
		#endregion Properties

		#region Methods
		/// <summary>
		/// Must be called by a MonoBehaviour in Update
		/// </summary>
		public void OnUpdate()
		{
			if (_currentState != null)
			{
				_currentState.OnUpdate();
			}
		}
		#endregion Methods
	}
}