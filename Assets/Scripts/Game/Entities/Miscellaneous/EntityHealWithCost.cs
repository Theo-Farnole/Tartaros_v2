namespace Tartaros.Entities
{
	using Tartaros.Economy;
	using Tartaros.Orders;
	using Tartaros.ServicesLocator;
	using UnityEngine;

	[RequireComponent(typeof(IHealthable))]
	[DisallowMultipleComponent]
	public class EntityHealWithCost : AEntityBehaviour, IOrderable
	{
		#region Fields
		private EntityHealWithCostData _data = null;

		private UserErrorsLogger _userErrorsLogger = null;
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
				BuyHeal();
				_healthable.HealMaxLife();
			}
			else
			{
				_userErrorsLogger.Log("Not enough resources to repair the building(s).");
			}
		}

		private bool CanBuyHeal()
		{
			ISectorResourcesWallet healCost = _data.GetCostToHeal(_healthable);
			return _playerSectorResources.CanBuy(healCost);
		}

		private void BuyHeal()
		{
			ISectorResourcesWallet healCost = _data.GetCostToHeal(_healthable);
			_playerSectorResources.Buy(healCost);
		}

		Order[] IOrderable.GenerateOrders()
		{
			if (_healthable.IsFullLife())
			{
				return null;
			}
			else
			{
				return new Order[]
				{
					new HealOrder(this)
				};
			}
		}
		#endregion Methods
	}
}
