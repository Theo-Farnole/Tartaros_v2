namespace Tartaros.Map
{
	using UnityEngine;

	public class Sector : MonoBehaviour
	{
		#region Fields
		[SerializeField]
		private MeshFilter _meshFiltrer = null;

		[SerializeField]
		private MeshCollider _collider = null;

		private SectorData _sectorData = null;
		#endregion Fields

		#region Methods
		public void Initialize(SectorData sectorData)
		{
			_sectorData = sectorData;

			Mesh mesh = SectorMeshGenerator.GenerateMesh(_sectorData);

			_meshFiltrer.mesh = mesh;
			_collider.sharedMesh = mesh;
		}
		#endregion Methods
	}
}
