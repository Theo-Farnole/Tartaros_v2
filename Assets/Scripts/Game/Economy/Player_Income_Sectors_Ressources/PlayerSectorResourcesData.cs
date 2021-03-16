namespace Tartaros.Economy
{
    using Sirenix.OdinInspector;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    [System.Serializable]
    public class PlayerSectorResourcesData : SerializedScriptableObject
    {
        [SerializeField]
        private ISectorResourcesWallet _wallet = null;

        public PlayerSectorResourcesData(ISectorResourcesWallet wallet)
        {
            _wallet = wallet;
        }

        public ISectorResourcesWallet Wallet => _wallet;
    }
}