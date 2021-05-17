namespace Tartaros.Entities.Attack
{
	using System.Collections;
	using Tartaros.Entities.Attack;
	using UnityEngine;

	[System.Serializable]
	public class AreaOfDamageEffect : IHitEffect
	{
		#region Fields
		[SerializeField]
		private GameObject _vfxPrefab = null;
		#endregion Fields
		void IHitEffect.ExecuteHitEffect(Vector3 positionToInstanciate, Quaternion rotationoInstanciate)
		{
			if (_vfxPrefab != null)
			{
				GameObject.Instantiate(_vfxPrefab, positionToInstanciate, rotationoInstanciate);
			}
		}

	}
}