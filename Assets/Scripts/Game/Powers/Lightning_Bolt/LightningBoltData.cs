namespace Tartaros.Powers
{
	using Sirenix.OdinInspector;
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public class LightningBoltData : SerializedScriptableObject
	{
		[SerializeField]
		private float _spellRadius = 1;
		[SerializeField]
		private GameObject _preCastVFXPrefab = null;
		[SerializeField]
		private GameObject _castVFXPrefab = null;
		[SerializeField]
		private float _attackFrequency = 1;
		[SerializeField]
		private float _timeBeforeAppliedDamage = 1;
		[SerializeField]
		private int _gloryPrice = 0;
		[SerializeField]
		private float _spellLifetime = 3;



		public float SpellRadius => _spellRadius;
		public GameObject PreCastVFXPrefab => _preCastVFXPrefab;
		public GameObject CastVFXPrefab => _castVFXPrefab;
		public float VFXLifeTime => _spellLifetime;
		public float AttackFrequency => _attackFrequency;
		public float TimeBeforeAppliedDamage => _timeBeforeAppliedDamage;
		public int GloryPrice => _gloryPrice;
	}
}