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

		#region Methods
		private void Start()
		{
			GenerateSectorsMeshes();
		}

		private void GenerateSectorsMeshes()
		{
			for (int i = 0; i < _mapData.Sectors.Length; i++)
			{
				SectorData sector = _mapData.Sectors[i];
				var mesh = SectorMeshGenerator.GenerateMesh(sector);

				string name = string.Format("Sector {0}", i);

				GameObject sectorGameObject = new GameObject(name, typeof(MeshRenderer));				
				var sectorMeshFilter = sectorGameObject.AddComponent<MeshFilter>();

				sectorMeshFilter.mesh = mesh;

				sectorGameObject.transform.Rotate(90, 0, 0);
			}
		}
		#endregion Methods
	}
}
