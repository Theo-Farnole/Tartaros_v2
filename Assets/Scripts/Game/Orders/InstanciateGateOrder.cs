namespace Tartaros.Orders
{
	using System;
	using System.Collections;
	using Tartaros.Entities;
	using Tartaros.Orders;
	using Tartaros.ServicesLocator;
	using Tartaros.UI.HoverPopup;
	using UnityEngine;

	public class InstanciateGateOrder : Order
	{
		private static Sprite Icon => Services.Instance.Get<IconsDatabase>().Data.InstanciateGateIcon;
		public InstanciateGateOrder(EntityWallToGate wallToGate) : base(Icon, InstanciateGate(wallToGate), Services.Instance.Get<HoverPopupsDatabase>().Database.TurnIntoGate)
		{
		}

		private static Action InstanciateGate(EntityWallToGate wallToGate)
		{
			return () =>
			{
				var userErrorLogger = Services.Instance.Get<UserErrorsLogger>();

				if (wallToGate.CanSpawn() && wallToGate.HaveEnoughSpace())
				{
					wallToGate.InstanciateGate();
				}
				else
				{
					userErrorLogger.Log("Cannot spawn wall");
				}
			};
		}
	}
}