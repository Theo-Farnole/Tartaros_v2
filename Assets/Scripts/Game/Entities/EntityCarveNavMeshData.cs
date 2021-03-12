namespace Tartaros.Entities
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class EntityCarveNavMeshData : IEntityBehaviourData
    {

        Vector2 _size = Vector2.zero;
        void IEntityBehaviourData.SpawnRequiredComponents(GameObject entityRoot)
        {
            throw new System.NotImplementedException();
        }
    }

}