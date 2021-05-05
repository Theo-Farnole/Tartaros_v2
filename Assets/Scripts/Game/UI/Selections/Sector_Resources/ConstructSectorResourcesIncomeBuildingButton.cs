namespace Tartaros.UI
{
	using System;
	using Tartaros.Map;
	using TMPro;
	using UnityEngine;

	public class ConstructSectorResourcesIncomeBuildingButton : AButtonActionAttacher
	{
		#region Fields
		[SerializeField]
		private TextMeshProUGUI _constructPriceLabel = null;

		private ISector _sector = null;
		#endregion Fields

		#region Properties
		public ISector Sector
		{
			get => _sector;

			set
			{
				_sector = value;

				UpdateButtonInformations();
			}
		}
		#endregion Properties

		#region Methods
		protected override void OnButtonClick()
		{
			SectorResourcesGeneratorSlot availableSlot = _sector.GetAvailableResourcesGeneratorSlot();

			if (availableSlot == null) throw new NotSupportedException("No available slots on sector {0}: cannot construct resources generator.".Format(_sector.ToString()));

			if (availableSlot.CanConstruct() == true)
			{
				availableSlot.Construct();
			}
		}

		private void UpdateButtonInformations()
		{
			SectorResourcesGeneratorSlot slot = null;

			if (_sector != null)
			{
				slot = _sector.GetAvailableResourcesGeneratorSlot();
			}

			if (_sector == null || slot == null)
			{
				Button.interactable = false;
				_constructPriceLabel.text = "TODO: HIDE THIS BUTTON";
			}
			else
			{

				Button.interactable = slot.CanConstruct();
				_constructPriceLabel.text = slot.ConstructionPrice.ToRichTextString();
			}
		}
		#endregion Methods
	}
}
