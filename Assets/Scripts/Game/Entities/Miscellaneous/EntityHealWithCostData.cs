namespace Tartaros.Entities
{
	using System;
	using Tartaros.Economy;
	using UnityEngine;

	[Serializable]
	public class EntityHealWithCostData : IEntityBehaviourData
	{
		#region Fields
		[SerializeField]
		private ISectorResourcesWallet _fulllifeCost = null;
		#endregion Fields

		public EntityHealWithCostData()
		{
			_fulllifeCost = new SectorResourcesWallet(0, 10, 5);
		}

		#region Methods	
		public ISectorResourcesWallet GetCostToHeal(IHealthable healthable)
		{
			return GetCostToHeal(healthable.GetMissingHealthPoints(), healthable.MaxHealth);
		}

		public ISectorResourcesWallet GetCostToHeal(int hpToHeal, int maxHealth)
		{
			// equivalent of _fulllifeCost * health / maxHealth
			return ISectorResourcesWalletMath.Multiply(_fulllifeCost, (hpToHeal / maxHealth));
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
