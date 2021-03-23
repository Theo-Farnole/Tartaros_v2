namespace Tartaros.Economy
{
	using UnityEngine;

	public enum SectorRessourceType
	{
		Iron,
		Stone,
		Food
	}

	public static class SectorRessourceTypeExtensions
	{
		public static Color GetDebugColor(this SectorRessourceType type)
		{
			switch (type)
			{
				case SectorRessourceType.Iron:
					return Color.red;

				case SectorRessourceType.Stone:
					return Color.blue;

				case SectorRessourceType.Food:
					return Color.green;

				default:
					throw new System.NotImplementedException();
			}
		}

		public static void DrawIcon(this SectorRessourceType type, Vector3 center)
		{
			Gizmos.DrawIcon(center, type.GetGizmosIconName());
		}

		private static string GetGizmosIconName(this SectorRessourceType type)
		{
			switch (type)
			{
				case SectorRessourceType.Iron:
					return "iron.png";

				case SectorRessourceType.Stone:
					return "stone.png";
					
				case SectorRessourceType.Food:
					return "food.png";

				default:
					throw new System.NotImplementedException();
			}
		}
	}
}