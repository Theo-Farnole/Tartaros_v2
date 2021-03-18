namespace Tartaros.Map
{
	using System.Collections.Generic;
	using UnityEngine;

	public class Sector : MonoBehaviour
	{
		#region Fields
		[SerializeField]
		private MeshFilter _meshFiltrer = null;

		[SerializeField]
		private MeshCollider _collider = null;

		private SectorData _sectorData = null;
		private bool _isCaptured = false;
		#endregion Fields

		#region Properties
		public SectorData SectorData => _sectorData;
		public bool IsCaptured => _isCaptured;
		#endregion Properties

		#region Methods
		public void Initialize(SectorData sectorData)
		{
			_sectorData = sectorData;

			Mesh mesh = SectorMeshGenerator.GenerateMesh(_sectorData);

			//_meshFiltrer.mesh = mesh;
			_collider.sharedMesh = mesh;
		}

		public void Capture()
		{
			if (_isCaptured == true) return;

			_isCaptured = true;
			Debug.Log("A sector has been captured");
		}

		public Vector3[] GetPointsWrappedSnappedToGround()
		{
			List<Vector3> sectorPointsSnapToGround = new List<Vector3>();

			foreach (Vector3 sectorPoint in _sectorData.GetWorldPointsWrapped())
			{
				Ray ray = new Ray(sectorPoint + Vector3.up * 5, Vector3.down);

				if (Physics.Raycast(ray, out RaycastHit hit))
				{
					sectorPointsSnapToGround.Add(hit.point);
				}
				else
				{
					sectorPointsSnapToGround.Add(sectorPoint);
				}
			}

			Debug.LogFormat("{0} has generated an outline of {1} points.", name, sectorPointsSnapToGround.Count);

			return sectorPointsSnapToGround.ToArray();
		}
		#endregion Methods
	}
}
