namespace Tartaros.FogOfWar
{
	using Tartaros.Math;
	using Tartaros.ServicesLocator;
	using UnityEngine;

	public partial class FogCircleVision : MonoBehaviour, IFogVision
	{
		#region Fields
		[SerializeField]
		private float _radius = 1;

		private FogOfWarManager _fogOfWarManager = null;
		private GameObject _meshVision = null;
		#endregion Fields

		#region Properties
		IShape IFogVision.VisionShape => new Circle(new Vector3(transform.position.x, 0, transform.position.z), _radius);

		public float Radius { get => _radius; set => _radius = value; }
		#endregion Properties

		#region Methods
		void Start()
		{
			_fogOfWarManager = Services.Instance.Get<FogOfWarManager>();
			_fogOfWarManager.AddVision(this);

			CreateMeshVision();
		}

		private void CreateMeshVision()
		{
			_meshVision = new GameObject("Fog Vision");

			_meshVision.transform.parent = transform;

			var meshRenderer = _meshVision.AddComponent<MeshRenderer>();
			var meshFilter = _meshVision.AddComponent<MeshFilter>();

			meshFilter.sharedMesh = MeshGenerator.GenerateCircleMesh();
			meshRenderer.material = new Material(Shader.Find("Particles/Standard Unlit"));

			_meshVision.layer = LayerMask.NameToLayer("FogOfWar");
			_meshVision.transform.localScale = _radius * Vector3.one;
			_meshVision.transform.localPosition = Vector3.zero;
		}

		void OnEnable()
		{
			if (_fogOfWarManager != null)
			{
				_fogOfWarManager.AddVision(this);
			}
		}

		void OnDisable()
		{
			_fogOfWarManager.RemoveVision(this);
		}
		#endregion Methods
	}

#if UNITY_EDITOR
	public partial class FogCircleVision
	{
		void OnDrawGizmos()
		{
			if (Application.isPlaying == true)
			{
				DrawVisionCircle();
			}
		}

		private void DrawVisionCircle()
		{
			Editor.HandlesHelper.DrawSolidCircle(transform.position, Vector3.up, _radius, Color.grey);
		}
	}
#endif
}
