namespace Tartaros.Entities
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Tartaros.Entities;

    public class EntityMovementData : IEntityBehaviourData
    {
        [SerializeField]
        private float _speed = 1;

        [SerializeField]
        private float _separationRange = 1;

        void IEntityBehaviourData.SpawnRequiredComponents(GameObject entityRoot)
        {
            throw new System.NotImplementedException();
        }
    }
}