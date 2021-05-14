namespace Assets.Scripts.Game.Entities.Attacks
{
	using Sirenix.Serialization;
	using System.Collections;
	using Tartaros.Entities;
	using Tartaros.Entities.Attack;
	using Tartaros.Entities.Attacks;
	using UnityEngine;

	[System.Serializable]
	public class AoEAttackMode : IAttackMode
	{
		[OdinSerialize]
		private GameObject _prefabProjectile = null;
		[OdinSerialize]
		private IHitEffect _vfxPrefab = null;
		[SerializeField]
		private int _damage = 1;
		[SerializeField]
		private Vector3 _projectileSpawnLocalPoint = Vector3.up;
		[SerializeField]
		private float _radiusOfDamage = 1;

		string IAttackMode.DisplayTypeUI => "AoE";

		int IAttackMode.Damage => _damage;

		void IAttackMode.Attack(Transform attacker, IAttackable target)
		{
			GameObject instance = GameObject.Instantiate(_prefabProjectile, attacker.TransformPoint(_projectileSpawnLocalPoint), Quaternion.identity);
			AoEProjectile AoEProjectile = instance.GetComponent<AoEProjectile>();

			AoEProjectile.Initialize(target, _vfxPrefab, _damage, _radiusOfDamage);	
		}
	}
}