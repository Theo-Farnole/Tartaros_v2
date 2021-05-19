namespace Tartaros.UI
{
	using System;
	using Tartaros.Map;
	using TMPro;
	using UnityEngine;

	[Obsolete("Use SectorOrder instead.")]
	public class ConstructAtBuildingSlot_Button : AButtonActionAttacher
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
			BuildingSlot availableSlot = _sector.GetBuildingSlotAvailable();

			if (availableSlot == null) throw new NotSupportedException("No available slots on sector {0}: cannot construct resources generator.".Format(_sector.ToString()));

			if (availableSlot.CanConstruct() == true)
			{
				availableSlot.Construct();
			}
		}

		private void UpdateButtonInformations()
		{
			BuildingSlot slot = null;

			if (_sector != null)
			{
				slot = _sector.GetBuildingSlotAvailable();
			}

			if (_sector == null || slot == null)
			{
				throw new System.NotSupportedException("No building slot. Cannot display informations on button {0}.".Format(name));
			}
			else
			{

				Button.interactable = slot.CanConstruct();
				_constructPriceLabel.text = "{0} {1}".Format(TartarosTexts.CONSTRUCT, slot.ConstructionPrice.ToRichTextString());
			}
		}
		#endregion Methods
	}
}
