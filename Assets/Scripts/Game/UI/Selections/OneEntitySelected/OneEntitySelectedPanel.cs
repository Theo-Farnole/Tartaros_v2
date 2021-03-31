namespace Assets.Scripts.Game.UI.Selections.OneEntitySelected
{
	using Tartaros.Selection;
	using Tartaros.ServicesLocator;
	using Tartaros.UI;

	public class OneEntitySelectedPanel : APanel
	{
		#region Fields
		private ISelection _currentSelection = null;
		#endregion Fields

		#region Methods
		private void Start()
		{
			_currentSelection = Services.Instance.Get<ISelection>();

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
				Show();
			}
			else
			{
				Hide();
			}
		} 
		#endregion Methods
	}
}
