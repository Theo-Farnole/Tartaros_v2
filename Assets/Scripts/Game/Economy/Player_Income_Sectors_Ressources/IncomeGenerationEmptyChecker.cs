namespace Tartaros.Economy
{
	using System.Collections;
	using UnityEngine;

	public class IncomeGenerationEmptyChecker
	{
		private IIncomeGenerator _income = null;
		private float _tickIntervalSeconds = 1;
		private IPlayerIncomeManager _playerIncomeManager = null;
		private int _currentRessourcesFilled = 0;

		public IncomeGenerationEmptyChecker(IIncomeGenerator income, float tickIntervalSeconds, IPlayerIncomeManager playerIncomeManager)
		{
			_income = income;
			_tickIntervalSeconds = tickIntervalSeconds;
			_playerIncomeManager = playerIncomeManager;
		}

		public void StartEmptyCheckerCoroutine(PlayerIncomeManager incomeManager)
		{
			incomeManager.StartCoroutine(CheckIfIncomeIsEmpty(incomeManager));
		}

		private IEnumerator CheckIfIncomeIsEmpty(PlayerIncomeManager incomeManager)
		{
			while(_currentRessourcesFilled >= _income.MaxRessourcesBeforeEmpty || _income != null)
			{
				yield return new WaitForSeconds(_tickIntervalSeconds);
				_currentRessourcesFilled += _income.ResourcesPerTick;

				if(_currentRessourcesFilled >= _income.MaxRessourcesBeforeEmpty)
				{
					_income.RessourcesIsEmpty();
					_playerIncomeManager.RemoveGeneratorIncome(_income);
					incomeManager.RemoveIncomeChecker(this);
				}
			}
		}
	}
}