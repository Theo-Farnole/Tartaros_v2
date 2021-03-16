namespace Tartaros.Economy
{
    using System;
    using System.Collections.Generic;

    public interface ISectorResourcesWallet : ICloneable
    {
        int GetAmount(SectorRessourceType ressource);
        void AddAmount(SectorRessourceType ressource, int amount);
        void RemoveAmount(SectorRessourceType ressource, int amount);
        bool CanBuy(Price price);
        void Buy(Price price);
    }
}