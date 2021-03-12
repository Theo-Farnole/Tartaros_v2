using System.Collections;
using UnityEngine;
using Tartaros.Gamemode;
using Tartaros.Economy;
using Tartaros.Gamemode.State;

namespace Tartaros.Construction
{
    public class ConstructionStateV2 : AGameState
    {


        private BuildingPreview _buildingPreview = null;
        private ConstructionInputs _constructionInput = null;
        private bool _shouldRefund = true;
        private Price _price = null;
        private IConstructable _constructable = null;

        public ConstructionStateV2(GamemodeManager gamemodeManager, Price price, IConstructable constructable) : base(gamemodeManager)
        {
            _price = price;
            _constructable = constructable;

            _constructionInput = new ConstructionInputs();

            _buildingPreview = new BuildingPreview(_constructable, _constructionInput.GetPreviewPosition());

        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            _buildingPreview.SetBuildingPreviewPosition(_constructionInput.GetPreviewPosition());

            if (_constructionInput.IsValidatePerformed())
            {
                Validate();
            }

            if (_constructionInput.IsLeaveAndRefundPerformed())
            {
                LeaveAndRefund();
            }
        }
        public override void OnStateExit()
        {
            base.OnStateExit();

            _buildingPreview.DestroyMethod();
        }

        void Validate()
        {
            _shouldRefund = false;
            InstanciateBuilding();
            LeaveState();
        }

        private void InstanciateBuilding()
        {
            GameObject buildingConstruct = GameObject.Instantiate(_constructable.ModelPrefab, _buildingPreview.GetBuildingPreviewPosition(), Quaternion.identity);
        }

        void LeaveAndRefund()
        {
            _shouldRefund = true;
            LeaveState();
        }

        void LeaveState()
        {
            _stateOwner.SetState(new PlayState(_stateOwner));
        }
    }
}