namespace Tartaros.Map
{
	using Tartaros.Selection;
	using Tartaros.ServicesLocator;
	using TF.CheatsGUI;
	using UnityEngine;

	public static class SectorCheats
	{
		[CheatMethod]
		public static void CaptureSelectedSector()
		{
			CurrentSelection currentSelection = Services.Instance.Get<CurrentSelection>();

			foreach (var selected in (currentSelection as ISelection).SelectedSelectables)
			{
				if (selected is Sector sector)
				{
					sector.Capture();
				}
			}
		}
	}
}
