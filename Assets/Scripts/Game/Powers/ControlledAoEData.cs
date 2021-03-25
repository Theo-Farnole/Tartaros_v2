namespace Tartaros.Power
{
    using Sirenix.OdinInspector;
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class ControlledAoEData : SerializedScriptableObject
    {
        [SerializeField]
        private float _spellRadius = 1;
        [SerializeField]
        private GameObject _preCastVFXPrefab = null;
        [SerializeField]
        private GameObject _castVFXPrefab = null;
        [SerializeField]
        private float _lifeTime = 1;
        [SerializeField]
        private float _attackFrequency = 1;

        public float SpellRadius => _spellRadius;
        public GameObject PreCastVFXPrefab => _preCastVFXPrefab;
        public GameObject CastVFXPrefab => _castVFXPrefab;
        public float LifeTime => _lifeTime;
        public float AttackFrequency => _attackFrequency;
    }
}