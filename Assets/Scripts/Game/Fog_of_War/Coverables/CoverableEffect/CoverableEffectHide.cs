namespace Tartaros.FogOfWar
{
	using UnityEngine;

	public class CoverableEffectHide : MonoBehaviour, ICoverableEffect
	{
		#region Fields
		[SerializeField]
		private MeshRenderer _meshRenderer = null;
		#endregion Fields

		#region Methods
		void Start()
		{
			if (_meshRenderer == null)
			{
				Debug.LogErrorFormat("Missing Meshrenderer on {0}. Cover will not be hide.", name);
			}
		}

		void ICoverableEffect.OnBecomeCover()
		{
			if (_meshRenderer != null)
			{
				_meshRenderer.enabled = false;
			}
		}

		void ICoverableEffect.OnBecomeVisible()
		{
			if (_meshRenderer != null)
			{
				_meshRenderer.enabled = true;
			}
		}
		#endregion Methods
	}
}
