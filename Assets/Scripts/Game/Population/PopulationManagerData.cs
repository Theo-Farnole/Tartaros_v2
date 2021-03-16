namespace Tartaros.Population
{
    using Sirenix.OdinInspector;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class PopulationManagerData : SerializedScriptableObject
    {
        [SerializeField]
        private int _startingMaxPopulation = 0;

        public PopulationManagerData(int startingMaxPoupulation)
        {
            _startingMaxPopulation = startingMaxPoupulation;
        }

        public int StartingMaxPopulation => _startingMaxPopulation;
    }

}