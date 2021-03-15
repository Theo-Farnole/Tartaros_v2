namespace Tartaros.Population
{
    using Sirenix.OdinInspector;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class PopulationManagerData : SerializedScriptableObject
    {
        [SerializeField]
        private int _startingMaxPoupulation = 0;

        public PopulationManagerData(int startingMaxPoupulation)
        {
            _startingMaxPoupulation = startingMaxPoupulation;
        }

        public int StartingMaxPoupulation => _startingMaxPoupulation;
    }

}