namespace Tartaros.Entities
{
    using System.Collections;
    using Tartaros.Economy;
    using UnityEngine;

    public class EntityWallToGateData : IEntityBehaviourData
    {
        [SerializeField]
        private GameObject _gatePrefab = null;
        [SerializeField]
        private ISectorResourcesWallet _gatePrice = null;

        public GameObject GatePrefab => _gatePrefab;
        public ISectorResourcesWallet GatePrice => _gatePrice;

        void IEntityBehaviourData.SpawnRequiredComponents(GameObject entityRoot)
        {
            EntityWallToGate wallToGate = entityRoot.AddComponent<EntityWallToGate>();
            NeigboorWallManager neigboorManager = entityRoot.AddComponent<NeigboorWallManager>();
            wallToGate.EntityWallToGateData = this;
            wallToGate.NeigboorManager = neigboorManager;
        }  
    }
}