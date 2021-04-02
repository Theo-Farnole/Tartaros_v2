namespace Tartaros.Entities
{
	using Assets.Scripts.Game.Orders;
	using Boo.Lang;
	using Tartaros.Economy;
	using Tartaros.Orders;
	using Tartaros.Population;
	using Tartaros.ServicesLocator;
	using UnityEngine;

	public class EntityUnitsSpawner : MonoBehaviour, IEntityOrderable
	{
		#region Fields
		[SerializeField]
		private EntityUnitsSpawnerData _data = null;

		private IPlayerSectorResources _playerResources = null;
		private IPopulationManager _populationManager = null;
		#endregion Fields

		#region Properties
		public ISpawnable[] SpawnablePrefabs => Data.SpawnablePrefabs;
		public EntityUnitsSpawnerData Data { get => _data; set => _data = value; }
		#endregion Properties

		#region Methods
		private void Start()
		{
			_playerResources = Services.Instance.Get<IPlayerSectorResources>();
			_populationManager = Services.Instance.Get<IPopulationManager>();
		}

		public void Spawn(ISpawnable prefabToSpawn)
		{
			if (CanSpawn(prefabToSpawn) == false)
			{
				Debug.LogErrorFormat("Entity {0} cannot spawn a {1}.", name, prefabToSpawn.Prefab.name);
				return;
			}

			Instantiate(prefabToSpawn.Prefab, GetSpawnPoint(), Quaternion.identity);
			_playerResources.RemoveWallet(Data.GetSpawnPrice(prefabToSpawn));
		}

		public bool CanSpawn(ISpawnable gameObject, bool logToUser = false)
		{
			if (CanBuy(gameObject) == false)
			{
				if (logToUser == true)
				{
					Services.Instance.Get<UserErrorsLogger>().Log("Not enough money to spawn {0}.", gameObject.ToString());
				}
				return false;
			}
			else if (HasEnoughPopulationToSpawn(gameObject) == false)
			{
				if (logToUser == true)
				{
					Services.Instance.Get<UserErrorsLogger>().Log("Not enough population to spawn {0}.", gameObject.ToString());
				}
				return false;
			}

			return true;
		}

		public bool CanBuy(ISpawnable gameObject)
		{
			return _playerResources.CanBuyWallet(Data.GetSpawnPrice(gameObject));
		}

		public bool HasEnoughPopulationToSpawn(ISpawnable gameObject)
		{
			return _populationManager.CanSpawn(gameObject.PopulationAmount);
		}

		Order[] IEntityOrderable.GenerateOrders(Entity entity)
		{
			List<Order> orders = new List<Order>();

			foreach (ISpawnable spawnable in SpawnablePrefabs)
			{
				orders.Add(new SpawnUnitOrder(spawnable, this));
			}

			return orders.ToArray();
		}

		private Vector3 GetSpawnPoint()
		{
			return transform.position + Vector3.right;
		}
		#endregion Methods
	}
}
