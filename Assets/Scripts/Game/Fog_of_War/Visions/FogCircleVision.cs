namespace Tartaros.FogOfWar
{
	using Tartaros.ServicesLocator;
	using UnityEngine;

	public class FogCircleVision : MonoBehaviour, IFogVision
	{
		#region Fields
		[SerializeField]
		private float _radius = 1;

		private FogOfWarManager _fogOfWarManager = null;
		#endregion Fields

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

		bool IFogVision.IsPointVisible(Vector3 worldPoint)
		{
			// TODO TF: (perf) use SqrtDistance
			return Vector3.Distance(transform.position, worldPoint) <= _radius;
		}
		#endregion Methods
	}
}
