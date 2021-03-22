namespace Tartaros.Economy
{
	using System;

	public class IncomeChangedArgs : EventArgs
	{ }

	public interface IPlayerIncomeManager
	{
		event EventHandler<IncomeChangedArgs> IncomeChanged;

		void AddGeneratorIncome(IIncomeGenerator income);
		void RemoveGeneratorIncome(IIncomeGenerator income);
		int GetIncomeAmount(SectorRessourceType type);
	}
}