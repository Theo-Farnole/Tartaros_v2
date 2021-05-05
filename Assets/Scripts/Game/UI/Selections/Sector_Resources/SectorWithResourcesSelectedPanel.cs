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

		[SerializeField]
		private Image _resourceIcon = null;

		[SerializeField]
		private TextMeshProUGUI _name = null;

		[SerializeField]
		private TextMeshProUGUI _description = null;

		private ISelection _currentSelection = null;
		private IconsDatabase _iconsDatabase = null;
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

				if (firtSelectable.GameObject.TryGetComponent(out ISector sector) && sector.ContainsResource())
				{
					UpdateShowInformations(sector);
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

		private void UpdateShowInformations(ISector sector)
		{
			SectorRessourceType resourceType = sector.GetResourceType();

			_resourceIcon.sprite = _iconsDatabase.Data.GetResourceIcon(resourceType);
			_name.text = TartarosTexts.GetResourceSectorName(sector);
			_description.text = TartarosTexts.GetResourceSectorDescription(sector);

			_captureButton.Sector = sector;
		}
		#endregion Methods
	}
}
