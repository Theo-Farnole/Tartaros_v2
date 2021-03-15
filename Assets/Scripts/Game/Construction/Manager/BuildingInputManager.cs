namespace Tartaros.Construction
{
    using System.Collections;
    using UnityEngine;
    using Tartaros.Construction;
    using UnityEngine.InputSystem;

    public class BuildingInputManager : MonoBehaviour, IBuildingInputManager
    {
        #region Fields
        private GameInputs _input = null;
        #endregion

        #region Methods
        private void OnEnable()
        {
            _input = new GameInputs();
            _input.Construction.Enable();
        }
        bool IBuildingInputManager.CheckConstruct()
        {
            if (_input.Construction.ValidateConstruction.phase == InputActionPhase.Performed)
                return true;
            else
                return false;
        }

        bool IBuildingInputManager.CheckEnterConstructionMode()
        {
            if (_input.Construction.EnterConstruction.phase == InputActionPhase.Performed)
                return true;
            else
                return false;
        }

        bool IBuildingInputManager.CheckLeaveWithoutConstruct()
        {
            if (_input.Construction.ExitConstruction.phase == InputActionPhase.Performed)
                return true;
            else
                return false;
        } 
        #endregion
    }
}