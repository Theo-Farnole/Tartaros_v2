namespace Tartaros
{
	using Tartaros.Sectors;

	public static class TartarosTexts
	{
		public static string CAPTURE_SECTOR_FREE = "FREE";
		public static string CAPTURE_SECTOR = "Capture";
		public static string SECTOR_CAPTURED = "Sector captured";


		public static string GetResourceSectorName(ISector sector)
		{
			return string.Format("{0} sector", sector.GetResourceType());
		}

		public static string GetResourceSectorDescription(ISector sector)
		{
			return string.Format("Generates {0}.", sector.GetResourceType());
		}
	}
}
