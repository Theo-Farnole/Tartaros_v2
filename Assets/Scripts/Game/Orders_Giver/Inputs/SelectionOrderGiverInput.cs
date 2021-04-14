namespace Tartaros.OrderGiver
{
	using Tartaros.Entities;
	using Tartaros.ServicesLocator;
	using Tartaros.Utilities;
	using UnityEngine;

	public class SelectionOrderGiverInput : MonoBehaviour
	{
		#region Fields
		[SerializeField]
		private SelectionOrderGiver _selectionOrderGiver = null;

		private GameInputs _gameInputs = null;
		private Camera _camera = null;
		#endregion Fields

		#region Methods
		private void Awake()
		{
			_gameInputs = new GameInputs();
			_gameInputs.Orders.Enable();

			_camera = Camera.main;
		}

		private void OnEnable()
		{
			_gameInputs.Orders.MoveToOrAttack.performed -= MoveToOrAttack;
			_gameInputs.Orders.MoveToOrAttack.performed += MoveToOrAttack;
		}

		private void OnDisable()
		{
			_gameInputs.Orders.MoveToOrAttack.performed -= MoveToOrAttack;
		}

		private void MoveToOrAttack(UnityEngine.InputSystem.InputAction.CallbackContext obj)
		{
			GameObject gameObject = MouseHelper.GetGameObjectUnderCursor();

			if (gameObject == null)
			{
				Debug.Log("Nothing under cursor. No order has been given.");
				return;
			}

			if (gameObject.TryGetComponentInParent(out Entity entity) && IsEntityOpponentOfSelection(entity))
			{
				if (entity.TryGetComponent(out IAttackable attackable))
				{
					_selectionOrderGiver.Attack(attackable);
				}
				else
				{
					Debug.Log("Not attackable");
				}
			}
			else if (MouseHelper.GetHitUnderCursor(out RaycastHit hit))
			{
				_selectionOrderGiver.Move(hit.point);
			}
		}

		private bool IsEntityOpponentOfSelection(Entity entity)
		{
			if (_selectionOrderGiver.ControllableTeam.HasOpponent() == true)
			{
				return entity.Team == _selectionOrderGiver.ControllableTeam.GetOpponent();
			}
			else
			{
				Debug.LogFormat("Entity {0} is not an opponent of team {1}. If it is an unwanted behaviour, check if the SelectionManager's controllable team is not set to Neutral.", entity.name, _selectionOrderGiver.ControllableTeam);
				return false;
			}
		}
		#endregion Methods
	}
}
