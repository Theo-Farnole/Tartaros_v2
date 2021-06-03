namespace Tartaros.Selection
{
	using Sirenix.OdinInspector;
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.EventSystems;
	using UnityEngine.InputSystem;

	public class DoubleClickSelectionInput : SerializedMonoBehaviour
	{
		#region Fields
		[SerializeField] private ISelection _selection = null;
		[SerializeField] private float _cancelMouseThreshold = 30; // move 30px = cancel double click

		private RectangleSelectionInput _rectangleSelection = null;
		private GameInputs _gameInputs = null;

		private Vector2 _startMousePosition = Vector2.zero;
		#endregion Fields

		#region Properties
		private bool EnableAdditiveSelectionPerformed => _gameInputs.Selection.EnableAdditiveSelection.phase == InputActionPhase.Performed;
		public Bounds BoundsCamera => GUIRectDrawer.GetViewportBounds(Camera.main, new Vector2(0, 0), new Vector2(Screen.width, Screen.height));
		#endregion Properties

		#region Methods
		private void Awake()
		{
			_gameInputs = new GameInputs();
			_rectangleSelection = GetComponent<RectangleSelectionInput>();


		}

		private void OnEnable()
		{
			_gameInputs.Selection.Enable();

			_gameInputs.Selection.DoubleClickSelection.started -= DoubleClickSelection_started;
			_gameInputs.Selection.DoubleClickSelection.started += DoubleClickSelection_started;

			_gameInputs.Selection.DoubleClickSelection.performed -= DoubleClickSelection_performed;
			_gameInputs.Selection.DoubleClickSelection.performed += DoubleClickSelection_performed;
		}

		private void OnDisable()
		{
			_gameInputs.Selection.DoubleClickSelection.performed -= DoubleClickSelection_performed;
			_gameInputs.Selection.DoubleClickSelection.started -= DoubleClickSelection_started;
		}

		private void DoubleClickSelection_started(InputAction.CallbackContext obj)
		{
			_startMousePosition = MouseHelper.CursorPosition;
		}

		private void DoubleClickSelection_performed(InputAction.CallbackContext obj)
		{
			if (_rectangleSelection.IsSelecting == true) return;

			if (CanSelect() == false) return;

			if (EnableAdditiveSelectionPerformed == false)
			{
				_selection.Clear();
			}

			if (TryGetISelectableUnderCursor(out ISelectable selectableUnderCursor) == true)
			{
				SelectSelectableOnCamera(selectableUnderCursor);
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
			}

			selectableUnderCursor = null;

			return false;
		}

		private void SelectSelectableOnCamera(ISelectable selectable)
		{
			ISelectable[] selectablesInGame = GetAllSelectablesInWorld();
			ISelectable[] selectablesInRect = SelectionHelper.GetSelectablesInRectangle(selectablesInGame, BoundsCamera);

			_selection.Add(SelectionHelper.GetSelectablesOfTheSameData(selectable, selectablesInRect));
		}

		private ISelectable[] GetAllSelectablesInWorld()
		{
			return ObjectsFinder.FindObjectsOfInterface<ISelectable>();
		}


		private bool RaycastUnderCursor(out RaycastHit hit)
		{
			Vector2 mousePosition = Mouse.current.position.ReadValue();
			Ray ray = Camera.main.ScreenPointToRay(mousePosition);

			return Physics.Raycast(ray, out hit, Mathf.Infinity);
		}


		private bool CanSelect()
		{
			return Vector2.Distance(_startMousePosition, MouseHelper.CursorPosition) <= _cancelMouseThreshold && IsPointerOverUI() == false;
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



		#endregion
	}
}