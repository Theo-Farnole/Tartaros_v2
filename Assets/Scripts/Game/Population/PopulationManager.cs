namespace Tartaros.Population
{
	using UnityEngine;
	using System.Collections;
	using Tartaros.ServicesLocator;
	using System;

	public class PopulationManager : MonoBehaviour, IPopulationManager
	{
		#region Fields
		private int _currentPopulation = 0;
		private int _maxPopulation = 0;

		[SerializeField]
		private PopulationManagerData _populationManagerData = null;
		#endregion Fields

		#region Properties
		int IPopulationManager.CurrentPopulation => _currentPopulation;
		int IPopulationManager.MaximumPopulation => _maxPopulation;
		#endregion Properties

		#region Events
		event EventHandler<CurrentPopulationChangedArgs> CurrentPopulationChanged = null;
		event EventHandler<MaxPopulationChangedArgs> MaxPopulationChanged = null;

		event EventHandler<CurrentPopulationChangedArgs> IPopulationManager.CurrentPopulationChanged { add => CurrentPopulationChanged += value; remove => CurrentPopulationChanged -= value; }
		event EventHandler<MaxPopulationChangedArgs> IPopulationManager.MaxPopulationChanged { add => MaxPopulationChanged += value; remove => MaxPopulationChanged -= value; }
		#endregion Events

		#region Methods
		void Awake()
		{
			Services.Instance.RegisterService<IPopulationManager>(this);
			_maxPopulation = _populationManagerData.StartingMaxPopulation;
		}

		void IPopulationManager.IncrementMaxPopulation(int popAmount)
		{
			_maxPopulation += popAmount;
		}

		void IPopulationManager.ReduceMaxPopulation(int popAmount)
		{
			if (_maxPopulation - popAmount > 0)
			{
				_maxPopulation -= popAmount;
			}
			else
			{
				Debug.LogError("_maxPop can't be inferrior than 0");
				_maxPopulation = 0;
			}
		}

		void IPopulationManager.AddCurrentPopulation(int popAmount)
		{
			if (popAmount < 0) throw new System.ArgumentException("PopAmount must be positive");

			if ((this as IPopulationManager).CanSpawn(popAmount) == true)
			{
				_currentPopulation += popAmount;
			}
			else
			{
				Debug.LogError("_currentPop can't be supperior than _maxPop");
			}
		}

		void IPopulationManager.RemoveCurrentPopulation(int popAmount)
		{
			if (popAmount < 0) throw new System.ArgumentException("PopAmount must be positive");

			if (_currentPopulation - popAmount > 0)
			{
				_currentPopulation -= popAmount;
			}
			else
			{
				_currentPopulation = 0;
				Debug.LogError("_currentPop can't be inferior than 0");
			}
		}
		#endregion Methods
	}
}