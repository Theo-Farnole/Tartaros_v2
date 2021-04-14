namespace Tartaros.FogOfWar
{
	using Tartaros.Math;
	using Tartaros.ServicesLocator;
	using UnityEngine;

	public class FogCoverablePosition : MonoBehaviour, IFogCoverable
	{
		#region Fields
		private bool _isCovered = false;
		private ICoverableEffect _coverableEffect = null;
		private FogOfWarManager _fogOfWarManager = null;
		#endregion Fields

		#region Properties
		bool IFogCoverable.IsCovered
		{
			get => _isCovered;

			set
			{
				// Do nothing if covered value is not set.
				if (_isCovered == value) return;

				_isCovered = value;

				if (_coverableEffect != null)
				{
					if (_isCovered == true)
					{
						_coverableEffect.OnBecomeCover();
					}
					else
					{
						_coverableEffect.OnBecomeVisible();
					}
				}
			}
		}

		IShape IFogCoverable.ModelBounds => new Circle(transform.position, 0.1f);
		#endregion Properties

		#region Methods
		void Awake()
		{
			_fogOfWarManager = Services.Instance.Get<FogOfWarManager>();
			_coverableEffect = GetComponent<ICoverableEffect>();

			if (_coverableEffect == null)
			{
				Debug.LogErrorFormat("Missing coverable effect on {0}. Please add a component that herit ICoverableEffect. On cover, the object will never disappear.", name);
			}
		}

		void OnEnable()
		{
			_fogOfWarManager.AddCoverable(this);
		}

		void OnDisable()
		{
			_fogOfWarManager.RemoveCoverable(this);
		}

		void OnDrawGizmos()
		{
			Gizmos.color = Color.red;
			Gizmos.DrawRay(transform.position, Vector3.up * 3);
		}
		#endregion Methods
	}
}
