namespace Tartaros.Selection
{
	using Sirenix.OdinInspector;
	using UnityEngine;
	using UnityEngine.EventSystems;
	using UnityEngine.InputSystem;

	public class ClickSelectionInput : SerializedMonoBehaviour
	{
		#region Fields
		[SerializeField]
		private ISelection _selection = null;

		private GameInputs _gameInputs = null;
		#endregion Fields

		#region Properties
		private bool EnableAdditiveSelectionPerformed => _gameInputs.Selection.EnableAdditiveSelection.phase == InputActionPhase.Performed;
		#endregion Properties

		#region Methods
		private void Awake()
		{
			_gameInputs = new GameInputs();
		}

		private void OnEnable()
		{
			_gameInputs.Selection.Enable();

			_gameInputs.Selection.SelectEntity.performed -= OnSelectEntity;
			_gameInputs.Selection.SelectEntity.performed += OnSelectEntity;
		}

		private void OnDisable()
		{
			_gameInputs.Selection.SelectEntity.performed -= OnSelectEntity;
		}

		private void OnSelectEntity(InputAction.CallbackContext obj)
		{
			if (CanSelect() == false) return;

			if (EnableAdditiveSelectionPerformed == false)
			{
				_selection.ClearSelection();
			}

			if (TryGetISelectableUnderCursor(out ISelectable selectableUnderCursor) == true)
			{
				_selection.AlternateSelection(selectableUnderCursor);
			}
		}

		private bool TryGetISelectableUnderCursor(out ISelectable selectableUnderCursor)
		{
			if (RaycastUnderCursor(out RaycastHit hit))
			{
				if (hit.transform.gameObject.TryGetComponentInParent(out selectableUnderCursor))
				{
					return true;
				}
				else
				{
					Debug.LogFormat("User click on {0} but it is not a selectable.", hit.transform.name);
				}
			}

			selectableUnderCursor = null;
			return false;
		}

		private bool RaycastUnderCursor(out RaycastHit hit)
		{
			Vector2 mousePosition = Mouse.current.position.ReadValue();
			Ray ray = Camera.main.ScreenPointToRay(mousePosition);

			return Physics.Raycast(ray, out hit, Mathf.Infinity);
		}

		private bool CanSelect()
		{
			return IsPointerOverUI() == false;
		}

		private bool IsPointerOverUI()
		{
			if (EventSystem.current == null)
			{
				return false;
			}
			else
			{
				return EventSystem.current.IsPointerOverGameObject(-1);
			}
		}
		#endregion Methods
	}
}
