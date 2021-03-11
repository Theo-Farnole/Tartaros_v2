namespace Tartaros.OrderGiver
{
	using Tartaros.Entities;
	using Tartaros.ServicesLocator;
	using Tartaros.Utilities;
	using UnityEngine;

	public class OrderGiverInput : MonoBehaviour
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
			GameObject gameObject = CursorHelper.GetGameObjectUnderCursor();

			if (gameObject == null)
			{
				Debug.Log("Nothing under cursor. No order has been given.");
				return;
			}

			if (gameObject.TryGetComponent(out Entity entity) && entity.Team == Team.Enemy)
			{
				if (entity.TryGetComponent(out IAttackable attackable))
				{
					Debug.Log("Attack");
					_selectionOrderGiver.Attack(attackable);
				}
				else
				{
					Debug.Log("Not enemy clicked on Attack");

				}
			}
			else if (CursorHelper.GetHitUnderCursor(out RaycastHit hit))
			{
				Debug.Log("Move");
				_selectionOrderGiver.Move(hit.point);
			}
		}
		#endregion Methods
	}
}
