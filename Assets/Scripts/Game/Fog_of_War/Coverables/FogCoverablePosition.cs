namespace Tartaros.FogOfWar
{
	using Tartaros;
	using UnityEngine;

	public class FogCoverablePosition : MonoBehaviour, IFogCoverable
	{
		#region Fields
		private bool _isCovered = false;
		private ICoverableEffect _coverableEffect = null;
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

		bool IContainable.ContainsPosition(Vector3 worldPosition)
		{
			return worldPosition == transform.position;
		}
		#endregion Methods
	}
}
