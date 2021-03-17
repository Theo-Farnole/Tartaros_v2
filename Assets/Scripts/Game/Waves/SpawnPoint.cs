namespace Tartaros.Wave
{
    using System.Collections;
    using UnityEngine;
    using Tartaros;
    public class SpawnPoint : MonoBehaviour, ISpawnPoint
    {
        private float _randomRadius = 0;
        
        SpawnPointIdentifier ISpawnPoint.Identifier => throw new System.NotImplementedException();

        Vector3 ISpawnPoint.SpawnPoint => Random.insideUnitCircle.ToXZ() * _randomRadius + transform.position;
    }
}