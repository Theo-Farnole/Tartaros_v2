namespace Tartaros.UI
{
	using Tartaros.Economy;
	using Tartaros.Map;
	using Tartaros.Selection;
	using Tartaros.ServicesLocator;
	using TMPro;
	using UnityEngine;
	using UnityEngine.UI;

	public class SectorWithResourcesSelectedPanel : APanel
	{
		#region Fields
		[SerializeField]
		private CaptureSectorButton _captureButton = null;

		[SerializeField]
		private ConstructAtBuildingSlot_Button _constructButton = null;

		[SerializeField]
		private Image _resourceIcon = null;

		[SerializeField]
		private TextMeshProUGUI _name = null;

		[SerializeField]
		private TextMeshProUGUI _description = null;

		private ISelection _currentSelection = null;
		private IconsDatabase _iconsDatabase = null;
		private ISector _displaySector = null;
		#endregion Fields

		#region Methods
		protected override void Awake()
		{
			base.Awake();

			_currentSelection = Services.Instance.Get<CurrentSelection>();
			_iconsDatabase = Services.Instance.Get<IconsDatabase>();
		}

		private void OnEnable()
		{
			_currentSelection.SelectionChanged -= SelectionChanged;
			_currentSelection.SelectionChanged += SelectionChanged;

			_constructButton.LateButtonClicked -= OnAnyButtonClick;
			_constructButton.LateButtonClicked += OnAnyButtonClick;

			_captureButton.LateButtonClicked -= OnAnyButtonClick;
			_captureButton.LateButtonClicked += OnAnyButtonClick;
		}

		private void OnDisable()
		{
			_currentSelection.SelectionChanged -= SelectionChanged;

			_constructButton.LateButtonClicked -= OnAnyButtonClick;
			_captureButton.LateButtonClicked -= OnAnyButtonClick;
		}

		private void OnAnyButtonClick(object sender, AButtonActionAttacher.LateButtonClickedArgs e)
		{
			UpdateShowInformations();
		}

		private void SelectionChanged(object sender, SelectionChangedArgs e)
		{
			if (_currentSelection.SelectedSelectables.Length == 1)
			{
				ISelectable firtSelectable = _currentSelection.SelectedSelectables[0];

				if (firtSelectable.GameObject.TryGetComponent(out ISector sector) && sector.ContainsResource())
				{
					_displaySector = sector;
					UpdateShowInformations();
					Show();
				}
				else
				{
					Hide();
				}
			}
			else
			{
				Hide();
			}
		}

		private void UpdateShowInformations()
		{
			SectorRessourceType resourceType = _displaySector.GetResourceType();

			_resourceIcon.sprite = _iconsDatabase.Data.GetResourceIcon(resourceType);
			_name.text = TartarosTexts.GetResourceSectorName(_displaySector);
			_description.text = TartarosTexts.GetResourceSectorDescription(_displaySector);

			UpdateButtons();

			void UpdateButtons()
			{
				_captureButton.gameObject.SetActive(!_displaySector.IsCaptured);
				_captureButton.Sector = _displaySector;


				BuildingSlot slot = _displaySector.GetBuildingSlotAvailable();
				_constructButton.gameObject.SetActive(_displaySector.IsCaptured && slot != null);

				if (slot != null)
				{
					_constructButton.Sector = _displaySector;
				}

				if (_captureButton.isActiveAndEnabled == false && _constructButton.isActiveAndEnabled == false)
				{
					Debug.LogWarning("Capture and construct buttons are hide. There is maybe a problem.");
				}
			}
		}
		#endregion Methods
	}
}
