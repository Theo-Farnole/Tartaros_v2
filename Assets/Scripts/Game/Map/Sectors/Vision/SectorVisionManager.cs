namespace Tartaros.Map
{
	using Sirenix.OdinInspector;
	using Tartaros.FogOfWar;
	using Tartaros.Map;
	using UnityEngine;

	public class SectorVisionManager : MonoBehaviour
	{
		#region Fields
		[SerializeField]
		[ChildGameObjectsOnly]
		private MeshFilter _meshFiltrer = null;

		private MeshRenderer _meshRenderer = null;
		private Sector _sector = null;
		private FogConvexPolygonVision _fogVision = null;
		#endregion Fields

		#region Methods
		private void Awake()
		{
			_sector = GetComponent<Sector>();
			_fogVision = this.GetOrAddComponent<FogConvexPolygonVision>();
			_meshRenderer = _meshFiltrer.GetComponent<MeshRenderer>();
		}

		private void Update()
		{
			//UpdateFogOfWarVisibility();
		}

		private void OnEnable()
		{
			_sector.Captured -= SectorCaptured;
			_sector.Captured += SectorCaptured;

			_sector.Initialized -= Initialized;
			_sector.Initialized += Initialized;
		}

		private void OnDisable()
		{
			_sector.Initialized -= Initialized;
			_sector.Captured -= SectorCaptured;
		}

		private void Initialized(object sender, Sector.InitializedArgs e)
		{
			SetVisionMesh();
			_fogVision.ConvexPolygon = _sector.SectorData.ConvexPolygon;
		}

		private void SectorCaptured(object sender, CapturedArgs e)
		{
			UpdateFogOfWarVisibility();
		}

		private void UpdateFogOfWarVisibility()
		{
			if (_sector.SectorMesh == null)
			{
				Debug.LogErrorFormat("Vision don't work on sector. Sector {0} has not be initialized.", name);
			}

			bool shouldEnableFog = ShouldEnableFog();

			_meshRenderer.enabled = shouldEnableFog;
			_fogVision.enabled = shouldEnableFog;
		}

		private bool ShouldEnableFog()
		{
			if (_sector.IsCaptured == true)
			{
				return true;
			}
			else
			{
				ISectorVisionEnabler[] enablers = _sector.FindObjectsInSectorOfType<ISectorVisionEnabler>();
				return enablers.Length > 0;
			}
		}

		private void SetVisionMesh()
		{
			if (_sector.SectorMesh == null)
			{
				Debug.LogErrorFormat("Vision don't work on sector. Sector {0} has not be initialized.", name);
			}

			_meshFiltrer.mesh = _sector.SectorMesh;
		}

		#endregion Methods
	}
}
