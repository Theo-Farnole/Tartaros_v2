namespace Tartaros.OrderGiver
{
	using Sirenix.OdinInspector;
	using System;
	using System.Collections.Generic;
	using Tartaros.Entities;
	using Tartaros.Entities.Movement;
	using Tartaros.Selection;
	using Tartaros.ServicesLocator;
	using Tartaros.SoundsSystem;
	using Tartaros.SoundsSystem;
	using UnityEngine;

	public class SelectionOrderGiver : SerializedMonoBehaviour
	{
		#region Fields
		[SerializeField] private Team _controllableTeam = Team.Player;
		[SerializeField] private ISelection _selection = null;
		[SerializeField] private SoundsHandler _soundsHandler = null;
		#endregion Fields

		#region Properties
		public Team ControllableTeam => _controllableTeam;
		#endregion Properties

		#region Methods		
		private void Awake()
		{
			_soundsHandler = Services.Instance.Get<SoundsHandler>();
		}

		public void Stop()
		{
			CallAction<IOrderStopReceiver>(ctx => ctx.Stop());
			_soundsHandler.Play(Sound.OrderStop);
		}

		public void Move(Vector3 position)
		{
			CallAction<IOrderMoveReceiver>(ctx => ctx.Move(position));
			_soundsHandler.Play(Sound.OrderMove);
		}

		public void Move(Transform target)
		{
			CallAction<IOrderMoveReceiver>(ctx => ctx.Follow(target));
			_soundsHandler.Play(Sound.OrderMove);
		}

		public void MoveAdditive(Vector3 position)
		{
			CallAction<IOrderMoveReceiver>(ctx => ctx.EnqueueMove(position));
			_soundsHandler.Play(Sound.OrderMove);
		}

		public void MoveAdditive(Transform target)
		{
			CallAction<IOrderMoveReceiver>(ctx => ctx.EnqueueFollow(target));
			_soundsHandler.Play(Sound.OrderMove);
		}

		public void Attack(IAttackable attackable)
		{
			CallAction<IOrderAttackReceiver>(ctx => ctx.Attack(attackable));
			_soundsHandler.Play(Sound.OrderAttack);
		}

		public void AttackAdditive(IAttackable attackable)
		{
			CallAction<IOrderAttackReceiver>(ctx => ctx.AttackAdditive(attackable));
			_soundsHandler.Play(Sound.OrderAttack);
		}

		public void MoveAggressively(Vector3 position)
		{
			CallAction<IOrderMoveAggresivellyReceiver>(ctx => ctx.MoveAggressively(position));
			_soundsHandler.Play(Sound.OrderMove);
		}

		public void MoveAggressivelyAdditive(Vector3 position)
		{
			CallAction<IOrderMoveAggresivellyReceiver>(ctx => ctx.MoveAggressivelyAdditive(position));
			_soundsHandler.Play(Sound.OrderMove);
		}

		public void Patrol(PatrolPoints patrolPoints)
		{
			CallAction<IOrderPatrolReceiver>(ctx => ctx.Patrol(patrolPoints));
			_soundsHandler.Play(Sound.OrderPatrol);
		}

		public void PatrolAdditive(PatrolPoints patrolPoints)
		{
			CallAction<IOrderPatrolReceiver>(ctx => ctx.EnqueuePatrol(patrolPoints));
			_soundsHandler.Play(Sound.OrderPatrol);
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
			ISelectable[] selectedObjects = _selection.Objects;

			List<T> output = new List<T>(selectedObjects.Length);

			foreach (ISelectable selectable in selectedObjects)
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
