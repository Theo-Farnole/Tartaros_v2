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
	using TMPro;
	using UnityEngine;

	[DisallowMultipleComponent]
	public class EntityUnitsSpawner : AEntityBehaviour, IOrderable
	{
		#region Fields
		[ShowInRuntime] private Queue<ISpawnable> _spawningQueue = new Queue<ISpawnable>();
		[ShowInRuntime] private float _nextSpawnTime = 0;
		[ShowInRuntime] private float _startSpawnTime = 0;

		private EntityUnitsSpawnerData _data = null;
		private IPlayerSectorResources _playerResources = null;
		private IPopulationManager _populationManager = null;
		private VillagerSpawnerManager _villagerSpawner = null;
		#endregion Fields

		#region Properties
		public ISpawnable[] Spawnables => Data.SpawnablePrefabs;
		public EntityUnitsSpawnerData Data { get => _data; set => _data = value; }
		public ISpawnable CurrentPrefabSpawning => _spawningQueue.Count > 0 ? _spawningQueue.Peek() : null;
		public float CurrentProgression
		{
			get
			{
				float current = Time.time;
				float duration = _nextSpawnTime - _startSpawnTime;
				float delta = current - _startSpawnTime;

				return delta / duration;

			}
		}
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
			if (_spawningQueue.IsPopulated() == true && Time.time >= _nextSpawnTime)
			{
				Spawn(_spawningQueue.Dequeue());

				if (_spawningQueue.IsPopulated() == true)
				{
					SpawnVillager(_spawningQueue.Peek());

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

		public int GetCountSpawnablesInQueue(ISpawnable prefab)
		{
			return _spawningQueue
				.Where(x => x == prefab)
				.Count();
		}

		public void CancelSpawn(ISpawnable spawnToCancel)
		{
			if (_spawningQueue.Contains(spawnToCancel))
			{
				var spawningPrefabBefore = CurrentPrefabSpawning;


				// 1. refund
				RefundEntitySpawn(spawnToCancel);

				// 2. remove from queue
				_spawningQueue = _spawningQueue.RemoveLastOccurenceOf(spawnToCancel);

				// 3. restart queue if needed
				bool currentSpawnHasChanged = spawningPrefabBefore == spawnToCancel && CurrentPrefabSpawning != spawnToCancel;

				if (currentSpawnHasChanged == true)
				{
					SetSpawnTimer();
				}
			}
		}

		public void EnqueueSpawn(ISpawnable prefabToSpawn)
		{
			if (CanSpawn(prefabToSpawn, true) == false)
			{
				Debug.LogErrorFormat("Entity {0} cannot spawn a {1}.", name, prefabToSpawn.Prefab.name);
				return;
			}

			_playerResources.RemoveWallet(Data.GetSpawnPrice(prefabToSpawn));

			if (_spawningQueue.IsPopulated() == false)
			{
				SpawnVillager(prefabToSpawn);
			}

			_spawningQueue.Enqueue(prefabToSpawn);
			SetSpawnTimer();
		}

		private void RefundEntitySpawn(ISpawnable toRefund)
		{
			_playerResources.AddWallet(Data.GetSpawnPrice(toRefund));
		}

		private void SpawnVillager(ISpawnable prefabToSpawn)
		{
			var archer = _data.SpawnablePrefabs[0];
			var hoplite = _data.SpawnablePrefabs[1];

			if (_villagerSpawner != null)
			{

				if (prefabToSpawn == archer)
				{
					_villagerSpawner.SpawnFuturArcher();
				}
				else if (prefabToSpawn == hoplite)
				{
					_villagerSpawner.SpawnFuturHoplite();
				}

			}
			else
			{
				Debug.LogWarningFormat("The variable VillagerSpawnerManager is nul on {0}", this.gameObject.name);
			}
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

			_startSpawnTime = Time.time;
			_nextSpawnTime = Time.time + _data.GetSpawnTime(_spawningQueue.Peek());
		}

		private void Spawn(ISpawnable prefabToSpawn)
		{
			Instantiate(prefabToSpawn.Prefab, GetSpawnPoint(), Quaternion.identity);
		}

		private Vector3 GetSpawnPoint()
		{
			return transform.position + Vector3.right * 2;
		}

		#region IOrderable
		Order[] IOrderable.GenerateOrders()
		{
			List<Order> orders = new List<Order>();

			foreach (ISpawnable spawnable in Spawnables)
			{
				orders.Add(new SpawnUnitOrder(spawnable, this));
			}

			return orders.ToArray();
		}
		#endregion IOrderable
		#endregion Methods
	}
}
