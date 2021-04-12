namespace Tartaros.Map.Village
{
	using Tartaros.Entities;
	using UnityEngine;

	public class VillageData : IEntityBehaviourData
    {
        [SerializeField]
        private int _populationIncreaseAmount = 0;
        [SerializeField]
        private GameObject _outpostPrefab = null;
        [SerializeField]
        private GameObject _villagerPrefab = null;

        public int PopulationAmount => _populationIncreaseAmount;
        public GameObject OutpostPrefab => _outpostPrefab;
        public GameObject VillagerPrefab => _villagerPrefab;

		void IEntityBehaviourData.SpawnRequiredComponents(GameObject entityRoot)
		{
            entityRoot.GetOrAddComponent<Village>().Data = this;
		}
	}
}