namespace Tartaros.Entities
{
	using System.Collections;
	using Tartaros.Economy;
	using Tartaros.Entities.Health;
	using Tartaros.Orders;
	using Tartaros.ServicesLocator;
	using UnityEngine;

	[RequireComponent(typeof(IHealthable))]
	[DisallowMultipleComponent]
	public class EntityHealWithCost : AEntityBehaviour, IOrderable
	{
		#region Fields
		private EntityHealWithCostData _data = null;
		private bool _healBlocked = false;
		private UserErrorsLogger _userErrorsLogger = null;
		private IPlayerSectorResources _playerSectorResources = null;
		private IHealthable _healthable = null;
		private EntityHealth _entityHealth = null;
		#endregion Fields

		#region Methods
		private void Awake()
		{
			_healthable = GetComponent<IHealthable>();
			_playerSectorResources = Services.Instance.Get<IPlayerSectorResources>();
			_data = Entity.GetBehaviourData<EntityHealWithCostData>();
			_entityHealth = GetComponent<EntityHealth>();
		}

		private void OnEnable()
		{
			_entityHealth.DamageTaken -= DamageTaken;
			_entityHealth.DamageTaken += DamageTaken;
		}

		private void OnDisable()
		{
			_entityHealth.DamageTaken -= DamageTaken;
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
			return _playerSectorResources.CanBuy(healCost) && _healBlocked == false;
		}

		private void BuyHeal()
		{
			ISectorResourcesWallet healCost = _data.GetCostToHeal(_healthable);
			_playerSectorResources.Buy(healCost);
		}

		private void DamageTaken(object sender, EntityHealth.DamageTakenArgs e)
		{
			if (_entityHealth.IsAlive && Entity.Team == Team.Player && Entity.EntityType == EntityType.Building)
			{
				StopCoroutine(DelayAfterTakingDamage());
				StartCoroutine(DelayAfterTakingDamage());
			}
		}



		IEnumerator DelayAfterTakingDamage()
		{
			float delayBeforeEnableRepair = 5f;

			_healBlocked = true;
			yield return new WaitForSeconds(delayBeforeEnableRepair);
			_healBlocked = false;


		}


		Order[] IOrderable.GenerateOrders()
		{
			return new Order[]
			{
					new HealOrder(this)
			};
		}
		#endregion Methods
	}
}
