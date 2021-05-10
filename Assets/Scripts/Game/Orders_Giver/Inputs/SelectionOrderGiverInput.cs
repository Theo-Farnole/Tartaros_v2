namespace Tartaros.OrderGiver
{
	using System.Linq;
	using Tartaros.Entities;
	using Tartaros.Selection;
	using Tartaros.ServicesLocator;

	using UnityEngine;

	public class SelectionOrderGiverInput : MonoBehaviour
	{
		#region Fields
		[SerializeField]
		private SelectionOrderGiver _selectionOrderGiver = null;

		[SerializeField]
		private GameObject _prefabMoveVFX = null;

		private GameInputs _gameInputs = null;
		private Camera _camera = null;
		private GameObject _moveVFX = null;
		private ISelection _selection = null;
		#endregion Fields

		#region Methods
		private void Awake()
		{
			_gameInputs = new GameInputs();
			_gameInputs.Orders.Enable();

			_camera = Camera.main;
			_selection = Services.Instance.Get<CurrentSelection>();
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
			if (DoMoveableSelected() == false) return;

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
				PlayVFX(hit.point);
			}
		}

		private bool DoMoveableSelected()
		{
			return _selection.SelectedSelectables
				.Where(x => (x as MonoBehaviour).GetComponent<IOrderMoveReceiver>() != null)
				.Count() > 0;
		}

		private void PlayVFX(Vector3 position)
		{
			if (_moveVFX == null)
			{
				_moveVFX = Instantiate(_prefabMoveVFX);
			}

			_moveVFX.transform.position = position;
			_moveVFX.GetComponent<ParticleSystem>().Play();
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
