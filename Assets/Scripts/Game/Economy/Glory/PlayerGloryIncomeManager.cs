namespace Tartaros.Economy
{
	using Tartaros.Entities;
	using Tartaros.ServicesLocator;
	using Tartaros.UI;
	using UnityEngine;

	public class PlayerGloryIncomeManager : MonoBehaviour
	{
		[SerializeField]
		private Vector3 _textPositionOffset = new Vector3(0, 0.5f, 0);

		[SerializeField]
		private EarnGloryText _prefabGloryText = null;

		private IPlayerGloryWallet _playerGloryWallet = null;

		private void Awake()
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
					AddGlory(e.entity.transform, gloryIncome);

					//Debug.LogFormat("Add {0} glory because {1} is killed.", gloryIncome, e.entity.name);
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
					AddGlory(e.entity.transform, gloryIncome);

					//Debug.LogFormat("Add {0} glory because {1} is spawned.", gloryIncome, e.entity.name);
				}
				else
				{
					Debug.LogWarningFormat("No entity glory income data beahviour on entity data {0}.", e.entity.EntityData);
				}
			}
		}

		private void AddGlory(Transform sender, int amount)
		{
			InstantiateGloryText(sender, amount);

			_playerGloryWallet.AddAmount(amount);
		}

		private void InstantiateGloryText(Transform sender, int amount)
		{
			if (_prefabGloryText != null)
			{
				var x = Instantiate(_prefabGloryText, sender.position + _textPositionOffset, Quaternion.identity);
				x.EarnedGloryAmount = amount;
			}
			else
			{
				Debug.LogError("Missing prefab in Player Glory Income Manager", gameObject);
			}
		}
	}
}