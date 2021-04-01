namespace Tartaros
{
	using Tartaros.Population;

	public static class IPopulationManagerExtensions
	{
		public static bool CanSpawn(this IPopulationManager popManager, int popAmount)
		{
			return popManager.CurrentPopulation + popAmount <= popManager.MaximumPopulation;
		}
	}
}
