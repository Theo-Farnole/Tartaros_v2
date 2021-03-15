namespace Tartaros.Population
{
    using UnityEngine;
    using System.Collections;
    public class PopulationManager : MonoBehaviour
    {
        private int _currentPopulation = 0;
        private int _maxPopulation = 0;


        bool CanSpawnUnit(int popAmount)
        {
            return true;
        }
    }
}