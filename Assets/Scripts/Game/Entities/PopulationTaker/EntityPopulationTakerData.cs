namespace Tartaros.Entities
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;


    public class EntityPopulationTakerData : IEntityBehaviourData
    {
        [SerializeField]
        private int _populationTakingCount = 1;

        public EntityPopulationTakerData(int populationTakingCount)
        {
            _populationTakingCount = populationTakingCount;
        }

        public int PopulationTakingCount => _populationTakingCount;

        void IEntityBehaviourData.SpawnRequiredComponents(GameObject entityRoot)
        {
            throw new System.NotImplementedException();
        }
    }
}