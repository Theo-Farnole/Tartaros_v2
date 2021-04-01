namespace Assets.Scripts.Game.UI.Selections.OneEntitySelected
{
	using Sirenix.OdinInspector;
	using Tartaros.Entities;
	using Tartaros.Orders;
	using Tartaros.Selection;
	using Tartaros.ServicesLocator;
	using Tartaros.UI;
	using UnityEngine;

	public class OneEntitySelectedPanel : APanel
	{
		#region Fields
		[SerializeField]
		[SuffixLabel("self if null")]
		private UIOrderButtonsGenerator _topButtons = null;

		private ISelection _currentSelection = null;
		#endregion Fields

		#region Methods
		protected override void Awake()
		{
			base.Awake();

			_topButtons = GetComponent<UIOrderButtonsGenerator>();
		}

		private void Start()
		{
			_currentSelection = Services.Instance.Get<CurrentSelection>();

			_currentSelection.SelectionChanged -= SelectionChanged;
			_currentSelection.SelectionChanged += SelectionChanged;
		}

		private void OnEnable()
		{
			if (_currentSelection != null)
			{
				_currentSelection.SelectionChanged -= SelectionChanged;
				_currentSelection.SelectionChanged += SelectionChanged;
			}
		}

		private void OnDisable()
		{
			_currentSelection.SelectionChanged -= SelectionChanged;
		}

		private void SelectionChanged(object sender, SelectionChangedArgs e)
		{
			if (_currentSelection.SelectedSelectables.Length == 1)
			{
				ISelectable firtSelectable = _currentSelection.SelectedSelectables[0];

				if (firtSelectable.GameObject.TryGetComponent(out Entity entity))
				{
					_topButtons.GenerateButtons(entity);
					Show();
				}
			}
			else
			{
				Hide();
			}
		}
		#endregion Methods
	}
}
