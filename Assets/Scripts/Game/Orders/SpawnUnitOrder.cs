namespace Assets.Scripts.Game.Orders
{
	using System;
	using Tartaros;
	using Tartaros.Entities;
	using Tartaros.Orders;
	using Tartaros.ServicesLocator;

	public class SpawnUnitOrder : Order
	{
		public SpawnUnitOrder(ISpawnable spawnable, EntityUnitsSpawner spawner) : base(spawnable.Portrait, CreateAction(spawnable, spawner))
		{ }

		private static Action CreateAction(ISpawnable spawnable, EntityUnitsSpawner spawner)
		{
			return () =>
			{
				if (spawner.CanSpawn(spawnable))
				{
					spawner.Spawn(spawnable);
				}
				else
				{
					Services.Instance.Get<UserErrorsLogger>().Log("Not enough money to format {0}.", spawnable.ToString());
				}
			};
		}
	}
}
