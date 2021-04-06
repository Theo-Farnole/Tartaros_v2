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
				// TODO (perf): use TryGetBehaviour
				if (e.entity.EntityData.HasBehaviour<EntityGloryIncomeData>() == true)
				{
					int gloryIncome = e.entity.EntityData.GetBehaviour<EntityGloryIncomeData>().GloryIncome;
					FillWallet(gloryIncome);

					Debug.LogFormat("Add {0} glory because {1} is killed.", gloryIncome, e.entity.name);
				}
				else
				{
					Debug.LogWarningFormat("No entity glory income data beahviour on entity data {0}.", e.entity.EntityData);
				}
			}
		}

		private void Entity_EntitySpawned(object sender, Entity.EntitySpawnedArgs e)
		{
			if (Time.timeSinceLevelLoad == 0) return; // skip already in scene entities

			if (e.entity.Team == Team.Player)
			{

				// TODO (perf): use TryGetBehaviour
				if (e.entity.EntityData.HasBehaviour<EntityGloryIncomeData>() == true)
				{
					int gloryIncome = e.entity.EntityData.GetBehaviour<EntityGloryIncomeData>().GloryIncome;
					FillWallet(gloryIncome);

					Debug.LogFormat("Add {0} glory because {1} is spawned.", gloryIncome, e.entity.name);
				}
				else
				{
					Debug.LogWarningFormat("No entity glory income data beahviour on entity data {0}.", e.entity.EntityData);
				}
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