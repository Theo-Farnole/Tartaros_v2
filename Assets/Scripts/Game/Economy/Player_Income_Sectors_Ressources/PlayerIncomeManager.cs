namespace Tartaros.Economy
{
	using ServicesLocator;
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class PlayerIncomeManager : MonoBehaviour, IPlayerIncomeManager
	{
		#region Fields
		[SerializeField]
		private PlayerIncomeManagerData _data = null;

		private List<IIncomeGenerator> _incomesGiver = new List<IIncomeGenerator>();
		private ISectorResourcesWallet _incomePerTick = null;
		private IPlayerSectorResources _incomeReceiver = null;

		private List<IncomeGenerationEmptyChecker> _incomesEmptyCheckers = new List<IncomeGenerationEmptyChecker>();
		#endregion Fields

		#region Properties
		public PlayerIncomeManagerData Data { get => _data; set => _data = value; }
		public event EventHandler<IncomeChangedArgs> IncomeChanged = null;
		#endregion Properties

		#region Methods
		private void Awake()
		{
			_incomeReceiver = Services.Instance.Get<IPlayerSectorResources>();

			if (_data != null)
			{
				_incomePerTick = new SectorResourcesWallet(_data.StartingIncome);
			}
			else
			{
				_incomePerTick = new SectorResourcesWallet();
				Debug.LogWarningFormat("Missing data in {0}.", _data);
			}
		}

		private void Start()
		{
			StartCoroutine(GenerationCoroutine());
		}

		private IEnumerator GenerationCoroutine()
		{
			while (true)
			{
				yield return new WaitForSeconds(_data.TickInvervalInSeconds);

				_incomeReceiver.AddWallet(_incomePerTick);
			}
		}

		public void RemoveIncomeChecker(IncomeGenerationEmptyChecker checker)
		{
			if(_incomesEmptyCheckers.Count != 0)
			{
				_incomesEmptyCheckers.Remove(checker);
			}
		}

		

		void IPlayerIncomeManager.AddGeneratorIncome(IIncomeGenerator income)
		{
			if (_incomesGiver.Contains(income))
			{
				Debug.LogErrorFormat("Cannot add generator: Income generator {0} is already in incomes generator list.", income.ToString());
				return;
			}
		

			_incomesGiver.Add(income);
			_incomePerTick.AddAmount(income.SectorRessourceType, income.ResourcesPerTick);

			IncomeChanged?.Invoke(this, new IncomeChangedArgs());

			if(income.MaxRessourcesBeforeEmpty != 0)
			{
				var emptyChecker = new IncomeGenerationEmptyChecker(income, _data.TickInvervalInSeconds, this);
				emptyChecker.StartEmptyCheckerCoroutine(this);
				_incomesEmptyCheckers.Add(emptyChecker);
			}
			else
			{
				Debug.LogWarningFormat("Ressources {0} has no maximum ressources values", income.SectorRessourceType);
			}

			Debug.LogFormat("Player Income changed: it is now {0}.", _incomePerTick.ToString());
		}

		void IPlayerIncomeManager.RemoveGeneratorIncome(IIncomeGenerator income)
		{
			if (income is null) throw new ArgumentNullException(nameof(income));

			if (_incomesGiver.Contains(income) == false)
			{
				//Debug.LogErrorFormat("Cannot remove generator: Income generator {0} is not incomes generator list.", income.ToString());
				return;
			}

			_incomesGiver.Remove(income);
			_incomePerTick.RemoveAmount(income.SectorRessourceType, income.ResourcesPerTick);

			IncomeChanged?.Invoke(this, new IncomeChangedArgs());

			Debug.LogFormat("Player Income changed: it is now {0}.", _incomePerTick.ToString());
		}

		int IPlayerIncomeManager.GetIncomeAmount(SectorRessourceType type)
		{
			return _incomePerTick.GetAmount(type);
		}
		#endregion Methods
	}
}