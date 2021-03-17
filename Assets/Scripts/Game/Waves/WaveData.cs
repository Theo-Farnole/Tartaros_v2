namespace Tartaros.Wave
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class WaveData
    {
        private Dictionary<SpawnPointIdentifier, UnitSequence> _sequencesBySpawnPoint;

        public void Spawn(MonoBehaviour mb, ISpawnPoint[] spawnPoints, IWaveSpawnable[] spawnedEntities)
        {
            foreach (ISpawnPoint spawnPoint in spawnPoints)
            {
                UnitSequence unitsSequence = _sequencesBySpawnPoint[spawnPoint.Identifier];

                mb.StartCoroutine(unitsSequence.SpawnUnits(spawnPoint, spawnedEntities));
            }
        }
    }
}