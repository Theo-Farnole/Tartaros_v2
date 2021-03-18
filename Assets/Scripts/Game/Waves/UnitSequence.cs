namespace Tartaros.Wave
{
    using System.Collections;
    using UnityEngine;
    public class UnitSequence
    {
        private IWaveSpawnableData _entityToSpawn = null;
        private int _entitiesCount = 0;
        private float _secondsBetweenUnits = 0;
        private float _secondsBeforeSpawn = 0;

        public IWaveSpawnableData EntityToSpawn => _entityToSpawn;
        public int EntitiesCount => _entitiesCount;
        public float SecondsBetweenUnits => _secondsBetweenUnits;
        public float SecondsBeforeSpawn => _secondsBeforeSpawn;
    }
}