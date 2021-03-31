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
            _playerGloryWallet = Services.Instance.Get<PlayerGloryWallet>();
        }

        private void OnEnable()
        {
            Entity.AnyEntitySpawned -= Entity_EntitySpawned;
            Entity.AnyEntitySpawned += Entity_EntitySpawned;

            Entity.AnyEntityKilled -= Entity_EntityKilled; 
            Entity.AnyEntityKilled += Entity_EntityKilled; 
        }
        private void OnDisable()
        {
            Entity.AnyEntitySpawned -= Entity_EntitySpawned;
            Entity.AnyEntityKilled -= Entity_EntityKilled; 
        }

        private void Entity_EntityKilled(object sender, Entity.EntityKilledArgs e)
        {
            if (e.entity.Team == Team.Enemy)
            {
                int gloryIncome = e.entity.EntityData.GetBehaviour<EntityGloryIncomeData>().GloryIncome;
                FillWallet(gloryIncome);
            }
        }

        private void Entity_EntitySpawned(object sender, Entity.EntitySpawnedArgs e)
        {
            if(e.entity.Team == Team.Player)
            {
                int gloryIncome = e.entity.EntityData.GetBehaviour<EntityGloryIncomeData>().GloryIncome;
                FillWallet(gloryIncome);
            }
        }


        void IPlayerGloryIncome.AddAmount(int amount)
        {
            FillWallet(amount);
        }

        private void FillWallet(int amount)
        {
            _playerGloryWallet.AddAmount(amount);
        }
    }
}