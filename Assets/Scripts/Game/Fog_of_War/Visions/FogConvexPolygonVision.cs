namespace Tartaros.FogOfWar
{
	using System.Linq;
	using Tartaros.Math;
	using Tartaros.ServicesLocator;
	using UnityEngine;

	public partial class FogConvexPolygonVision : MonoBehaviour, IFogVision
	{
		#region Fields
		private ConvexPolygon _convexPolygon = null;
		private FogOfWarManager _fogOfWarManager = null;
		#endregion Fields

		#region Properties
		public ConvexPolygon ConvexPolygon { get => _convexPolygon; set => _convexPolygon = value; }
		IShape IFogVision.VisionShape => _convexPolygon;
		#endregion Properties

		#region Methods
		void Start()
		{
			_fogOfWarManager = Services.Instance.Get<FogOfWarManager>();
			_fogOfWarManager.AddVision(this);
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
	public partial class FogConvexPolygonVision
	{
		#region Methods
		void OnDrawGizmos()
		{
			if (this.enabled == false) return;

			Vector3[] positions = _convexPolygon.vertices.Select(x => x.ToXZ()).ToArray();

			var color = Color.grey;
			color.a = 0.1f;

			UnityEditor.Handles.color = color;
			UnityEditor.Handles.DrawAAConvexPolygon(positions);
		}
		#endregion Methods
	}
#endif
}
