namespace Tartaros.Wave
{
    using System.Collections;
    using UnityEngine;
    using Tartaros;
    public class SpawnPoint : MonoBehaviour, ISpawnPoint
    {
        [SerializeField]
        private float _randomRadius = 0;
        [SerializeField]
        private SpawnPointIdentifier _identifier;
        
        SpawnPointIdentifier ISpawnPoint.Identifier => _identifier;

        Vector3 ISpawnPoint.SpawnPoint => Random.insideUnitCircle.ToXZ() * _randomRadius + transform.position;
    }
}