namespace Tartaros.FogOfWar
{
	using Sirenix.OdinInspector;
	using UnityEngine;

	public class CoverableEffectHide : MonoBehaviour, ICoverableEffect
	{
		#region Fields
		[SerializeField]
		private GameObject _model = null;
		#endregion Fields

		#region Methods
		void Start()
		{
			if (_model == null)
			{
				Debug.LogErrorFormat("Missing Meshrenderer on {0}. Cover will not be hide.", name);
			}
		}

		void ICoverableEffect.OnBecomeCover()
		{
			if (_model != null)
			{
				_model.SetActive(false);
			}
		}

		void ICoverableEffect.OnBecomeVisible()
		{
			if (_model != null)
			{
				_model.SetActive(true);
			}
		}
		#endregion Methods
	}
}
