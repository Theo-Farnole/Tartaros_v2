namespace Tartaros.Entities
{
	using System;
	using System.Collections.Generic;
	using Tartaros.Economy;
	using Tartaros.Orders;
	using Tartaros.Selection;
	using Tartaros.ServicesLocator;
	using UnityEngine;

	[DisallowMultipleComponent]
	public class EntityWallToGate : AEntityBehaviour, IOrderable
	{
		//[SerializeField] private int _numberOfWallToInstanciateGate = 2;

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
			if (HaveEnoughSpace() == true)
			{
				List<Order> orders = new List<Order>();

				orders.Add(new InstanciateGateOrder(this));
				return orders.ToArray();
			}
			return null;
		}

		public void InstanciateGate()
		{
			if (CanSpawn())
			{
				Vector3 position = (transform.position + _neigboorManager.BackAdjacentWall.gameObject.transform.position) / 2;

				GameObject gate = GameObject.Instantiate(_data.GatePrefab, position, transform.rotation);

				_neigboorManager.BackAdjacentWall.GetComponent<EntityNeigboorWallManager>().BackAdjacentWall.GetComponent<Entity>().Kill(false);
				_neigboorManager.BackAdjacentWall.GetComponent<Entity>().Kill(false);
				_neigboorManager.FrontAdjacentWall.GetComponent<Entity>().Kill(false);

				this.GetComponent<Entity>().Kill(false);

				ISelection selction = Services.Instance.Get<CurrentSelection>();
				selction.Clear();
				selction.Add(gate.GetComponent<ISelectable>());
			}
		}

		public bool HaveEnoughSpace()
		{
			try
			{
				if (_neigboorManager != null && _neigboorManager.BackAdjacentWall == null || _neigboorManager.FrontAdjacentWall == null)
				{
					return false;
				}

				var managerBack = _neigboorManager.BackAdjacentWall.GetComponent<EntityNeigboorWallManager>();
				var managerDoubleBack = managerBack.BackAdjacentWall.GetComponent<EntityNeigboorWallManager>();

				return managerDoubleBack.FrontAdjacentWall != null && managerBack.BackAdjacentWall != null;
			}
			catch (NullReferenceException e)
			{
				return false;
			}
		}


		public bool CanSpawn()
		{
			return ISectorResourcesWalletExtensions.CanBuy(_playerResources, _data.GatePrice);
		}
	}
}