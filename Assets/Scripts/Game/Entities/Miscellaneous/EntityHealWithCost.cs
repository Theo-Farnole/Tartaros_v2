namespace Tartaros.Entities
{
	using Tartaros.Economy;
	using Tartaros.Orders;
	using Tartaros.ServicesLocator;
	using UnityEngine;

	[RequireComponent(typeof(IHealthable))]
	public class EntityHealWithCost : AEntityBehaviour, IEntityOrderable
	{
		#region Fields
		private EntityHealWithCostData _data = null;

		private IPlayerSectorResources _playerSectorResources = null;
		private IHealthable _healthable = null;
		#endregion Fields

		#region Methods
		private void Awake()
		{
			_healthable = GetComponent<IHealthable>();
			_playerSectorResources = Services.Instance.Get<IPlayerSectorResources>();
			_data = Entity.GetBehaviourData<EntityHealWithCostData>();
		}

		public void HealWholeLife()
		{
			if (CanBuyHeal() == true)
			{
				_healthable.HealMaxLife();
			}
		}

		private bool CanBuyHeal()
		{
			ISectorResourcesWallet healCost = _data.GetCostToHeal(_healthable);
			return _playerSectorResources.CanBuy(healCost);
		}

		Order[] IEntityOrderable.GenerateOrders(Entity entity)
		{
			return new Order[]
			{
				new HealOrder(this)
			};
		}
		#endregion Methods
	}
}
