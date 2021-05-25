namespace Tartaros.Map
{
	using Sirenix.OdinInspector;
	using Sirenix.Serialization;
	using System.Collections.Generic;
	using System.Linq;
	using UnityEngine;

	public class MapData : SerializedScriptableObject
	{
		#region Fields
		[OdinSerialize]
		private List<SectorData> _sectorsData = new List<SectorData>(0);

		[SerializeField]
		private Vector2 _mapSize = new Vector2(10, 10);
		#endregion Fields

		#region Properties
		public Vector2 MapSize => _mapSize;
		public SectorData[] Sectors => _sectorsData.ToArray();
		public int SectorsCount => _sectorsData?.Count ?? throw new System.NotSupportedException("Sectors data is null.");
		public Vertex2D[] Vertices => _sectorsData.SelectMany(x => x.Vertices).ToArray();
		#endregion Properties

		#region Methods
		public void AddSector(SectorData sectorData)
		{
			_sectorsData.Add(sectorData);
		}

		[Button]
		public void CreateDefaultSector()
		{
			SectorData sectorData = new SectorData();

			sectorData.AddVertex(new Vertex2D(new Vector3(1, 0, 1)));
			sectorData.AddVertex(new Vertex2D(new Vector3(1, 0, 0)));
			sectorData.AddVertex(new Vertex2D(new Vector3(0, 0, 1)));

			_sectorsData.Add(sectorData);
		}
		#endregion Methods
	}
}