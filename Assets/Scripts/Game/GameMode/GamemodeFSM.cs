namespace Tartaros.Gamemode
{
	using Tartaros.Utilities;

	public class GamemodeFSM : GenericFSM<GamemodeManager>
	{
		#region Fields
		private GenericFSM<GamemodeManager> _finiteStateMachine = new GenericFSM<GamemodeManager>();
		private AGameState _currentState = null;
		#endregion Fields

		#region Methods		
		private void Update()
		{
			if (_finiteStateMachine != null)
			{
				_finiteStateMachine.OnUpdate();
			}
		}

		public void SetState(AGameState newState)
		{
			_finiteStateMachine.CurrentState = newState;
			_currentState = newState;
		}
		#endregion Methods
	}
}