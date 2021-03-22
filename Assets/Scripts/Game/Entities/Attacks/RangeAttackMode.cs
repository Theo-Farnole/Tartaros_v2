namespace Tartaros.Entities.Attack
{
    using UnityEngine;

    public class RangeAttackMode : IAttackMode
    {
        [SerializeField]
        private GameObject _prefabProjectile = null;
        [SerializeField]
        private IHitEffect _vfxPrefab = null;
        void IAttackMode.Attack(Transform attacker, IAttackable target)
        {
            GameObject instance = GameObject.Instantiate(_prefabProjectile, attacker.position, Quaternion.identity);
            RangeProjectile rangeProjectile = instance.GetComponent<RangeProjectile>();

            rangeProjectile.Initialize(attacker, target, _vfxPrefab);
        }
    }
}