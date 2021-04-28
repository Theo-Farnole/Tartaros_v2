namespace Tartaros.Gamemode
{
	using System;
	using Tartaros.ServicesLocator;

	using UnityEngine;

	public class GamemodeManager : MonoBehaviour
	{
		private GamemodeFSM _gamemodeFSM = null;

		public AState<GamemodeManager> CurrentState => _gamemodeFSM.CurrentState;


		public class ConstructionStateEnableArgs : EventArgs { }
		public event EventHandler<ConstructionStateEnableArgs> ConstructionStateEnable;

		public class DefaultStateEnableArgs : EventArgs { }
		public event EventHandler<DefaultStateEnableArgs> DefaultStateEnable;

		public class PowerStateEnableArgs : EventArgs { }
		public event EventHandler<PowerStateEnableArgs> PowerStateEnable;

		public class OrdersStateEnableArgs : EventArgs { }
		public event EventHandler<OrdersStateEnableArgs> OrdersStateEnable;

		public void InvokeConstructionStateEnable()
		{
			ConstructionStateEnable?.Invoke(this, new ConstructionStateEnableArgs());
		}

		public void InvokeDefaultStateEnable()
		{
			DefaultStateEnable?.Invoke(this, new DefaultStateEnableArgs());
		}

		public void InvokePowerStateEnable()
		{
			PowerStateEnable?.Invoke(this, new PowerStateEnableArgs());
		}

		public void InvokeOrdersStateEnable()
		{
			OrdersStateEnable?.Invoke(this, new OrdersStateEnableArgs());
		}

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