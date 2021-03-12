namespace Tartaros.Gamemode.State
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Tartaros.Gamemode;
    using Tartaros.Entities;
    using Tartaros.Construction;

    public class ConstructionState : AGameState
    {
        private EntityData _buildingToConstruct = null;
        private IBuildingPreviewPosition _buildingPreviewPosition = null;
        private IConstructable _building = null;
        private IBuildingInputManager _input = null;
        private BuildingPreview _buildingPreview = null;
        private ConstructionManager _constructionManager = null;

        public ConstructionState(GamemodeManager stateOwner, ConstructionManager constructionManager, IConstructable building, IBuildingPreviewPosition buildingPreviewPosition, 
        IBuildingInputManager input) : base(stateOwner)
        {
            _buildingPreviewPosition = buildingPreviewPosition;
            _building = building;
            _input = input;
            _constructionManager = constructionManager;
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();
            
            //InstanciatePreview();
        }

        public override void OnUpdate()
        {
            base.OnUpdate();


        }

        public override void OnStateExit()
        {
            base.OnStateExit();


        }

        //private void InstanciatePreview()
        //{
        //    _buildingPreview = new BuildingPreview();
        //    _buildingPreview.InstanciateBuildingPreview(_building, _buildingPreviewPosition.GetPreviewPosition());
        //}

        public void ConstructBuilding()
        {
            
        }

    }

}