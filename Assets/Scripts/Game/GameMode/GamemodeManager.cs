namespace Tartaros.Gamemode
{
	using Tartaros.ServicesLocator;
	using Tartaros.Utilities;
	using UnityEngine;

	public class GamemodeManager : MonoBehaviour
	{		
		private GamemodeFSM _gamemodeFSM = null;

		private void Awake()
		{
			Services.Instance.RegisterService(this);
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