namespace Tartaros.OrderGiver
{
	using Sirenix.OdinInspector;
	using System;
	using System.Collections.Generic;
	using Tartaros.Entities;
	using Tartaros.Entities.Movement;
	using Tartaros.Selection;
	using Tartaros.ServicesLocator;
	using UnityEngine;

	public class SelectionOrderGiver : SerializedMonoBehaviour
	{
		#region Fields
		[SerializeField]
		private Team _controllableTeam = Team.Player;

		[SerializeField]
		private ISelection _selection = null;
		#endregion Fields

		#region Properties
		public Team ControllableTeam => _controllableTeam;
		#endregion Properties

		#region Methods		
		public void Stop()
		{
			CallAction<IOrderStopReceiver>(ctx => ctx.Stop());
		}

		public void Move(Vector3 position)
		{
			CallAction<IOrderMoveReceiver>(ctx => ctx.Move(position));
		}

		public void Move(Transform target)
		{
			CallAction<IOrderMoveReceiver>(ctx => ctx.Move(target));
		}

		public void MoveAdditive(Vector3 position)
		{
			CallAction<IOrderMoveReceiver>(ctx => ctx.MoveAdditive(position));
		}

		public void MoveAdditive(Transform target)
		{
			CallAction<IOrderMoveReceiver>(ctx => ctx.MoveAdditive(target));
		}

		public void Attack(IAttackable attackable)
		{
			CallAction<IOrderAttackReceiver>(ctx => ctx.Attack(attackable));
		}

		public void AttackAdditive(IAttackable attackable)
		{
			CallAction<IOrderAttackReceiver>(ctx => ctx.AttackAdditive(attackable));
		}

		public void MoveAggressively(Vector3 position)
		{
			CallAction<IOrderMoveAggresivellyReceiver>(ctx => ctx.MoveAggressively(position));
		}

		public void MoveAggressivelyAdditive(Vector3 position)
		{
			CallAction<IOrderMoveAggresivellyReceiver>(ctx => ctx.MoveAggressivelyAdditive(position));
		}

		public void Patrol(PatrolPoints patrolPoints)
		{
			CallAction<IOrderPatrolReceiver>(ctx => ctx.Patrol(patrolPoints));
		}

		public void PatrolAdditive(PatrolPoints patrolPoints)
		{
			CallAction<IOrderPatrolReceiver>(ctx => ctx.PatrolAdditive(patrolPoints));
		}

		private void CallAction<T>(Action<T> action)
		{
			foreach (T orderReceiver in GetSelectablesAs<T>())
			{
				action.Invoke(orderReceiver);
			}
		}

		private T[] GetSelectablesAs<T>()
		{
			List<T> output = new List<T>(_selection.SelectedSelectables.Length);

			foreach (ISelectable selectable in _selection.SelectedSelectables)
			{
				if (IsSelectableControllable(selectable) && GetSelectableAs(selectable, out T convertedEntity))
				{
					output.Add(convertedEntity);
				}
			}

			return output.ToArray();
		}

		private bool GetSelectableAs<T>(ISelectable selectable, out T convertedEntity)
		{
			return selectable.GameObject.TryGetComponent(out convertedEntity);
		}

		private bool IsSelectableControllable(ISelectable selectable)
		{
			return selectable.Team == _controllableTeam;
		}
		#endregion Methods
	}
}
