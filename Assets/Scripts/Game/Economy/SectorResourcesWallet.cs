namespace Tartaros.Economy
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    [System.Serializable]
    public class SectorResourcesWallet : ISectorResourcesWallet
    {
        private Dictionary<SectorRessourceType, int> _ressourceAmount = new Dictionary<SectorRessourceType, int>();

        bool ISectorResourcesWallet.CanBuy(Price price)
        {
            Debug.Log(_ressourceAmount[SectorRessourceType.Food]);
            throw new System.NotImplementedException();
        }

        void ISectorResourcesWallet.AddAmount(SectorRessourceType ressource, int amount)
        {
            throw new System.NotImplementedException();
        }

        void ISectorResourcesWallet.Buy(Price price)
        {
            throw new System.NotImplementedException();
        }

        int ISectorResourcesWallet.GetAmount(SectorRessourceType ressource)
        {
            throw new System.NotImplementedException();
        }

        void ISectorResourcesWallet.RemoveAmount(SectorRessourceType ressource, int amount)
        {
            throw new System.NotImplementedException();
        }
    }
}