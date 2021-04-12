﻿namespace Tartaros.Gamemode.State
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Tartaros.Power;
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

            _inputs.ValidatePerformed -= ValidatePerformed;
            _inputs.ValidatePerformed += ValidatePerformed;

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
            GameObject powerInstanciate = GameObject.Instantiate(_power.PrefabPower, _inputs.GetMousePosition(), Quaternion.identity);
            Debug.LogFormat("Spend {0}.", _power.Price);
            _playerGloryWallet.Spend(_power.Price);
            _preview.DestroyMethods();
            _stateOwner.SetState(new PlayState(_stateOwner));
        }
    }
}