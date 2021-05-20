namespace Tartaros.UI
{
	using Sirenix.OdinInspector;
	using System.Threading;
	using Tartaros.Economy;
	using Tartaros.Map;
	using Tartaros.Selection;
	using Tartaros.ServicesLocator;
	using Tartaros.UI.Sectors.Orders;
	using TMPro;
	using UnityEngine;
	using UnityEngine.UI;

	public class SectorSelectedPanel : APanel
	{
		#region Fields
		[Title("UI Informations References")]
		[SerializeField] private Image _resourceIcon = null;
		[SerializeField] private TextMeshProUGUI _name = null;
		[SerializeField] private TextMeshProUGUI _description = null;
		[Title("Buttons References")]
		[SerializeField] private CaptureSectorButton _captureButton = null;
		[SerializeField] private SectorOrderButton _orderButton = null;

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

			_captureButton.LateButtonClicked -= OnAnyButtonClick;
			_captureButton.LateButtonClicked += OnAnyButtonClick;
		}

		private void OnDisable()
		{
			_currentSelection.SelectionChanged -= SelectionChanged;

			_captureButton.LateButtonClicked -= OnAnyButtonClick;
		}

		private void OnAnyButtonClick(object sender, AButtonActionAttacher.LateButtonClickedArgs e)
		{
			UpdateShowInformations();
		}

		private void SelectionChanged(object sender, SelectionChangedArgs e)
		{
			if (_currentSelection.ObjectsCount == 1)
			{
				ISelectable firtSelectable = _currentSelection.Objects[0];

				if (firtSelectable.GameObject.TryGetComponent(out ISector sector))
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
			if (_displaySector.TryGetResourceType(out SectorRessourceType resourceType))
			{
				_resourceIcon.sprite = _iconsDatabase.Data.GetResourceIcon(resourceType);
				_name.text = TartarosTexts.GetResourceSectorName(_displaySector);
				_description.text = TartarosTexts.GetResourceSectorDescription(_displaySector);
			}

			UpdateOrderButton();
			UpdateCaptureButton();
		}

		private void UpdateOrderButton()
		{
			if (_displaySector.IsCaptured == true)
			{
				ISectorOrderable sectorOrderable = GetSectorOrderable();

				if (sectorOrderable != null)
				{
					SectorOrder sectorOrder = sectorOrderable.GenerateSectorOrder();

					_orderButton.gameObject.SetActive(sectorOrder.IsAvailable);
					_orderButton.SectorOrder = sectorOrder;
				}
				else
				{
					_orderButton.gameObject.SetActive(false);
				}
			}
			else
			{
				_orderButton.gameObject.SetActive(false);
			}
		}

		private ISectorOrderable GetSectorOrderable()
		{
			ISectorOrderable[] sectorOrderables = _displaySector.FindObjectsInSectorOfType<ISectorOrderable>();

			if (sectorOrderables.Length > 1) throw new System.NotSupportedException("A sector cannot more than one ISectorOrderable.");

			if (sectorOrderables.Length > 0)
			{
				return sectorOrderables[0];
			}
			else
			{
				return null;
			}
		}

		private void UpdateCaptureButton()
		{
			_captureButton.gameObject.SetActive(!_displaySector.IsCaptured);
			_captureButton.Sector = _displaySector;
		}
		#endregion Methods
	}
}
