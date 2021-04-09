namespace Tartaros.UI
{
	using System.Windows.Forms;
	using Tartaros.Map;
	using Tartaros.Sectors;
	using Tartaros.Selection;
	using Tartaros.ServicesLocator;
	using TMPro;
	using UnityEngine;

	public class SectorSelectedPanel : APanel
	{
		#region Fields
		[SerializeField]
		private CaptureSectorButton _captureButton = null;

		private ISelection _currentSelection = null;
		#endregion Fields

		#region Methods
		private void Start()
		{
			_currentSelection = Services.Instance.Get<CurrentSelection>();
			SubscribeToSelectionChangedEvent();
		}

		private void OnEnable()
		{
			if (_currentSelection != null)
			{
				SubscribeToSelectionChangedEvent();
			}
		}

		private void OnDisable()
		{
			UnsubscribeToSelectionChangedEvents();
		}

		private void UnsubscribeToSelectionChangedEvents()
		{
			_currentSelection.SelectionChanged -= SelectionChanged;
		}

		private void SubscribeToSelectionChangedEvent()
		{
			_currentSelection.SelectionChanged -= SelectionChanged;
			_currentSelection.SelectionChanged += SelectionChanged;
		}

		private void SelectionChanged(object sender, SelectionChangedArgs e)
		{
			if (_currentSelection.SelectedSelectables.Length == 1)
			{
				ISelectable firtSelectable = _currentSelection.SelectedSelectables[0];

				if (firtSelectable.GameObject.TryGetComponent(out ISector sector))
				{
					UpdateShowInformations(sector);
					Show();
				}
			}
			else
			{
				Hide();
			}
		}

		private void UpdateShowInformations(ISector sector)
		{
			// ICON

			// NAME
			// DESCRIPTION

			_captureButton.Sector = sector;
		}
		#endregion Methods
	}
}
