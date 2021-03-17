namespace Tartaros.Map
{
	using Sirenix.OdinInspector;
	using System.Collections.Generic;
	using System.Linq;
	using UnityEngine;

	public class MapData : SerializedScriptableObject
	{
		#region Fields
		[SerializeField]
		private Vector2 _mapSize = new Vector2(10, 10);

		[SerializeField]
		private List<SectorData> _sectorData = new List<SectorData>(0);
		#endregion Fields

		#region Properties
		public Vector2 MapSize => _mapSize;
		public SectorData[] SectorData => _sectorData.ToArray();
		public Vertex[] Vertices => _sectorData.SelectMany(x => x.Vertices).ToArray();
		#endregion Properties

		#region Methods
		public void AddSector(SectorData sectorData)
		{
			_sectorData.Add(sectorData);
		}
		#endregion Methods
	}
}