namespace Tartaros
{
	using Sirenix.OdinInspector;
	using Tartaros.ServicesLocator;
	using UnityEngine;

	public class IconsDatabase : MonoBehaviour
	{
		[SerializeField]
		[InlineEditor]
		private IconsDatabaseData _data = null;

		public IconsDatabaseData Data => _data;
	}
}
