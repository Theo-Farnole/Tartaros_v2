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
		private int _maxRessorceBeforeEmpty = 0;
		private int _ressourcesPerTick = 0;

		public IncomeGenerationEmptyChecker(IIncomeGenerator income, float tickIntervalSeconds, IPlayerIncomeManager playerIncomeManager)
		{
			_income = income;
			_tickIntervalSeconds = tickIntervalSeconds;
			_playerIncomeManager = playerIncomeManager;
			_maxRessorceBeforeEmpty = _income.MaxRessourcesBeforeEmpty;
			_ressourcesPerTick = _income.ResourcesPerTick;
		}

		public void StartEmptyCheckerCoroutine(PlayerIncomeManager incomeManager)
		{
			incomeManager.StartCoroutine(CheckIfIncomeIsEmpty(incomeManager));
		}

		private IEnumerator CheckIfIncomeIsEmpty(PlayerIncomeManager incomeManager)
		{
			while (_currentRessourcesFilled < _maxRessorceBeforeEmpty)
			{

				if (_income == null)
				{
					incomeManager.RemoveIncomeChecker(this);
				}

				yield return new WaitForSeconds(_tickIntervalSeconds);
				_currentRessourcesFilled += _ressourcesPerTick;

				if (_currentRessourcesFilled >= _maxRessorceBeforeEmpty)
				{
					if (_income.IsInterfaceDestroyed() == false)
					{
						_income.RessourcesIsEmpty();
						_playerIncomeManager.RemoveGeneratorIncome(_income);
					}

					incomeManager.RemoveIncomeChecker(this);
				}
			}
		}
	}
}