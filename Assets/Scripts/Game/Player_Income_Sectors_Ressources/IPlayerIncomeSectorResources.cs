namespace Tartaros.PlayerIncomeSectorRessources
{
    using Tartaros.Economy;
    public interface IPlayerIncomeSectorResources
    {
        void AddAmount(SectorRessourceType ressource, int amount);
        void RemoveAmount(SectorRessourceType ressource, int amount);
    }
}