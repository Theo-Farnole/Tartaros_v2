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

       
        private IConstructable _testConstructable = null;
        #endregion

        #region Methods

        private void Awake()
        {
            _testConstructable = GetComponent<IConstructable>();

            //_input = GetComponent<IBuildingInputManager>();
            //_IBuildingPreviewPosition = GetComponent<IBuildingPreviewPosition>();
            //if (_IBuildingPreviewPosition == null)
            //    Debug.LogError("Add compenent IbuildingPreviewPosition");
        }

        private void Start()
        {
            if (Services.HasInstance)
            {
                if (Services.Instance.TryGet<GamemodeManager>(out GamemodeManager gameModeManager))
                {
                    _gamemodeManager = gameModeManager;
                }
            }
        }

        private void Update()
        {
            //if (_input.CheckEnterConstructionMode())
            //{
            //    if (_buildingPreview == null)
            //    {
            //        EnterConstructionMode(_testConstructable, new Price());
            //    }
            //}

            //if (_buildingPreview != null)
            //{
            //    if(_input.CheckLeaveWithoutConstruct())
            //    {
            //        ExitConstructionModeWithoutConstruct();
            //    }

            //    _buildingPreview.SetBuildingPreviewPosition(_IBuildingPreviewPosition.GetPreviewPosition());
            //    ConstructBuilding();
            //}
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
            _gamemodeManager.SetState(new ConstructionStateV2(_gamemodeManager, constructionPrice, toBuild));
        }
        #endregion
    }

}