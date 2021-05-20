namespace Tartaros.UI.Sectors.Orders
{
	using UnityEngine;

	public class UIStyles : MonoBehaviour
	{
		[SerializeField] private SectorStylesDatabase _sectorsStyles = null;

		public SectorStylesDatabase SectorStyles => _sectorsStyles;
	}
}
