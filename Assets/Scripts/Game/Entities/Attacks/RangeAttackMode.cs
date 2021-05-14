namespace Tartaros.Entities.Attack
{
	using Sirenix.Serialization;
	using UnityEngine;

	[System.Serializable]
	public class RangeAttackMode : IAttackMode
	{
		[OdinSerialize]
		private GameObject _prefabProjectile = null;
		[OdinSerialize]
		private IHitEffect _vfxPrefab = null;
		[SerializeField]
		private int _damage = 1;
		[SerializeField]
		private Vector3 _projectileSpawnLocalPoint = Vector3.up;

		string IAttackMode.DisplayTypeUI => "Range";

		int IAttackMode.Damage => _damage;

		void IAttackMode.Attack(Transform attacker, IAttackable target)
		{
			GameObject instance = GameObject.Instantiate(_prefabProjectile, attacker.TransformPoint(_projectileSpawnLocalPoint), Quaternion.identity);
			RangeProjectile rangeProjectile = instance.GetComponent<RangeProjectile>();

			rangeProjectile.Initialize(attacker, target, _vfxPrefab, _damage);
		}
	}
}