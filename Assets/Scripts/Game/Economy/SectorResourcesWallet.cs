namespace Tartaros.Economy
{
    using System.Collections;
    using UnityEngine;

    public class SectorResourcesWallet : ISectorResourcesWallet
    {
        bool ISectorResourcesWallet.CanBuy(Price price)
        {
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