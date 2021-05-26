namespace Tartaros.Gamemode
{
	using System;
	using Tartaros.Construction;
	using Tartaros.Gamemode.State;
	using Tartaros.Orders;
	using Tartaros.ServicesLocator;

	using UnityEngine;
	using UnityEngine.Playables;

	public class GamemodeManager : MonoBehaviour
	{
		[ShowInRuntime] private GamemodeFSM _gamemodeFSM = null;

		public AState<GamemodeManager> CurrentState => _gamemodeFSM.CurrentState;


		public class ConstructionStateEnableArgs : EventArgs 
		{
			public readonly ConstructionState constructionState;
			public readonly WallConstructionState wallConstructionState;

			public ConstructionStateEnableArgs(ConstructionState constructionState, WallConstructionState wallState)
			{
				this.constructionState = constructionState;
				this.wallConstructionState = wallState;
			}
		}
		public event EventHandler<ConstructionStateEnableArgs> ConstructionStateEnable;

		public class DefaultStateEnableArgs : EventArgs 
		{
			public readonly State.PlayState defaultState;

			public DefaultStateEnableArgs(State.PlayState defaultState)
			{
				this.defaultState = defaultState;
			}
		}
		public event EventHandler<DefaultStateEnableArgs> DefaultStateEnable;

		public class PowerStateEnableArgs : EventArgs 
		{
			public readonly PowerState powerState;

			public PowerStateEnableArgs(PowerState powerState)
			{
				this.powerState = powerState;
			}
		}
		public event EventHandler<PowerStateEnableArgs> PowerStateEnable;

		public class OrdersStateEnableArgs : EventArgs 
		{
			public readonly CatchRightClickState ordersState;
			public readonly Order currentOrder;

			public OrdersStateEnableArgs(CatchRightClickState ordersState, Order currentOrder)
			{
				this.ordersState = ordersState;
				this.currentOrder = currentOrder;
			}
		}
		public event EventHandler<OrdersStateEnableArgs> OrdersStateEnable;

		public void InvokeConstructionStateEnable(ConstructionState currentState, WallConstructionState wallState)
		{
			ConstructionStateEnable?.Invoke(this, new ConstructionStateEnableArgs(currentState, wallState));
		}

		public void InvokeDefaultStateEnable(State.PlayState currentState)
		{
			DefaultStateEnable?.Invoke(this, new DefaultStateEnableArgs(currentState));
		}

		public void InvokePowerStateEnable(PowerState currentState)
		{
			PowerStateEnable?.Invoke(this, new PowerStateEnableArgs(currentState));
		}

		public void InvokeOrdersStateEnable(CatchRightClickState currentState, Order currentOrder)
		{
			OrdersStateEnable?.Invoke(this, new OrdersStateEnableArgs(currentState, currentOrder));
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