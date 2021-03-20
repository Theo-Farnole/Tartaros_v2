namespace Tartaros.Wave
{
    using Sirenix.OdinInspector;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    [System.Serializable]
    public class WavesSpawnerData : SerializedScriptableObject
    {
        [SerializeField]
        private WaveData[] _waves;
        [SerializeField]
        private float _secondsBetweenWaves = 0;

        public WaveData[] Wave => _waves;
        public float SecondsBetweenWaves => _secondsBetweenWaves;
    }
}