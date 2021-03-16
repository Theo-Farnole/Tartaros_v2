namespace Tartaros.Economy
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using ServicesLocator;
    using System;

    public class PlayerSectorResources : MonoBehaviour, IPlayerSectorResources
    {
        private ISectorResourcesWallet _playerWallet = null;
        [SerializeField]
        private PlayerSectorResourcesData _playerSectorRessourcesData = null;

        

        private void Awake()
        {
            _playerWallet = _playerSectorRessourcesData.Wallet.Clone() as ISectorResourcesWallet;
            Services.Instance.RegisterService<IPlayerSectorResources>(this);
        }
        
        void IPlayerSectorResources.AddAmount(SectorRessourceType ressource, int amount)
        {
            _playerWallet.AddAmount(ressource, amount);
        }

        int IPlayerSectorResources.GetAmount(SectorRessourceType ressource)
        {
            return _playerWallet.GetAmount(ressource);
        }

        void IPlayerSectorResources.RemoveAmount(SectorRessourceType ressource, int amount)
        {
            _playerWallet.RemoveAmount(ressource, amount);
        }

        void IPlayerSectorResources.Buy(Price price)
        {
            _playerWallet.Buy(price);
        }
    }
}