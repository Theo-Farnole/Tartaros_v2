namespace Tartaros
{
	using Sirenix.OdinInspector;
	using Sirenix.Utilities;
	using Tartaros.Economy;
	using Tartaros.Map;
	using Tartaros.ServicesLocator;
	using Tartaros.UI;
	using UnityEngine;

	public static class TartarosTexts
	{
		public static readonly string CAPTURE_SECTOR_FREE = "FREE";
		public static readonly string CAPTURE_SECTOR = "Capture";
		public static readonly string SECTOR_CAPTURED = "Sector captured";
		public static readonly string FAVOR = "favor";
		public static readonly string CONSTRUCT = "Construct";
		public static string TEMPLE_DESCRIPTION => string.Format("Train <color={0}>hoplites</color> and <color={0}>archers</color> to defend your people.", UNITS_COLOR_HEX);
		public static readonly string TEMPLE_NAME = "Temple";

		private static readonly string RESOURCE_COLOR_HEX = Color.green.ToHex();
		private static readonly string UNITS_COLOR_HEX = Color.red.ToHex();
		private static readonly string SPELLS_COLOR_HEX = Color.magenta.ToHex();

		public static readonly string VILLAGE = "Village";
		public static readonly string VILLAGE_DESCRIPTION = string.Format("Unlock a <color={0}>spell</color> when captured.", SPELLS_COLOR_HEX);

		public static readonly string DEFAULT_SECTOR_NAME = "Empty sector";
		public static readonly string DEFAULT_SECTOR_DESCRIPTION = "";

		private static readonly string ICON_GLORY = "<sprite name=\"glory\">";



		public static string GetResourceSectorName(ISector sector) => GetResourceSectorName(sector.GetResourceType());

		public static string GetResourceSectorName(SectorRessourceType type)
		{
			return string.Format("{0} sector", type);
		}

		public static string GetResourceSectorDescription(ISector sector)
		{
			var resourceType = sector.GetResourceType();
			var remainingAmount = sector.GetAvailableResources();

			return string.Format("Generates {0}. There is {1} available.", GetTypeResourceText(resourceType), GetAmountResourceText(remainingAmount, resourceType));
		}

		public static string GetSectorConstructLabel(ISectorResourcesWallet constructionPrice)
		{
			return "{0} {1}".Format(CONSTRUCT, constructionPrice.ToRichTextString());
		}

		public static string GetSpecialSectorDescription(SpecialSector specialSector)
		{
			var specialSectorIncome = specialSector.GetComponent<SpecialSectorIncome>();
			IIncomeGenerator incomeGenerator = specialSectorIncome;

			return "Earn {0} on capture. Give frenquently {1}.".Format(
				GetGloryText(specialSectorIncome.GloryIncomeOnCapture),
				GetAmountResourceText(incomeGenerator.ResourcesPerTick, incomeGenerator.SectorRessourceType));
		}

		public static string GetAmountResourceText(int amount, SectorRessourceType type)
		{
			return "{1}<color={0}>{2}</color>".Format(RESOURCE_COLOR_HEX, type.GetRichTextSprite(), amount);
		}

		public static string GetTypeResourceText(SectorRessourceType resourceType)
		{
			return "{0}<color={1}>{2}</color>".Format(resourceType.GetRichTextSprite(), RESOURCE_COLOR_HEX, resourceType);
		}

		public static string GetGloryText(int amount)
		{
			int gemAmount = amount / Services.Instance.Get<GloryGemsManagerUI>().MaxGloryPerGem;

			return "{2}<color={0}>{1}</color>".Format(SPELLS_COLOR_HEX, gemAmount, ICON_GLORY);
		}
	}
}
