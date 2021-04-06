namespace Tartaros.Gamemode.State
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
        private IPower _power = null;
        private PowerInputs _inputs = null;
        private PowerPreview _preview = null;
        private IPlayerGloryWallet _playerGloryWallet = null;

        public PowerState(GamemodeManager gamemodeManager, IPower power) : base(gamemodeManager)
        {
            _power = power;

            _inputs = new PowerInputs();
            _preview = new PowerPreview(power.Range, _inputs.GetMousePosition());
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();

            _inputs.ValidatePerformed -= _inputs_ValidatePerformed;
            _inputs.ValidatePerformed += _inputs_ValidatePerformed;

            _playerGloryWallet = Services.Instance.Get<IPlayerGloryWallet>();
        }

        private void _inputs_ValidatePerformed(InputAction.CallbackContext obj)
        {
            if (CanCastHere())
            {
                CastSpell();
            }
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            SetPreviewRange();
        }

        public override void OnStateExit()
        {
            base.OnStateExit();

            _inputs.ValidatePerformed -= _inputs_ValidatePerformed;
        }

        private bool CanCastHere()
        {
            //return true;
            return _playerGloryWallet.CanSpend(_power.Price);
        }

        private void SetPreviewRange()
        {
            _preview.SetPreviewPosition(_inputs.GetMousePosition());
        }

        private void CastSpell()
        {
            GameObject powerInstanciate = GameObject.Instantiate(_power.PrefabPower, _inputs.GetMousePosition(), Quaternion.identity);
            Debug.Log(_power.Price);
            _playerGloryWallet.Spend(_power.Price);
            _preview.DestroyMethods();
            _stateOwner.SetState(new PlayState(_stateOwner));
        }
    }
}