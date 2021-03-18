
namespace Tartaros.Construction
{
    using System.Collections;
    using UnityEngine;
    using Tartaros.Gamemode;
    using Tartaros.Economy;
    using Tartaros.Gamemode.State;
    using Tartaros.ServicesLocator;
    using Tartaros.Sectors;

    public class ConstructionStateV2 : AGameState
    {
        private BuildingPreview _buildingPreview = null;
        private ConstructionInputs _constructionInput = null;
        private IConstructable _constructable = null;
        private IPlayerSectorResources _playerSectorRessources = null;
        private ICheckCanConstruct _CheckCanConstruct = null;

        public ConstructionStateV2(GamemodeManager gamemodeManager, IConstructable constructable) : base(gamemodeManager)
        {
            _constructable = constructable;
            _constructionInput = new ConstructionInputs();
            _buildingPreview = new BuildingPreview(_constructable, _constructionInput.GetPreviewPosition());
            _playerSectorRessources = Services.Instance.Get<IPlayerSectorResources>();
            _CheckCanConstruct = Services.Instance.Get<ICheckCanConstruct>();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();

            _buildingPreview.SetBuildingPreviewPosition(_constructionInput.GetPreviewPosition());

            if (_constructionInput.IsValidatePerformed())
            {
                if (CanConstructHere())
                {
                    Validate();
                }
            }
        }
        public override void OnStateExit()
        {
            base.OnStateExit();

            _buildingPreview.DestroyMethod();
        }

        void Validate()
        {
            InstanciateBuilding();
            PayPriceRessources();
            LeaveState();
        }

        bool CanConstructHere()
        {
            if (_CheckCanConstruct.IsNotOnABuilding(_buildingPreview.GetBuildingPreviewPosition(), _constructionInput.GetPreviewPosition()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void InstanciateBuilding()
        {
            GameObject buildingConstruct = GameObject.Instantiate(_constructable.ModelPrefab, _buildingPreview.GetBuildingPreviewPosition(), Quaternion.identity);
        }

        private void PayPriceRessources()
        {
            _playerSectorRessources.Buy(_constructable.Price);
        }

        void LeaveState()
        {
            _stateOwner.SetState(new PlayState(_stateOwner));
        }
    }
}