namespace Tartaros.Gamemode
{
	using Tartaros.ServicesLocator;
	
	using UnityEngine;

	public class GamemodeManager : MonoBehaviour
	{		
		private GamemodeFSM _gamemodeFSM = null;

		public AState<GamemodeManager> CurrentState => _gamemodeFSM.CurrentState;

		private void Awake()
		{			
			_gamemodeFSM = new GamemodeFSM();
		}

		public void SetState(AGameState _state)
		{
			_gamemodeFSM.CurrentState = _state;
		}

		private void Update()
		{
			_gamemodeFSM.OnUpdate();
		}
	}
}