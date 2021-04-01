namespace Tartaros.Entities
{
	using Boo.Lang;
	using Tartaros.Economy;
	using Tartaros.Orders;
	using Tartaros.ServicesLocator;
	using UnityEngine;

	public class EntityUnitsSpawner : MonoBehaviour, IEntityOrderable
	{
		#region Fields
		[SerializeField]
		private EntityUnitsSpawnerData _data = null;

		private IPlayerSectorResources _playerResources = null;
		#endregion Fields

		#region Properties
		public ISpawnable[] SpawnablePrefabs => Data.SpawnablePrefabs;
		public EntityUnitsSpawnerData Data { get => _data; set => _data = value; }
		#endregion Properties

		#region Methods
		private void Start()
		{
			_playerResources = Services.Instance.Get<IPlayerSectorResources>();
		}

		public void Spawn(ISpawnable prefabToSpawn)
		{
			if (CanSpawn(prefabToSpawn) == true)
			{
				Instantiate(prefabToSpawn.Prefab);
				_playerResources.RemoveWallet(Data.GetPriceToSpawn(prefabToSpawn));
			}
			else
			{
				Debug.LogErrorFormat("Entity {0} cannot spawn a {1}.", name, prefabToSpawn.Prefab.name);
				return;
			}
		}

		public bool CanSpawn(ISpawnable entityData)
		{
			return Data.CanSpawn(entityData);
		}

		Order[] IEntityOrderable.GenerateOrders(Entity entity)
		{
			List<Order> orders = new List<Order>();

			foreach (ISpawnable spawnable in SpawnablePrefabs)
			{
				throw new System.NotImplementedException();
			}

			return orders.ToArray();
		}
		#endregion Methods
	}
}
