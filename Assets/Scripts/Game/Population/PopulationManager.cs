namespace Tartaros.Population
{
    using UnityEngine;
    using System.Collections;
    public class PopulationManager : MonoBehaviour, IPopulationManager
    {
        private int _currentPopulation = 0;
        private int _maxPopulation = 0;

        [SerializeField]
        private PopulationManagerData _populationManagerData = null;


        private void OnEnable()
        {
            _maxPopulation = _populationManagerData.StartingMaxPoupulation;
        }
        public bool CanSpawn(int popAmount)
        {
            return _currentPopulation + popAmount < _maxPopulation;
        }

        public void AddCurrentPopulation(int popAmount)
        {
            if (_currentPopulation + popAmount < _maxPopulation)
                _currentPopulation += popAmount;
            else
                Debug.LogError("_currentPop can't be supperior than _maxPop");
        }
        public void RemoveCurrentPopulation(int popAmount)
        {
            if (_currentPopulation + popAmount > 0)
                _currentPopulation -= popAmount;
            else
                Debug.LogError("_currentPop can't be inferior than 0");
        }

        public void IncrementMaxPopulation(int popAmount)
        {
            _maxPopulation += popAmount;
        }

        public void ReduceMaxPopulation(int popAmount)
        {
            if (_maxPopulation - popAmount > 0)
                _maxPopulation -= popAmount;
            else
                Debug.LogError("_maxPop can't be inferrior than 0");
        }
    }
}