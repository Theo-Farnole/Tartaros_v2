namespace Tartaros.Entities.Attack
{
	using UnityEngine;

	[System.Serializable]
	public class SingleEffect : IHitEffect
	{
		#region Fields
		[SerializeField]
		private GameObject _vfxPrefab = null;
		#endregion Fields

		#region Methods
		void IHitEffect.ExecuteHitEffect(Vector3 positionToInstanciate, Quaternion rotationoInstanciate)
		{
			if (_vfxPrefab != null)
			{
				GameObject.Instantiate(_vfxPrefab, positionToInstanciate, Quaternion.identity);
			}
		}
		#endregion Methods
	}
}