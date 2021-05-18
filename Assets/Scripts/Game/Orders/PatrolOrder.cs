namespace Tartaros.Orders
{
	using System;
	using System.Collections;
	using Tartaros.Entities;
	using Tartaros.Entities.Movement;
	using Tartaros.Gamemode;
	using Tartaros.OrderGiver;
	using Tartaros.ServicesLocator;
	using Tartaros.UI.HoverPopup;
	using UnityEngine;

	public class PatrolOrder : Order
	{
		private static Sprite Icon => Services.Instance.Get<IconsDatabase>().Data.PatrolIcon;
		public PatrolOrder(EntityMovement entityMovement) : base(Icon, Services.Instance.Get<HoverPopupsDatabase>().Database.Patrol)
		{
			_executeAction = Create(entityMovement, this);
		}

		// Use this for initialization
		private static Action Create(EntityMovement entityMovement, Order order)
		{
			return () =>
			{
				GamemodeManager gamemodeManager = Services.Instance.Get<GamemodeManager>();

				CatchRightClickState state = new CatchRightClickState(gamemodeManager, GetFirstPatrolPoint(entityMovement, order), order);

				gamemodeManager.SetState(state);
			};
		}


		private static Action GetFirstPatrolPoint(EntityMovement entityMovement, Order order)
		{
			return () =>
			{
				var userErrorLogger = Services.Instance.Get<UserErrorsLogger>();
				RaycastHit hit;
				bool gameObjectUnderCursor = MouseHelper.GetHitUnderCursor(out hit);
				Vector3 position = hit.point;

				if (entityMovement.CanMoveToPoint(position))
				{
					GamemodeManager gamemodeManager = Services.Instance.Get<GamemodeManager>();

					CatchRightClickState state = new CatchRightClickState(gamemodeManager, OrderSetPatrol(entityMovement, position), order);


					gamemodeManager.SetState(state);
				}
				else
				{
					userErrorLogger.Log("FirstPatrolPoint isn't valable");
				}
			};
		}

		private static Action OrderSetPatrol(EntityMovement entityMovement, Vector3 firstPosition)
		{
			return () =>
			{
				var userErrorLogger = Services.Instance.Get<UserErrorsLogger>();

				RaycastHit hit;
				bool gameObjectUnderCursor = MouseHelper.GetHitUnderCursor(out hit);
				Vector3 secondPosition = hit.point;

				PatrolPoints patrolPoints = new PatrolPoints(firstPosition, secondPosition);

				if (entityMovement.CanMoveToPoint(secondPosition))
				{
					entityMovement.GetComponent<IOrderPatrolReceiver>().Patrol(patrolPoints);
				}
				else
				{
					userErrorLogger.Log("SecondPatrolPoint isn't valable");
				}
			};
		}
	}
}