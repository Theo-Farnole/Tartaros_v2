namespace Assets.Scripts.Game.Orders
{
	using System;
	using Tartaros.Entities;
	using Tartaros.Orders;
	using Tartaros.UI.HoverPopup;

	public class SpawnUnitOrder : Order
	{
		public SpawnUnitOrder(ISpawnable spawnable, EntityUnitsSpawner spawner) : base(spawnable.Portrait, CreateAction(spawnable, spawner), GetHoverPopupData(spawnable, spawner))
		{ }

		private static HoverPopupData GetHoverPopupData(ISpawnable spawnable, EntityUnitsSpawner spawner)
		{
			return new HoverPopupData(spawnable.HoverPopupData)
			{
				SectorResourcesCost = spawner.GetSpawnPrice(spawnable)
			};
		}

		private static Action CreateAction(ISpawnable spawnable, EntityUnitsSpawner spawner)
		{
			return () =>
			{
				if (spawner.CanSpawn(spawnable, true))
				{
					spawner.EnqueueSpawn(spawnable);
				}
			};
		}
	}
}
