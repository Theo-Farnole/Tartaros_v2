namespace Tartaros.UI.HoverPopup
{
	using UnityEngine;

	public class HoverPopupsDatabase : MonoBehaviour
	{
		[SerializeField]
		private HoverPopupsDatabaseData _database = null;

		public HoverPopupsDatabaseData Database => _database;
	}
}
