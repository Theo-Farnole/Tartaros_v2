namespace Tartaros.Wave
{
    using System.Collections;
    using UnityEngine;
    public class UnitSequence
    {
        [SerializeField]
        private IWaveSpawnableData _entityToSpawn = null;
        [SerializeField]
        private int _entitiesCount = 0;
        [SerializeField]
        private float _secondsBetweenUnits = 0;
        [SerializeField]
        private float _secondsBeforeSpawn = 0;

        public IWaveSpawnableData EntityToSpawn => _entityToSpawn;
        public int EntitiesCount => _entitiesCount;
        public float SecondsBetweenUnits => _secondsBetweenUnits;
        public float SecondsBeforeSpawn => _secondsBeforeSpawn;
    }
}