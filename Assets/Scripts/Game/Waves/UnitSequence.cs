namespace Tartaros.Wave
{
    using System.Collections;
    using UnityEngine;
    public class UnitSequence
    {
        private IWaveSpawnableData _entityToSpawn = null;
        private int _entitiesCount = 0;
        private float _timeBetweenUnits = 0;

        public IEnumerator SpawnUnits(ISpawnPoint spawnPoint, IWaveSpawnable[] spawnedEntities)
        {
            for (int i = 0; i < spawnedEntities.Length; i++)
            {
                GameObject spawnedEntity = GameObject.Instantiate(_entityToSpawn.Prefab, spawnPoint.SpawnPoint, Quaternion.identity);
                _entitiesCount++;
                yield return new WaitForSeconds(_timeBetweenUnits);
            }
        }
    }
}