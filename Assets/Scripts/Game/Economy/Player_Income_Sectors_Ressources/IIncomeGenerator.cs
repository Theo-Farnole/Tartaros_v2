namespace Tartaros.Economy
{
	public interface IIncomeGenerator
	{
		SectorRessourceType SectorRessourceType { get; }
		int ResourcesPerTick { get; }

	}
}
