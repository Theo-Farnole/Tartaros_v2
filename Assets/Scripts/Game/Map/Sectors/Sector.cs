namespace Tartaros.Map
{
	using System.Collections.Generic;
	using Tartaros.Selection;
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
		private Mesh _sectorMesh = null;
		#endregion Fields

		#region Properties
		public SectorData SectorData => _sectorData;
		public bool IsCaptured => _isCaptured;
		#endregion Properties

		#region Methods
		public void Initialize(SectorData sectorData)
		{
			_sectorData = sectorData;

			_sectorMesh = SectorMeshGenerator.GenerateMesh(_sectorData);

			_collider.sharedMesh = _sectorMesh;
			UpdateFogOfWarVisibility();
		}
		public void Capture()
		{
			if (_isCaptured == true) return;

			_isCaptured = true;

			OnCapture();
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


		private void OnCapture()
		{
			Debug.Log("A sector has been captured");
			UpdateSelectableTeam();
			UpdateFogOfWarVisibility();
		}

		private void UpdateSelectableTeam()
		{
			if (TryGetComponent(out ISelectable selectable))
			{
				selectable.Team = Entities.Team.Player;
			}
		}

		private void UpdateFogOfWarVisibility()
		{
			_meshFiltrer.mesh = _isCaptured ? _sectorMesh : null;
		}
		#endregion Methods
	}
}
