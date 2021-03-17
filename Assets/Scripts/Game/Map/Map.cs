namespace Tartaros.Map
{
	using Sirenix.OdinInspector;
	using UnityEngine;

	public class Map : MonoBehaviour
	{
		#region Fields 
		[SerializeField]
		private MapData _mapData = null;

		[SerializeField]
		[AssetsOnly]
		private GameObject _sectorPrefab = null;
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
				Mesh mesh = SectorMeshGenerator.GenerateMesh(sector);

				// because polygon normal are forward, we must rotate to make them look up
				GameObject sectorGameObject = Instantiate(_sectorPrefab, Vector3.zero, Quaternion.Euler(90, 0, 0));
				sectorGameObject.name = string.Format("Sector {0}", i);

				MeshFilter sectorMeshFilter = sectorGameObject.GetOrAddComponent<MeshFilter>();
				sectorMeshFilter.mesh = mesh;

				var meshCollider = sectorGameObject.GetOrAddComponent<MeshCollider>();
				meshCollider.sharedMesh = mesh;
			}
		}
		#endregion Methods
	}
}
