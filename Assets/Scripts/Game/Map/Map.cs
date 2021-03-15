namespace Tartaros.Map
{
	using UnityEngine;

	public class Map : MonoBehaviour
	{
		#region Fields 
		[SerializeField]
		private MapData _mapData = null;
		#endregion Fields

		#region Properties
		public MapData MapData => _mapData;
		#endregion Properties
	}
}
