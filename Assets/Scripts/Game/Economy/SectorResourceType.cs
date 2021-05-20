namespace Tartaros.Economy
{
	using Tartaros.ServicesLocator;
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

		public static string GetRichTextSprite(this SectorRessourceType type)
		{
			const string FORMAT = "<sprite name={0}>";

			return string.Format(FORMAT, type.ToString().ToLower());
		}

		public static void DrawIcon(this SectorRessourceType type, Vector3 center)
		{
			Gizmos.DrawIcon(center, type.GetGizmosIconName());
		}

		public static Sprite GetIcon(this SectorRessourceType type)
		{
			return Services.Instance.Get<IconsDatabase>().Data.GetResourceIcon(type);
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