namespace Tartaros.Utilities
{
	public class GenericFSM<T>
	{
		#region Fields
		private AState<T> _currentState = null;
		#endregion Fields

		#region Properties
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