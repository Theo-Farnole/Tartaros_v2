namespace Assets.Scripts.Game.Orders
{
	using System;
	using Tartaros.Entities;
	using Tartaros.Orders;

	public class SpawnUnitOrder : Order
	{
		public SpawnUnitOrder(ISpawnable spawnable, EntityUnitsSpawner spawner) : base(spawnable.Portrait, CreateAction(spawnable, spawner), null)
		{ }

		private static Action CreateAction(ISpawnable spawnable, EntityUnitsSpawner spawner)
		{
			return () =>
			{
				if (spawner.CanSpawn(spawnable, true))
				{
					spawner.Spawn(spawnable);
				}
			};
		}
	}
}
