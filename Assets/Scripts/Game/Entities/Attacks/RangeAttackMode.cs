namespace Tartaros.Entities.Attack
{
    using Sirenix.Serialization;
    using UnityEngine;

    public class RangeAttackMode : IAttackMode
    {
        [OdinSerialize]
        private GameObject _prefabProjectile = null;
        [OdinSerialize]
        private IHitEffect _vfxPrefab = null;
        void IAttackMode.Attack(Transform attacker, IAttackable target)
        {
            GameObject instance = GameObject.Instantiate(_prefabProjectile, attacker.position, Quaternion.identity);
            RangeProjectile rangeProjectile = instance.GetComponent<RangeProjectile>();

            rangeProjectile.Initialize(attacker, target, _vfxPrefab);
        }
    }
}