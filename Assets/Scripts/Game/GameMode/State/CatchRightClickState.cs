namespace Tartaros.Gamemode
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using Tartaros.OrderGiver;
	using Tartaros.ServicesLocator;
	
	using UnityEngine.InputSystem;

	public class CatchRightClickState : AGameState
	{
		private GameInputs _gameInputs = null;
		private Action _rightClickAction = null;
		private SelectionOrderGiverInput _selectionOrderGiverInput = null;

		public CatchRightClickState(GamemodeManager stateOwner, Action rightClickAction) : base(stateOwner)
		{
			_gameInputs = new GameInputs();
			_gameInputs.Orders.RightClick.Enable();

			_rightClickAction = rightClickAction;

			_selectionOrderGiverInput = Services.Instance.Get<SelectionOrderGiverInput>();
		}

		public override void OnStateEnter()
		{
			base.OnStateEnter();

			_stateOwner.InvokeOrdersStateEnable();

			_selectionOrderGiverInput.enabled = false;

			_gameInputs.Orders.RightClick.performed -= RightClick;
			_gameInputs.Orders.RightClick.performed += RightClick;
		}

		public override void OnStateExit()
		{
			base.OnStateExit();

			_selectionOrderGiverInput.enabled = true;

			_gameInputs.Orders.RightClick.performed -= RightClick;
		}

		private void RightClick(InputAction.CallbackContext obj)
		{
			_rightClickAction.Invoke();

			// right click action can modify the current state, so we only want to leave the state if current state has changed
			if (_stateOwner.CurrentState == this)
			{
				LeaveState();
			}
		}
	}
}
