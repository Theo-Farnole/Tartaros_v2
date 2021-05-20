namespace Assets.Scripts.Game.UI.Selections.Sector.Style
{
	using Tartaros.UI.Sectors.Orders;
	using UnityEngine;

	public class UIStyles : MonoBehaviour
	{
		[SerializeField] private SectorStylesDatabase _sectorsStyles = null;

		public SectorStylesDatabase SectorStyles => _sectorsStyles;
	}
}
