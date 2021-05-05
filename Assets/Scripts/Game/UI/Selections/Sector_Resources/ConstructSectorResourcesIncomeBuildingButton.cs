namespace Tartaros.UI
{
	using System;
	using System.Diagnostics;
	using Tartaros.Map;
	using TMPro;
	using UnityEngine;

	public class ConstructSectorResourcesIncomeBuildingButton : AButtonActionAttacher
	{
		[SerializeField]
		private TextMeshProUGUI _constructPriceLabel = null;

		private ISector _sector = null;

		public ISector Sector
		{
			get => _sector; 
			
			set
			{
				_sector = value;

				UpdateButtonInformations();
			}
		}

		protected override void OnButtonClick()
		{
			SectorResourcesGeneratorSlot availableSlot = _sector.GetAvailableResourcesGeneratorSlot();

			if (availableSlot == null) throw new NotSupportedException("No available slots on sector {0}: cannot construct resources generator.".Format(_sector.ToString()));
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

				Button.interactable = true;
				_constructPriceLabel.text = slot.ConstructionPrice.ToRichTextString();
			}
		}
	}
}
