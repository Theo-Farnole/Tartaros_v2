namespace Tartaros.Economy
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Tartaros.Economy;
    using ServicesLocator;

    public class PlayerIncomeSectorResources : MonoBehaviour, IPlayerIncomeSectorResources
    {
        private IPlayerSectorResources _playerSectorRessources = null;
        [SerializeField]
        private PlayerSectorResourcesData _data = null;

        
        private void Awake()
        {
            Services.Instance.RegisterService<IPlayerIncomeSectorResources>(this);
            _playerSectorRessources = Services.Instance.Get<IPlayerSectorResources>();
        }
        void IPlayerIncomeSectorResources.AddIncome(SectorRessourceType ressource, int amount)
        {
            _playerSectorRessources.AddAmount(ressource, amount);
        }

        void IPlayerIncomeSectorResources.RemoveIncome(SectorRessourceType ressource, int amount)
        {
            _playerSectorRessources.RemoveAmount(ressource, amount);
        }
    }
}