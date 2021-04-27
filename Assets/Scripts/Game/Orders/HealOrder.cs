namespace Tartaros.Orders
{
	using Tartaros.Entities;
	using Tartaros.ServicesLocator;
	using Tartaros.UI.HoverPopup;
	using UnityEngine;

	public class HealOrder : Order
	{
		#region Properties
		private static Sprite Icon => Services.Instance.Get<IconsDatabase>().Data.HealIcon;
		#endregion Properties

		#region Ctor
		public HealOrder(EntityHealWithCost healWithCostEntity) : base(Icon, healWithCostEntity.HealWholeLife, Services.Instance.Get<HoverPopupsDatabase>().Database.Heal)
		{ }
		#endregion Ctor
	}
}
