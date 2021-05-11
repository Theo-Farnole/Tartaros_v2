namespace Tartaros.Entities
{
	using Assets.Scripts.Game.Orders;
	using System.Collections.Generic;
	using System.Linq;
	using Tartaros.Economy;
	using Tartaros.Orders;
	using Tartaros.Population;
	using Tartaros.Selection;
	using Tartaros.ServicesLocator;
	using UnityEngine;

	[DisallowMultipleComponent]
	public class EntityUnitsSpawner : AEntityBehaviour, IOrderable
	{
		#region Fields
		[ShowInRuntime]
		private Queue<ISpawnable> _spawningQueue = new Queue<ISpawnable>();
		[ShowInRuntime]
		private float _spawnNextInQueueSpawn = 0;

		private EntityUnitsSpawnerData _data = null;
		private IPlayerSectorResources _playerResources = null;
		private IPopulationManager _populationManager = null;
		private VillagerSpawnerManager _villagerSpawner = null;
		#endregion Fields

		#region Properties
		public ISpawnable[] SpawnablePrefabs => Data.SpawnablePrefabs;
		public EntityUnitsSpawnerData Data { get => _data; set => _data = value; }
		#endregion Properties

		#region Methods
		private void Awake()
		{
			_playerResources = Services.Instance.Get<IPlayerSectorResources>();
			_populationManager = Services.Instance.Get<IPopulationManager>();

			_data = Entity.GetBehaviourData<EntityUnitsSpawnerData>();
		}

		private void OnEnable()
		{
			_villagerSpawner = GetComponent<VillagerSpawnerManager>();
		}

		private void Update()
		{
			if (_spawningQueue.IsPopulated() == true && Time.time >= _spawnNextInQueueSpawn)
			{
				Spawn(_spawningQueue.Dequeue());

				if (_spawningQueue.IsPopulated() == true)
				{
					SetSpawnTimer();
				}
			}
		}

		private void OnGUI()
		{
			if ((Services.Instance.Get<CurrentSelection>() as ISelection).SelectedSelectables.Contains(GetComponent<ISelectable>()) == true)
			{
				foreach (var toSpawn in _spawningQueue)
				{
					GUILayout.Label(toSpawn.ToString());
				}
			}
		}

		public ISectorResourcesWallet GetSpawnPrice(ISpawnable gameObject) => _data.GetSpawnPrice(gameObject);

		public void EnqueueEntitySpawn(ISpawnable prefabToSpawn)
		{
			if (CanSpawn(prefabToSpawn, true) == false)
			{
				Debug.LogErrorFormat("Entity {0} cannot spawn a {1}.", name, prefabToSpawn.Prefab.name);
				return;
			}

			_playerResources.RemoveWallet(Data.GetSpawnPrice(prefabToSpawn));
			_spawningQueue.Enqueue(prefabToSpawn);

			if(_villagerSpawner != null)
			{
				_villagerSpawner.SpawnFuturHoplite();
			}
			else
			{
				Debug.LogWarningFormat("The variable VillagerSpawnerManager is nul on {0}", this.gameObject.name);
			}

			SetSpawnTimer();
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
			return ISectorResourcesWalletExtensions.CanBuy(_playerResources, Data.GetSpawnPrice(gameObject));
		}

		public bool HasEnoughPopulationToSpawn(ISpawnable gameObject)
		{
			return _populationManager.CanSpawn(gameObject.PopulationAmount);
		}

		private void SetSpawnTimer()
		{
			if (_spawningQueue.IsEmpty() == true) throw new System.NotSupportedException("Cannot set spawn timer if the queue is empty.");

			_spawnNextInQueueSpawn = Time.time + _data.GetSpawnTime(_spawningQueue.Peek());
		}

		private void Spawn(ISpawnable prefabToSpawn)
		{
			Instantiate(prefabToSpawn.Prefab, GetSpawnPoint(), Quaternion.identity);
		}

		private Vector3 GetSpawnPoint()
		{
			return transform.position + Vector3.right;
		}

		#region IOrderable
		Order[] IOrderable.GenerateOrders()
		{
			List<Order> orders = new List<Order>();

			foreach (ISpawnable spawnable in SpawnablePrefabs)
			{
				orders.Add(new SpawnUnitOrder(spawnable, this));
			}

			return orders.ToArray();
		}
		#endregion IOrderable
		#endregion Methods
	}
}
