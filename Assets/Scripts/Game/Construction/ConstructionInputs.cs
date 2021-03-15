using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Tartaros.Construction
{
    public class ConstructionInputs 
    {

        private IBuildingPreviewPosition _buildingPreviewPosition = null;
        private GameInputs _input = null;

        public ConstructionInputs()
        {
            _input = new GameInputs();
            _input.Construction.Enable();
            _buildingPreviewPosition = new SetBuildingPreviewPositionWithPlane();
        }

        public Vector3 GetPreviewPosition()
        {
            return _buildingPreviewPosition.GetPreviewPosition();
        }

        public bool IsValidatePerformed()
        {
            return _input.Construction.ValidateConstruction.phase == InputActionPhase.Performed;
        }

        public bool IsLeaveAndRefundPerformed()
        {
            return _input.Construction.ExitConstruction.phase == InputActionPhase.Performed;
        }
    }
}