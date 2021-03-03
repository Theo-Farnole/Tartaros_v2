namespace Tartaros.Population
{
    public interface IPopulationManager
    {
        bool CanSpawn(int popAmount);
        bool IncrementMaxPopulation(int popAmount);
        bool ReduceMaxPopulation(int popAmount);
        bool AddCurrentPopulation(int popAmount);
        bool RemoveCurrentPopulation(int popAmount);
    }
}