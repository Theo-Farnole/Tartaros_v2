namespace Tartaros.Economy
{
    using Tartaros.Economy;

    public interface IPlayerIncomeSectorResources
    {
        void AddIncome(SectorRessourceType ressource, int amount);
        void RemoveIncome(SectorRessourceType ressource, int amount);
    }
}