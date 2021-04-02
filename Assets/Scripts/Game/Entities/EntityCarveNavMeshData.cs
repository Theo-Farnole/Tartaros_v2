namespace Tartaros.Entities
{
	using UnityEngine;
	using UnityEngine.AI;


	public class EntityCarveNavMeshData : IEntityBehaviourData
    {
        [SerializeField]
        Vector2 _size = Vector2.zero;



        void IEntityBehaviourData.SpawnRequiredComponents(GameObject entityRoot)
        {
            NavMeshObstacle _navObstacle = entityRoot.GetOrAddComponent<NavMeshObstacle>();

            Vector3 newSize = new Vector3(_size.x, 1, _size.y);

            _navObstacle.size = newSize;
            _navObstacle.carving = true;
        }
    }

}