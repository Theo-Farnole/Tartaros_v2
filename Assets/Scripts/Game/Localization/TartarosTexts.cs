namespace Tartaros
{
	using Sirenix.Utilities;
	using Tartaros.Economy;
	using Tartaros.Map;
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

		public static readonly string VILLAGE = "Village";
		public static readonly string VILLAGE_DESCRIPTION = "Unlock a spell when captured.";



		public static string GetResourceSectorName(ISector sector) => GetResourceSectorName(sector.GetResourceType());

		public static string GetResourceSectorName(SectorRessourceType type)
		{
			return string.Format("{0} sector", type);
		}

		public static string GetResourceSectorDescription(ISector sector) => GetResourceSectorDescription(sector.GetResourceType());

		public static string GetResourceSectorDescription(SectorRessourceType resourceType)
		{
			return string.Format("Generates {0}<color={1}>{2}</color>.", resourceType.GetRichTextSprite(), RESOURCE_COLOR_HEX, resourceType);
		}

		public static string GetSectorConstructLabel(ISectorResourcesWallet constructionPrice)
		{
			return "{0} {1}".Format(CONSTRUCT, constructionPrice.ToRichTextString());
		}

		public static string GetSpecialSectorDescription(SpecialSector specialSector)
		{
			var specialSectorIncome = specialSector.GetComponent<SpecialSectorIncome>();
			IIncomeGenerator incomeGenerator = specialSectorIncome;

			return "Earn {0} glory on capture. Give frenquently {1}{2}.".Format(specialSectorIncome.GloryIncomeOnCapture, incomeGenerator.SectorRessourceType.GetRichTextSprite(), incomeGenerator.ResourcesPerTick);
		}
	}
}
