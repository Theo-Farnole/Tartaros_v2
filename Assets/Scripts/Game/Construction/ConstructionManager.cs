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
    using Tartaros.ServicesLocator;

    public class ConstructionManager : MonoBehaviour
    {
        #region Fields
        private readonly ConstructionManagerData _contstructionManagerData = null;
        private GamemodeManager _gamemodeManager = null;
        private BuildingPreview _buildingPreview = null;

        private IBuildingPreviewPosition _IBuildingPreviewPosition = null;
        private IBuildingInputManager _input = null;
        private IConstructable _testConstructable = null;
        #endregion

        #region Methods

        private void Awake()
        {
            _input = GetComponent<IBuildingInputManager>();
            _testConstructable = GetComponent<IConstructable>();

            _IBuildingPreviewPosition = GetComponent<IBuildingPreviewPosition>();
            if (_IBuildingPreviewPosition == null)
                Debug.LogError("Add compenent IbuildingPreviewPosition");
        }

        private void Start()
        {
            if (Services.HasInstance)
            {
                if (Services.Instance.TryGet<GamemodeManager>(out GamemodeManager gameModeManager))
                {
                    _gamemodeManager = gameModeManager;
                }
                else
                {
                    Debug.LogError("Don't find GameModeManger");
                }
            }
        }

        private void Update()
        {
            if (_input.CheckEnterConstructionMode())
            {
                if (_buildingPreview == null)
                {
                    EnterConstructionMode(_testConstructable, new Price());
                }
            }

            if (_buildingPreview != null)
            {
                if(_input.CheckLeaveWithoutConstruct())
                {
                    ExitConstructionModeWithoutConstruct();
                }

                _buildingPreview.SetBuildingPreviewPosition(_IBuildingPreviewPosition.GetPreviewPosition());
                ConstructBuilding();
            }
        }


        //private void OnDrawGizmos()
        //{
        //    if (Application.isPlaying)
        //    {
        //        Gizmos.color = Color.red;
        //        Gizmos.DrawSphere(_IBuildingPreviewPosition.GetBuildingPosition(), 0.5f);
        //    }
        //}

        private bool CanEnterConstruction(Price constructionPrice)
        {
            throw new System.NotImplementedException();
        }

        public void EnterConstructionMode(IConstructable toBuild, Price constructionPrice)
        {
            _gamemodeManager.SetState(new ConstructionState(_gamemodeManager));
            _buildingPreview = new BuildingPreview();
            _buildingPreview.InstanciateBuildingPreview(toBuild, _IBuildingPreviewPosition.GetPreviewPosition());

        }

        public void ExitConstructionMode()
        {
            _buildingPreview.DestroyMethod();
            _buildingPreview = null;

            _gamemodeManager.SetState(new PlayState(_gamemodeManager));
            //throw new System.NotImplementedException();
        }

        public void ExitConstructionModeWithoutConstruct()
        {
            ExitConstructionMode();
            //throw new System.NotImplementedException();
        }

        public void ConstructBuilding()
        {
            if(_input.CheckConstruct())
            {
                GameObject buildingConstruct = GameObject.Instantiate(_testConstructable.ModelPrefab, _buildingPreview.GetBuildingPreviewPosition(), Quaternion.identity);
                ExitConstructionMode();
            }
            //throw new System.NotImplementedException();
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