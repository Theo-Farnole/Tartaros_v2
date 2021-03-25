namespace Tartaros.FogOfWar
{
	using Tartaros;
	using Tartaros.ServicesLocator;
	using Tartaros.Utilities;
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

		BoundsXZ IFogCoverable.ModelBounds => throw new System.NotImplementedException();
		#endregion Properties

		#region Methods
		void Awake()
		{
			_coverableEffect = GetComponent<ICoverableEffect>();

			if (_coverableEffect == null)
			{
				Debug.LogErrorFormat("Missing coverable effect on {0}. Please add a component that herit ICoverableEffect. On cover, the object will never disappear.", name);
			}
		}

		void Start()
		{
			_fogOfWarManager = Services.Instance.Get<FogOfWarManager>();
			_fogOfWarManager.AddCoverable(this);
		}

		void OnEnable()
		{
			if (_fogOfWarManager != null)
			{
				_fogOfWarManager.AddCoverable(this);
			}
		}

		void OnDisable()
		{
			_fogOfWarManager.RemoveCoverable(this);
		}
		#endregion Methods
	}
}
