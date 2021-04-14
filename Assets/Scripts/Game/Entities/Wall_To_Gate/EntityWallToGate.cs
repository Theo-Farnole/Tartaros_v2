namespace Tartaros.Entities
{
	using System.Collections;
	using System.Collections.Generic;
	using Tartaros.Economy;
	using Tartaros.Orders;
	using Tartaros.Selection;
	using Tartaros.ServicesLocator;
	using UnityEngine;

	public class EntityWallToGate : AEntityBehaviour, IEntityOrderable
	{
		private EntityWallToGateData _data = null;
		private IconsDatabase _iconsDataBase = null;
		private IPlayerSectorResources _playerResources = null;
		private NeigboorWallManager _neigboorManager = null;

		[SerializeField]
		private Entity _previousAdjacentWall = null;
		[SerializeField]
		private Entity _nextAdjacentWall = null;
		[SerializeField]
		private Entity _rightAdjacecntWall = null;
		[SerializeField]
		private Entity _leftAdjacentWall = null;

		public Entity PreviousAdjacentWall => _previousAdjacentWall;
		public Entity NextAdjacentWall { get => _nextAdjacentWall; set => _nextAdjacentWall = value; }

		public IconsDatabase IconData => _iconsDataBase;

		public EntityWallToGateData EntityWallToGateData { get => _data; set => _data = value; }
		public NeigboorWallManager NeigboorManager { get => _neigboorManager; set => _neigboorManager = value; }

		private void Awake()
		{
			_iconsDataBase = Services.Instance.Get<IconsDatabase>();
			_playerResources = Services.Instance.Get<IPlayerSectorResources>();

			_data = Entity.GetBehaviourData<EntityWallToGateData>();
		}

		Order[] IEntityOrderable.GenerateOrders(Entity entity)
		{
			List<Order> orders = new List<Order>();

			orders.Add(new InstanciateGateOrder(this));
			return orders.ToArray();
		}

		public void InstanciateGate()
		{
			if (CanSpawn())
			{
				Vector3 position = (transform.position + _neigboorManager.PreviousAdjacentWall.gameObject.transform.position) / 2;

				GameObject gate = GameObject.Instantiate(_data.GatePrefab, position, transform.rotation);
				Destroy(_neigboorManager.PreviousAdjacentWall.gameObject);
				Destroy(this.gameObject);

				ISelection selction = Services.Instance.Get<CurrentSelection>();
				selction.ClearSelection();
				selction.AddToSelection(gate.GetComponent<ISelectable>());
			}
		}

		public bool HaveEnoughSpace()
		{
			return _neigboorManager.NextAdjacentWall != null && _neigboorManager.PreviousAdjacentWall != null;
		}


		public bool CanSpawn()
		{
			return _playerResources.CanBuyWallet(_data.GatePrice);
		}
	}
}