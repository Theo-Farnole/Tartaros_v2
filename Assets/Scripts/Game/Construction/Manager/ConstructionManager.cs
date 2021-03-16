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
        private IPlayerSectorResources _playerSectorRessources = null;
        #endregion

        #region Methods


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

        public bool CanEnterConstruction(Price constructionPrice)
        {
            return constructionPrice.Amount >= _playerSectorRessources.GetAmount(constructionPrice.RessourceType);
        }

        public void EnterConstructionMode(IConstructable toBuild)
        {
            _gamemodeManager.SetState(new ConstructionStateV2(_gamemodeManager, toBuild));
        }
        #endregion
    }

}