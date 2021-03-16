namespace Tartaros.Construction
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Tartaros.Construction;
    using Tartaros.Economy;
    using Tartaros.Gamemode;
    using Tartaros.ServicesLocator;

    public class ConstructionManager : MonoBehaviour
    {
        #region Fields
        private readonly ConstructionManagerData _contstructionManagerData = null;
        private GamemodeManager _gamemodeManager = null;
        private PlayerSectorResources _playerSectorRessources = null;
        private IConstructable _testConstructable = null;

        private SectorRessourceType _currentRessource;
        private int _currentAmount = 0;
        #endregion

        #region Methods

        private void Awake()
        {
            _testConstructable = GetComponent<IConstructable>();
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
            
        }

        private bool CanEnterConstruction(Price constructionPrice)
        {
            SectorRessourceType ressourceType = constructionPrice.RessourceType;
            int amount = constructionPrice.Amount;

            throw new System.NotImplementedException();
        }

        public void EnterConstructionMode(IConstructable toBuild, Price constructionPrice)
        {
            _gamemodeManager.SetState(new ConstructionStateV2(_gamemodeManager, constructionPrice, toBuild));
        }
        #endregion
    }

}