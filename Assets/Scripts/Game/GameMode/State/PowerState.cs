namespace Tartaros.Gamemode.State
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Tartaros.Power;
    using UnityEngine;
    using UnityEngine.InputSystem;

    public class PowerState : AGameState
    {
        private IPower _power = null;
        private PowerInputs _inputs = null;
        private PowerPreview _preview = null;

        public PowerState(GamemodeManager gamemodeManager, IPower power) : base(gamemodeManager)
        {
            _power = power;

            _inputs = new PowerInputs();
            _preview = new PowerPreview(power.range, _inputs.GetMousePosition());
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();

            _inputs.ValidatePerformed -= _inputs_ValidatePerformed;
            _inputs.ValidatePerformed += _inputs_ValidatePerformed;
        }

        private void _inputs_ValidatePerformed(InputAction.CallbackContext obj)
        {
            if (CanCastHere())
            {
                Validate();
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

        private void Validate()
        {
            CastSpell();
        }

        private bool CanCastHere()
        {
            return true;
            //throw new System.NotImplementedException();
        }

        private void SetPreviewRange()
        {
            _preview.SetPreviewPosition(_inputs.GetMousePosition());
        }

        private void CastSpell()
        {

            GameObject powerInstanciate = GameObject.Instantiate(_power.prefabPower, _inputs.GetMousePosition(), Quaternion.identity);

            //throw new System.NotImplementedException();
        }
    }
}