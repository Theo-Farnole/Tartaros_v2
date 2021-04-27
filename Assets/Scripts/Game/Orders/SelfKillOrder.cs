namespace Tartaros.Orders
{
	using Tartaros;
	using Tartaros.Entities;
	using Tartaros.ServicesLocator;
	using Tartaros.UI.HoverPopup;
	using UnityEngine;

	public class SelfKillOrder : Order
	{
		public static Sprite Icon => Services.Instance.Get<IconsDatabase>().Data.SelfKillIcon;

		public SelfKillOrder(Entity entity) : base(Icon, entity.Kill, Services.Instance.Get<HoverPopupsDatabase>().Database.SelfKill)
		{ }
	}
}
