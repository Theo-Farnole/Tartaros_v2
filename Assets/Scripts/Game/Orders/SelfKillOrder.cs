namespace Tartaros.Orders
{
	using Tartaros;
	using Tartaros.Entities;
	using Tartaros.ServicesLocator;
	using UnityEngine;

	public class SelfKillOrder : Order
	{
		public static Sprite Icon => Services.Instance.Get<IconsDatabase>().Data.SelfKillIcon;

		public SelfKillOrder(Entity entity) : base(Icon, entity.Kill)
		{ }
	}
}
