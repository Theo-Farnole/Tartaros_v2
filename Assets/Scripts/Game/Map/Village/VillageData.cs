namespace Tartaros.Sectors.Village
{
    using System.Collections;
    using UnityEngine;
    using Tartaros.Sectors;
    using Sirenix.OdinInspector;

    public class VillageData : SerializedScriptableObject
    {
        [SerializeField]
        private int _populationAugmantationAmount = 0;
        [SerializeField]
        private GameObject _outpostPrefab = null;
        [SerializeField]
        private GameObject _villagerPrefab = null;

        public int PopulationAmount => _populationAugmantationAmount;
        public GameObject OutpostPrefab => _outpostPrefab;
        public GameObject VillagerPrefab => _villagerPrefab;
    }
}