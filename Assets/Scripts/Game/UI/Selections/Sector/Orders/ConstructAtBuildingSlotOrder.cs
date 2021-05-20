namespace Tartaros.UI.Sectors.Orders
{
	using Tartaros.Map;

	public class ConstructAtBuildingSlotOrder : SectorOrder
	{
		public ConstructAtBuildingSlotOrder(ISector sector) : this(sector.GetBuildingSlotAvailable())
		{ }

		public ConstructAtBuildingSlotOrder(BuildingSlot slot) : base(TartarosTexts.GetSectorConstructLabel(slot.ConstructionPrice), slot.Construct, () => slot.IsAvailable)
		{
			if (slot is null)
			{
				throw new System.ArgumentNullException(nameof(slot));
			}
		}
	}
}
