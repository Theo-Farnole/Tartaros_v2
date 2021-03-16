namespace Tartaros.Economy
{
    using Sirenix.OdinInspector;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class PlayerSectorResourcesData : SerializedScriptableObject
    {
        [SerializeField]
        private SectorResourcesWallet _wallet = null;

        public PlayerSectorResourcesData(SectorResourcesWallet wallet)
        {
            _wallet = wallet;
        }

        public SectorResourcesWallet Wallet => _wallet;
    }
}