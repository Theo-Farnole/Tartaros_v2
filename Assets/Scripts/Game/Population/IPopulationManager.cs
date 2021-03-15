namespace Tartaros.Population
{
    public interface IPopulationManager
    {
        bool CanSpawn(int popAmount);
        void IncrementMaxPopulation(int popAmount);
        void ReduceMaxPopulation(int popAmount);
        void AddCurrentPopulation(int popAmount);
        void RemoveCurrentPopulation(int popAmount);
    }
}