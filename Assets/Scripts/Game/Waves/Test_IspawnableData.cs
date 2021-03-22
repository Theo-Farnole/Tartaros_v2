namespace Tartaros.Wave
{
    using System.Collections;
    using System.Collections.Generic;
    using Tartaros.Entities;
    using UnityEngine;

    public class Test_IspawnableData : IWaveSpawnableData
    {
        [SerializeField]
        private GameObject _prefab = null;

        GameObject IWaveSpawnableData.Prefab => _prefab;
    }

}