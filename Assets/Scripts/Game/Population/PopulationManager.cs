namespace Tartaros.Population
{
	using UnityEngine;
	using System.Collections;
	using Tartaros.ServicesLocator;

	public class PopulationManager : MonoBehaviour, IPopulationManager
	{
		#region Fields
		private int _currentPopulation = 0;
		private int _maxPopulation = 0;

		[SerializeField]
		private PopulationManagerData _populationManagerData = null;
		#endregion Fields


		#region Methods
		void Awake()
		{
			Services.Instance.RegisterService<IPopulationManager>(this);
			_maxPopulation = _populationManagerData.StartingMaxPopulation;
		}

		public bool CanSpawn(int popAmount)
		{
			return _currentPopulation + popAmount < _maxPopulation;
		}

		public void AddCurrentPopulation(int popAmount)
		{
			if (popAmount < 0) throw new System.ArgumentException("PopAmount must be positive");

			if (CanSpawn(popAmount) == true)
			{
				_currentPopulation += popAmount;
			}
			else
			{
				Debug.LogError("_currentPop can't be supperior than _maxPop");
			}
		}

		public void RemoveCurrentPopulation(int popAmount)
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

		public void IncrementMaxPopulation(int popAmount)
		{
			_maxPopulation += popAmount;
		}

		public void ReduceMaxPopulation(int popAmount)
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
		#endregion Methods
	}
}