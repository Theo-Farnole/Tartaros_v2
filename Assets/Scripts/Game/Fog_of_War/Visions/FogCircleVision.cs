namespace Tartaros.FogOfWar
{
	using Tartaros.Math;
	using Tartaros.ServicesLocator;
	using UnityEngine;

	public class FogCircleVision : MonoBehaviour, IFogVision
	{
		#region Fields
		[SerializeField]
		private float _radius = 1;

		private FogOfWarManager _fogOfWarManager = null;
		#endregion Fields

		#region Properties
		IShape IFogVision.VisionShape => new Circle(new Vector3(transform.position.x, 0, transform.position.z), _radius);
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

		void OnDrawGizmos()
		{
#if UNITY_EDITOR
			Editor.HandlesHelper.DrawSolidCircle(transform.position, Vector3.up, _radius, Color.grey);
#endif
		}
		#endregion Methods
	}
}
