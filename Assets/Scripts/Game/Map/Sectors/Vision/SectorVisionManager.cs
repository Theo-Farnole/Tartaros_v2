namespace Tartaros.Map
{
	using Sirenix.OdinInspector;
	using System.Collections.Generic;
	using Tartaros.FogOfWar;
	using Tartaros.Map;
	using UnityEngine;

	public class SectorVisionManager : MonoBehaviour
	{
		#region Fields
		[SerializeField, ChildGameObjectsOnly] private MeshFilter _meshFiltrer = null;

		private MeshRenderer _meshRenderer = null;
		private Sector _sector = null;
		private FogConvexPolygonVision _fogVision = null;
		private List<ISectorVisionEnabler> _enablers = new List<ISectorVisionEnabler>();
		#endregion Fields

		#region Methods
		private void Awake()
		{
			_sector = GetComponent<Sector>();
			_fogVision = this.GetOrAddComponent<FogConvexPolygonVision>();
			_meshRenderer = _meshFiltrer.GetComponent<MeshRenderer>();
		}

		private void Start()
		{
			UpdateFogOfWarVisibility();
		}

		private void OnEnable()
		{
			_sector.Captured -= SectorCaptured;
			_sector.Captured += SectorCaptured;

			_sector.Initialized -= Initialized;
			_sector.Initialized += Initialized;

			_sector.ObjectAdded -= OnObjectAdded;
			_sector.ObjectAdded += OnObjectAdded;

			_sector.ObjectRemoved -= OnObjectRemoved;
			_sector.ObjectRemoved += OnObjectRemoved;
		}

		private void OnDisable()
		{
			_sector.Initialized -= Initialized;
			_sector.Captured -= SectorCaptured;
			_sector.ObjectAdded -= OnObjectAdded;
			_sector.ObjectRemoved -= OnObjectRemoved;
		}

		private void OnObjectAdded(object sender, ObjectAddedArgs e)
		{
			if (e.addedObject.TryGetComponent(out ISectorVisionEnabler enabler))
			{
				AddSectorVisionEnabler(enabler);
			}
		}

		private void OnObjectRemoved(object sender, ObjectRemovedArgs e)
		{
			if (e.removedObject.TryGetComponent(out ISectorVisionEnabler enabler))
			{
				RemoveSectorVisionEnabler(enabler);
			}
		}

		private void AddSectorVisionEnabler(ISectorVisionEnabler enabler)
		{
			_enablers.TryAddWithoutDuplicate(enabler);
			UpdateFogOfWarVisibility();
		}

		private void RemoveSectorVisionEnabler(ISectorVisionEnabler enabler)
		{
			_enablers.Remove(enabler);
			UpdateFogOfWarVisibility();
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
				return _enablers.Count > 0;
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
