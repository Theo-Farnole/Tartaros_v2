namespace Tartaros.Entities.Attack
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class SingleEffect : IHitEffect
    {
        [SerializeField]
        GameObject _vfxPrefab = null;

        void IHitEffect.ExecuteHitEffect(Vector3 positionToInstanciate)
        {
            GameObject vfxInstanciate = GameObject.Instantiate(_vfxPrefab, positionToInstanciate, Quaternion.identity);
        }
    }
}