namespace Tartaros.Gamemode.State
{
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using Tartaros.Powers;
	using Tartaros.Economy;
	using UnityEngine;
	using UnityEngine.InputSystem;
	using Tartaros.ServicesLocator;

	public class PowerState : AGameState
	{
		private readonly IPower _power = null;
		private readonly PowerInputs _inputs = null;
		private readonly PowerPreview _preview = null;
		private readonly IPlayerGloryWallet _playerGloryWallet = null;

		public PowerState(GamemodeManager gamemodeManager, IPower power) : base(gamemodeManager)
		{
			_power = power;

			_inputs = new PowerInputs();
			_preview = new PowerPreview(power.Range, _inputs.GetMousePosition());

			_playerGloryWallet = Services.Instance.Get<IPlayerGloryWallet>();
		}

		public override void OnStateEnter()
		{
			base.OnStateEnter();

            _stateOwner.InvokePowerStateEnable(this);

			_inputs.ValidatePerformed -= ValidatePerformed;
			_inputs.ValidatePerformed += ValidatePerformed;

			_inputs.LeavePerformed -= LeavePerformed;
			_inputs.LeavePerformed += LeavePerformed;
		}

		private void LeavePerformed(InputAction.CallbackContext obj)
		{
			LeaveState();
		}

		private void ValidatePerformed(InputAction.CallbackContext obj)
		{
			if (CanCastHere())
			{
				CastSpell();
			}
		}

		public override void OnUpdate()
		{
			base.OnUpdate();

			SetPreviewPosition();
		}

		public override void OnStateExit()
		{
			base.OnStateExit();

			_inputs.ValidatePerformed -= ValidatePerformed;
		}

		private bool CanCastHere()
		{
			//return true;
			return _playerGloryWallet.CanSpend(_power.Price);
		}

		private void SetPreviewPosition()
		{
			_preview.SetPreviewPosition(_inputs.GetMousePosition());
		}

		private void CastSpell()
		{
			GameObject powerInstanciate = GameObject.Instantiate(_power.PrefabPower, _inputs.GetMousePosition() + new Vector3(0, 0.1f, 0), Quaternion.identity);
			_playerGloryWallet.Spend(_power.Price);
			_preview.DestroyMethods();
			_stateOwner.SetState(new PlayState(_stateOwner));
		}
	}
}