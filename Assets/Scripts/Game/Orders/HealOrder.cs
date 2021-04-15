namespace Tartaros.Orders
{
	using Tartaros.Entities;
	using Tartaros.ServicesLocator;
	using UnityEngine;

	public class HealOrder : Order
	{
		#region Properties
		private static Sprite Icon => Services.Instance.Get<IconsDatabase>().Data.HealIcon;
		#endregion Properties

		#region Ctor
		public HealOrder(EntityHealWithCost healWithCostEntity) : base(Icon, healWithCostEntity.HealWholeLife)
		{ }
		#endregion Ctor
	}
}
