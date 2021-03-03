namespace Tartaros.Economy.PlayerSectorRessources
{
	using Tartaros.Economy;

	public interface IPlayerSectorResources
	{
		int GetAmount(SectorRessourceType ressource);
		void AddAmount(SectorRessourceType ressource, int amount);
		void RemoveAmount(SectorRessourceType ressource, int amount);
	}
}