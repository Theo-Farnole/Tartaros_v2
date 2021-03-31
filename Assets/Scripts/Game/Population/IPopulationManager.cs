namespace Tartaros.Population
{
	using System;

	public class CurrentPopulationChangedArgs : EventArgs
	{ }

	public class MaxPopulationChangedArgs : EventArgs
	{ }

	public interface IPopulationManager
	{
		int CurrentPopulation { get; }
		int MaximumPopulation { get; }

		event EventHandler<CurrentPopulationChangedArgs> CurrentPopulationChanged;
		event EventHandler<MaxPopulationChangedArgs> MaxPopulationChanged;

		bool CanSpawn(int popAmount);

		void AddCurrentPopulation(int popAmount);
		void RemoveCurrentPopulation(int popAmount);

		void IncrementMaxPopulation(int popAmount);
		void ReduceMaxPopulation(int popAmount);
	}
}