namespace Tartaros.Entities.Attack
{
	using System.Collections;
	using Tartaros.Entities.Attack;
	using UnityEngine;

	public class AreaOfDamageEffect : IHitEffect
	{
		#region Fields
		[SerializeField]
		private GameObject _vfxPrefab = null;
		#endregion Fields
		void IHitEffect.ExecuteHitEffect(Vector3 positionToInstanciate)
		{
			if (_vfxPrefab != null)
			{
				GameObject.Instantiate(_vfxPrefab, positionToInstanciate, Quaternion.identity);
			}
		}
	}
}