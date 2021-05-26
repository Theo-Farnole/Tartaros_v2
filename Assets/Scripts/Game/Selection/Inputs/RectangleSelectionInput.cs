namespace Tartaros.Selection
{
	using Sirenix.OdinInspector;
	using UnityEngine;
	using UnityEngine.InputSystem;
	using UnityEngine.InputSystem.Controls;

	class RectangleSelectionInput : SerializedMonoBehaviour
	{
		#region Fields
		[SerializeField]
		private ISelection _selection = null;

		[SerializeField]
		private float _startSelectionDelta = 15;

		[SerializeField]
		[Required]
		private SelectionRectangle _selectionRectangle = null;

		private bool _isButtonDown = false;
		private Vector2 _startingPosition = Vector2.zero;

		private GameInputs _gameInputs = null;
		#endregion Fields

		#region Properties
		public bool IsSelecting => _isButtonDown == true && Vector2.Distance(_startingPosition, Mouse.current.position.ReadValue()) >= _startSelectionDelta;
		#endregion Properties

		#region Methods
		private void Awake()
		{
			_gameInputs = new GameInputs();
			_gameInputs.Selection.Enable();
		}

		private void Update()
		{
			if (_isButtonDown == true)
			{
				_selectionRectangle.PositionTwo = Mouse.current.position.ReadValue();
			}

			_selectionRectangle.enabled = IsSelecting;
		}

		private void OnEnable()
		{
			_gameInputs.Selection.StartSelectionRectangle.performed -= StartSelectionRectangle_performed;
			_gameInputs.Selection.StartSelectionRectangle.performed += StartSelectionRectangle_performed;

			_gameInputs.Selection.EndSelectionRectangle.performed -= EndSelectionRectangle_performed;
			_gameInputs.Selection.EndSelectionRectangle.performed += EndSelectionRectangle_performed;
		}

		private void OnDisable()
		{
			_gameInputs.Selection.StartSelectionRectangle.performed -= StartSelectionRectangle_performed;
			_gameInputs.Selection.EndSelectionRectangle.performed -= EndSelectionRectangle_performed;

			_isButtonDown = false;
		}

		private void StartSelectionRectangle_performed(InputAction.CallbackContext obj)
		{
			_isButtonDown = true;

			_startingPosition = Mouse.current.position.ReadValue();
			_selectionRectangle.PositionOne = _startingPosition;
		}

		private void EndSelectionRectangle_performed(InputAction.CallbackContext obj)
		{
			if (IsSelecting == true)
			{
				ISelectable[] selectablesInRect = _selectionRectangle.GetSelectablesInRectangle();
				_selection.Add(selectablesInRect);
			}

			_isButtonDown = false;
		}
		#endregion Methods
	}
}
