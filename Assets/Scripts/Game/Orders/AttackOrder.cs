﻿namespace Tartaros.Orders
{
	using System;
	using Tartaros.Entities;
	using Tartaros.Gamemode;
	using Tartaros.OrderGiver;
	using Tartaros.ServicesLocator;
	using Tartaros.UI.HoverPopup;
	using UnityEngine;

	public class AttackOrder : Order
	{
		#region Properties
		private static Sprite Icon => Services.Instance.Get<IconsDatabase>().Data.AttackIcon;
		#endregion Properties

		#region Ctor
		public AttackOrder(Entity entity) : base(Icon, Create(entity), Services.Instance.Get<HoverPopupsDatabase>().Database.Attack)
		{ }
		#endregion Ctor

		private static Action Create(Entity entity)
		{
			return () =>
			{
				GamemodeManager gamemodeManager = Services.Instance.Get<GamemodeManager>();

				CatchRightClickState state = new CatchRightClickState(gamemodeManager, OrderAttackOnEntityUnderCursor(entity));

				gamemodeManager.SetState(state);
			};
		}

		private static Action OrderAttackOnEntityUnderCursor(Entity entity)
		{
			return () =>
			{
				GameObject gameObjectUnderCursor = MouseHelper.GetGameObjectUnderCursor();

				if (gameObjectUnderCursor.TryGetComponentInParent(out IAttackable attackableUnderCursor))
				{
					entity.GetComponent<IOrderAttackReceiver>().Attack(attackableUnderCursor);
				}
			};
		}
	}
}
