namespace Tartaros.Gamemode.State
{
    using System.Collections;
    using System.Collections.Generic;
    using Tartaros.Construction;
    using Tartaros.Economy;
    using Tartaros.Sectors;
    using Tartaros.ServicesLocator;
    using UnityEngine;

    public class WallConstructionState : AGameState
    {
        private IConstructable _constructable = null;
        private ConstructionInputs _inputs = null;
        private WallBuildingPreview _wallSectionPreview = null;
        private BuildingPreview _buildingPreview = null;
        private IPlayerSectorResources _playerSectorRessources = null;
        private IMap _map = null;
        private int _securityInstanciateIndex = 0;

        public WallConstructionState(GamemodeManager gamemodeManager, IConstructable constructable) : base(gamemodeManager)
        {
            _constructable = constructable;
            _inputs = new ConstructionInputs();
            _playerSectorRessources = Services.Instance.Get<IPlayerSectorResources>();
            _map = Services.Instance.Get<IMap>();
            //_buildingPreview = new BuildingPreview(_constructable, _inputs.GetPreviewPosition());
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();


        }
        public override void OnUpdate()
        {
            base.OnUpdate();
            SecurityInisialize();
            if (_wallSectionPreview != null)
            {
                _wallSectionPreview.CheckLine(_inputs.GetPreviewPosition());
            }

        }

        private void SecurityInisialize()
        {
            if (_securityInstanciateIndex == 1)
            {
                _wallSectionPreview = new WallBuildingPreview(_constructable, _inputs.GetPreviewPosition());
                _securityInstanciateIndex++;
            }
            else
            {
                _securityInstanciateIndex++;
            }
        }

        bool CanConstructHere()
        {
            throw new System.NotImplementedException();
        }

        private void PayPriceRessources()
        {
            throw new System.NotImplementedException();
        }

        void LeaveState()
        {
            _stateOwner.SetState(new PlayState(_stateOwner));
        }
    }
}