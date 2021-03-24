﻿namespace Tartaros.Gamemode.State
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
        private List<GameObject> _wallSections = new List<GameObject>();
        private List<GameObject> _wallCorners = new List<GameObject>();
        private ISectorResourcesWallet _pricePreview = SectorResourcesWallet.Zero;

        public WallConstructionState(GamemodeManager gamemodeManager, IConstructable constructable) : base(gamemodeManager)
        {
            _constructable = constructable;
            _inputs = new ConstructionInputs();
            _playerSectorRessources = Services.Instance.Get<IPlayerSectorResources>();
            _map = Services.Instance.Get<IMap>();
            _buildingPreview = new BuildingPreview(_constructable, _inputs.GetPreviewPosition());
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();

            _inputs.ValidatePerformed -= _inputs_ValidatePerformed;
            _inputs.ValidatePerformed += _inputs_ValidatePerformed;


        }
        public override void OnUpdate()
        {
            base.OnUpdate();

            SetWallSectionPreview();

            SetFirstBuildingPreview();
        }

        public override void OnStateExit()
        {
            base.OnStateExit();

            _inputs.ValidatePerformed -= _inputs_ValidatePerformed;

            if (_buildingPreview != null)
            {
                _buildingPreview.DestroyMethod();
            }

            if (_wallSectionPreview != null)
            {
                _wallSectionPreview.DestroyMehods();
            }
        }

        private void _inputs_ValidatePerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            if (CanConstructHere())
            {
                bool isInPreviewMode = _wallSectionPreview != null;

                if (isInPreviewMode)
                {
                    if (_inputs.IsCtrlPerformed() == true)
                    {
                        ContinueWallPreview();
                    }
                    else
                    {
                        ValidateFinish();
                    }
                }
                else
                {
                    ValidateFirstPreview();
                }
            }
        }

        private void ContinueWallPreview()
        {
            AddWallPreviewOnList();
            _pricePreview = GetTotalPriceOfConstruction();
            Vector3 lastPosition = _wallSectionPreview.GetAllCornerPreview()[1].transform.position;
            _wallSectionPreview = null;
            _wallSectionPreview = new WallBuildingPreview(_constructable, lastPosition);
        }

        private void SetFirstBuildingPreview()
        {
            if (_buildingPreview != null)
            {
                _buildingPreview.SetBuildingPreviewPosition(_inputs.GetPreviewPosition());
            }
        }

        private void SetWallSectionPreview()
        {
            if (_wallSectionPreview != null)
            {
                _wallSectionPreview.CheckLine(_inputs.GetPreviewPosition());
                ShowPriceTotal();
            }
        }

        private void ValidateFirstPreview()
        {
            _wallSectionPreview = new WallBuildingPreview(_constructable, _buildingPreview.GetBuildingPreviewPosition());
            _buildingPreview.DestroyMethod();
            _buildingPreview = null;
        }

        private void ValidateFinish()
        {
            AddWallPreviewOnList();
            PayPriceRessources();
            InstanciateWallSection();
            LeaveState();
        }

        private void AddWallPreviewOnList()
        {
            foreach (GameObject wallSection in _wallSectionPreview.GetAllSectionPreview())
            {
                _wallSections.Add(wallSection);

            }

            foreach (GameObject wallCorner in _wallSectionPreview.GetAllCornerPreview())
            {
                _wallCorners.Add(wallCorner);
            }
        }

        private void InstanciateWallSection()
        {
            foreach (GameObject wall in _wallSections)
            {
                Transform transform = wall.transform;
                GameObject.Destroy(wall);
                GameObject wallInstanciate = GameObject.Instantiate(_constructable.PreviewPrefab, transform.position, transform.rotation);
            }

            foreach (GameObject corner in _wallCorners)
            {
                Transform transform = corner.transform;
                GameObject.Destroy(corner);
                GameObject wallInstanciate = GameObject.Instantiate(_constructable.PreviewPrefab, transform.position, transform.rotation);
            }
        }

        private bool CanConstructHere()
        {
            return true;

            return DoCanConstructOnMap() && DoCanConstructRulesAreValid();
        }

        private bool DoCanConstructOnMap()
        {
            foreach (GameObject wallPreview in _wallSectionPreview.GetWallBuildingPreview())
            {
                if (_map.CanBuild(wallPreview.transform.position, _constructable.Size) == false)
                {
                    return false;
                }
            }
            return true;
        }

        private bool DoCanConstructRulesAreValid()
        {
            foreach (GameObject wallPreview in _wallSectionPreview.GetWallBuildingPreview())
            {
                if (_constructable.DoRulesPassAtPosition(wallPreview.transform.position) == false)
                {
                    return false;
                }
            }
            return true;
        }

        private ISectorResourcesWallet GetTotalPriceOfConstruction()
        {
            ISectorResourcesWallet totalPrice = SectorResourcesWallet.Zero;

            foreach (GameObject wallPreview in _wallSectionPreview.GetWallBuildingPreview())
            {
                totalPrice.AddWallet(_constructable.Price);
            }

            totalPrice.AddWallet(_pricePreview);
            return totalPrice;
        }

        private void ShowPriceTotal()
        {
            //TODO DJ: Ref l'UI Z
            //Debug.LogFormat("{0}", GetTotalPriceOfConstruction().ToString());
        }

        private void PayPriceRessources()
        {
            _playerSectorRessources.Buy(GetTotalPriceOfConstruction());
        }

        void LeaveState()
        {
            _stateOwner.SetState(new PlayState(_stateOwner));
        }
    }
}