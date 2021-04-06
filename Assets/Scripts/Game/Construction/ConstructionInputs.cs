namespace Tartaros.Construction
{
    using System;
    using System.Collections;
    using UnityEngine;
    using UnityEngine.InputSystem;
    using static UnityEngine.InputSystem.InputAction;

    public class ConstructionInputs
    {

        private IMousePosition _mousePosition = null;
        private GameInputs _input = null;

        public event Action<CallbackContext> ValidatePerformed
        {
            add
            {
                _input.Construction.ValidateConstruction.performed += value;
            }

            remove
            {
                _input.Construction.ValidateConstruction.performed -= value;
            }
        }

        public event Action<CallbackContext> CrtlPerformed
        {
            add
            {
                _input.Construction.AddNewWallSections.performed += value;
            }

            remove
            {
                _input.Construction.AddNewWallSections.performed -= value;
            }
        }

        public event Action<CallbackContext> LeavePerformed
        {
            add
            {
                _input.Construction.ExitConstruction.performed += value;
            }

            remove
            {
                _input.Construction.ExitConstruction.performed -= value;
            }
        }
        public ConstructionInputs()
        {
            _input = new GameInputs();
            _input.Construction.Enable();
            _mousePosition = new SetMousePositionWithPlane();
        }

        public Vector3 GetMousePosition()
        {
            return _mousePosition.GetPreviewPosition();
        }

        public bool IsCtrlPerformed()
        {
            return _input.Construction.AddNewWallSections.phase == InputActionPhase.Performed;
        }

        public bool IsValidatePerformed()
        {
            return _input.Construction.ValidateConstruction.phase == InputActionPhase.Performed;
        }

        public bool IsLeavePerformed()
        {
            return _input.Construction.ExitConstruction.phase == InputActionPhase.Performed;
        }
    }
}