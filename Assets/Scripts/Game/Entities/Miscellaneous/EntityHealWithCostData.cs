namespace Tartaros.Entities
{
	using System;
	using Tartaros.Economy;
	using UnityEngine;

	public class EntityHealWithCostData : IEntityBehaviourData
	{
		#region Fields
		[SerializeField]
		private ISectorResourcesWallet _fulllifeCost = null;
		#endregion Fields

		#region Ctor
		public EntityHealWithCostData()
		{
			_fulllifeCost = new SectorResourcesWallet(0, 10, 5);
		}

		public EntityHealWithCostData(ISectorResourcesWallet fulllifeCost)
		{
			_fulllifeCost = fulllifeCost ?? throw new ArgumentNullException(nameof(fulllifeCost));
		}
		#endregion Ctor

		#region Methods	
		public ISectorResourcesWallet GetCostToHeal(IHealthable healthable)
		{
			return GetCostToHeal(healthable.GetMissingHealthPoints(), healthable.MaxHealth);
		}

		public ISectorResourcesWallet GetCostToHeal(int hpToHeal, int maxHealth)
		{
			// equivalent of _fulllifeCost * health / maxHealth
			float multiplicator = ((float)hpToHeal / (float)maxHealth);

			return ISectorResourcesWalletMath.Multiply(_fulllifeCost, multiplicator);
		}

#if UNITY_EDITOR
		void IEntityBehaviourData.SpawnRequiredComponents(GameObject entityRoot)
		{
			entityRoot.GetOrAddComponent<EntityHealWithCost>();
		}
#endif
		#endregion Methods
	}
}
