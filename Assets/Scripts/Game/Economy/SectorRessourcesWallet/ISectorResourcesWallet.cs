namespace Tartaros.Economy
{
	public interface ISectorResourcesWallet
    {
        int GetAmount(SectorRessourceType ressource);
        void AddAmount(SectorRessourceType ressource, int amount);
        void RemoveAmount(SectorRessourceType ressource, int amount);
        bool CanBuy(ISectorResourcesWallet price);
        void Buy(ISectorResourcesWallet price);
    }
}