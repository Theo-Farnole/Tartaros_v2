namespace Tartaros.FogOfWar
{
	using Sirenix.OdinInspector;
	using UnityEngine;

	public class OnDiscoverEnableFakeFogOfWar : MonoBehaviour, ICoverableEffect
	{
		#region Fields
		public static readonly int ENABLE_FAKE_FOG_OF_WAR_PROJECTION = Shader.PropertyToID("_EnableFakeFoWProjection");

		[SerializeField, Required] private MeshRenderer _meshRenderer = null;
		#endregion Fields

		#region Methods
		void ICoverableEffect.OnBecomeCover()
		{
			EnableFakeProjection(true);
		}

		void ICoverableEffect.OnBecomeVisible()
		{
			EnableFakeProjection(false);
		}

		private void EnableFakeProjection(bool enable)
		{
			float value = enable ? 1 : 0;

			for (int i = 0; i < _meshRenderer.materials.Length; i++)
			{
				Material material = _meshRenderer.materials[i];
				material.SetFloat(ENABLE_FAKE_FOG_OF_WAR_PROJECTION, value);
			}
		}
		#endregion Methods
	}
}
