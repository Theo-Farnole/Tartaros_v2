namespace Tartaros.Entities
{
	using System.Collections.Generic;
	using Tartaros.Economy;
	using Tartaros.Orders;
	using Tartaros.Selection;
	using Tartaros.ServicesLocator;
	using UnityEngine;

	[DisallowMultipleComponent]
	public class EntityWallToGate : AEntityBehaviour, IOrderable
	{
		private EntityWallToGateData _data = null;
		private IconsDatabase _iconsDataBase = null;
		private IPlayerSectorResources _playerResources = null;
		private EntityNeigboorWallManager _neigboorManager = null;

		public IconsDatabase IconData => _iconsDataBase;

		public EntityWallToGateData EntityWallToGateData { get => _data; set => _data = value; }
		public EntityNeigboorWallManager NeigboorManager { get => _neigboorManager; set => _neigboorManager = value; }

		private void Awake()
		{
			_iconsDataBase = Services.Instance.Get<IconsDatabase>();
			_playerResources = Services.Instance.Get<IPlayerSectorResources>();
			_neigboorManager = GetComponent<EntityNeigboorWallManager>();

			_data = Entity.GetBehaviourData<EntityWallToGateData>();
		}

		Order[] IOrderable.GenerateOrders()
		{
			List<Order> orders = new List<Order>();

			orders.Add(new InstanciateGateOrder(this));
			return orders.ToArray();
		}

		public void InstanciateGate()
		{
			if (CanSpawn())
			{
				Vector3 position = (transform.position + _neigboorManager.BackAdjacentWall.gameObject.transform.position) / 2;

				GameObject gate = GameObject.Instantiate(_data.GatePrefab, position, transform.rotation);

				_neigboorManager.BackAdjacentWall.GetComponent<Entity>().Kill();
				this.GetComponent<Entity>().Kill();

				ISelection selction = Services.Instance.Get<CurrentSelection>();
				selction.ClearSelection();
				selction.AddToSelection(gate.GetComponent<ISelectable>());
			}
		}

		public bool HaveEnoughSpace()
		{
			return _neigboorManager.FrontAdjacentWall != null && _neigboorManager.BackAdjacentWall != null;
		}


		public bool CanSpawn()
		{
			return ISectorResourcesWalletExtensions.CanBuy(_playerResources, _data.GatePrice);
		}
	}
}