namespace Tartaros.Entities
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Tartaros.Entities;

    public class EntityDetectionData : IEntityBehaviourData
    {
        [SerializeField]
        private float _detectionRange = 1;

        public EntityDetectionData(float detectionRange)
        {
            _detectionRange = detectionRange;
        }
        public float DetectionRange => _detectionRange;


        public void SpawnRequiredComponents(GameObject entityRoot)
        {
            throw new System.NotImplementedException();
        }
    }
}