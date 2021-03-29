namespace Tartaros.Economy
{
    using System.Collections;
    using System.Collections.Generic;
    using Tartaros.Entities;
    using Tartaros.ServicesLocator;
    using UnityEngine;

    public class PlayerGloryIncome : MonoBehaviour, IPlayerGloryIncome
    {
        private IPlayerGloryWallet _playerGloryWallet = null;

        private void Awake()
        { 
            Services.Instance.RegisterService(this);
        }

        private void Start()
        {
            _playerGloryWallet = Services.Instance.Get<IPlayerGloryWallet>();
        }

        private void OnEnable()
        {
            Entity.EntitySpawned -= Entity_EntitySpawned;
            Entity.EntitySpawned += Entity_EntitySpawned;
        }

        private void OnDisable()
        {
            Entity.EntitySpawned -= Entity_EntitySpawned;
        }

        private void Entity_EntitySpawned(object sender, Entity.EntitySpawnedArgs e)
        {
            throw new System.NotImplementedException();
        }

        void IPlayerGloryIncome.AddAmount(int amount)
        {
            _playerGloryWallet.AddAmount(amount);
        }
    }
}