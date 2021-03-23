namespace Tartaros.Map
{
	using System.Collections.Generic;
	using Tartaros.Selection;
	using UnityEngine;
	using Tartaros.Economy;
	using Tartaros.ServicesLocator;
	using Tartaros.Sectors;
	using Tartaros.Math;
	using System.Linq;

	public class Sector : MonoBehaviour, ISector
	{
		#region Fields		
		[SerializeField]
		private MeshFilter _meshFiltrer = null;

		[SerializeField]
		private MeshCollider _collider = null;

		private SectorData _sectorData = null;
		private bool _isCaptured = false;
		private Mesh _sectorMesh = null;

		private IPlayerSectorResources _playerWallet = null;
		#endregion Fields

		#region Properties
		public SectorData SectorData => _sectorData;
		public bool IsCaptured => _isCaptured;

		GameObject[] ISector.ObjectsInSector
		{
			get
			{
				return FindObjectsOfType<GameObject>()
					.Where(x => IsObjectInSector(x))
					.ToArray();
			}
		}
		#endregion Properties

		#region Methods
		private void Awake()
		{
			_playerWallet = Services.Instance.Get<IPlayerSectorResources>();
		}

		public void Initialize(SectorData sectorData)
		{
			_sectorData = sectorData;

			_sectorMesh = SectorMeshGenerator.GenerateMesh(_sectorData);

			_collider.sharedMesh = _sectorMesh;
			UpdateFogOfWarVisibility();
		}

		bool ISector.CanCapture()
		{
			if (SectorData.CapturePrice == null)
			{
				Debug.LogErrorFormat("Capture price is not set on sector {0}.", name);
				return false;
			}

			return _playerWallet.CanBuy(SectorData.CapturePrice);
		}

		void ISector.Capture()
		{
			if ((this as ISector).CanCapture() == false)
			{
				Debug.LogErrorFormat("Not enought resources to capture resource.");
				return;
			}

			if (_isCaptured == true) return;

			_isCaptured = true;
			_playerWallet.Buy(SectorData.CapturePrice);

			OnCapture();
		}

		bool ISector.ContainsPosition(Vector3 point)
		{
			return _sectorData.ConvexPolygon.ContainsPoint2D(new Vector2(point.x, point.z));
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

		public bool IsObjectInSector(GameObject gameObject)
		{
			return _sectorData.ConvexPolygon.ContainsWorldPosition(gameObject.transform.position);
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
