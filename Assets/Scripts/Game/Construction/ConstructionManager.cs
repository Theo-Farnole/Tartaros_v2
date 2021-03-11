namespace Tartaros.Construction
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Tartaros.Construction;
    using Tartaros.Economy;
    using Tartaros.Gamemode.State;
    using Tartaros.Gamemode;
    using Tartaros.Utilities;
    using UnityEngine.InputSystem;

    public class ConstructionManager : MonoBehaviour
    {
        #region Fields
        private readonly ConstructionManagerData _contstructionManagerData = null;
        private GamemodeManager _gamemodeManager = null;
        private IBuildingPreviewPosition _IBuildingPreviewPosition = null;
        private GameInputs _inputs = null;
        private BuildingPreview _buildingPreview = null;

        private IConstructable _testConstructable = null;
        #endregion

        #region Methods

        private void Awake()
        {
            _inputs = new GameInputs();
            _inputs.Camera.Enable();

            _testConstructable = GetComponent<IConstructable>();

            _IBuildingPreviewPosition = GetComponent<IBuildingPreviewPosition>();
            if (_IBuildingPreviewPosition == null)
                Debug.LogError("Add compenent IbuildingPreviewPosition");
        }

        private void Update()
        {
            if (_inputs.Camera.Forward.phase == InputActionPhase.Performed)
            {
                if (_buildingPreview == null)
                {
                    EnterConstructionMode(_testConstructable, new Price());
                }
                else
                {
                    _buildingPreview.DestroyMethod();
                    EnterConstructionMode(_testConstructable, new Price());
                }
            }

            if (_buildingPreview != null)
                _buildingPreview.SetBuildingPreviewPosition(_IBuildingPreviewPosition.GetBuildingPosition());
        }


        private void OnDrawGizmos()
        {
            if (Application.isPlaying)
            {
                //Gizmos.color = Color.red;
                //Gizmos.DrawSphere(_IBuildingPreviewPosition.GetBuildingPosition(), 1f);
            }
        }

        private bool CanEnterConstruction(Price constructionPrice)
        {
            throw new System.NotImplementedException();
        }

        public void EnterConstructionMode(IConstructable toBuild, Price constructionPrice)
        {
            _buildingPreview = new BuildingPreview();
            _buildingPreview.InstanciateBuildingPreview(toBuild, _IBuildingPreviewPosition.GetBuildingPosition());
            Debug.Log("number");

        }

        public void ExitConstructionMode()
        {
            _gamemodeManager.SetState(new PlayState(_gamemodeManager));
            throw new System.NotImplementedException();
        }

        public void ExitConstructionModeWithoutConstruct()
        {
            _gamemodeManager.SetState(new PlayState(_gamemodeManager));
            throw new System.NotImplementedException();
        }

        public void ConstructBuilding()
        {

            throw new System.NotImplementedException();
        }

        bool CanConstructBuilding()
        {
            throw new System.NotImplementedException();
        }

        public void Refund()
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }

}