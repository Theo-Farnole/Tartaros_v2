namespace Tartaros.Entities
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.AI;


    public class EntityCarveNavMeshData : IEntityBehaviourData
    {
        [SerializeField]
        Vector2 _size = Vector2.zero;



        void IEntityBehaviourData.SpawnRequiredComponents(GameObject entityRoot)
        {
            NavMeshObstacle _navObstacle = entityRoot.GetOrAddComponent<NavMeshObstacle>();
            _navObstacle.size = _size;
            _navObstacle.carving = true;
        }
    }

}