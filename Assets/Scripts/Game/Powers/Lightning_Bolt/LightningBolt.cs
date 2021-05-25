namespace Tartaros.Powers
{
	using Sirenix.OdinInspector;
	using System.Collections;
	using System.Collections.Generic;
	using Tartaros.Entities;
	using Tartaros.Entities.Detection;
	using Tartaros.ServicesLocator;
	using Tartaros.Economy;
	using UnityEngine;

	public class LightningBolt : SerializedMonoBehaviour, IPower
	{
		#region Fields
		[SerializeField]
		private LightningBoltData _data = null;

		private GameObject _castVFX = null;
		private EntitiesDetectorManager _kdTree = null;
		private Animator _animator = null;
		#endregion

		#region Properties
		float IPower.Range => _data.SpellRadius;

		GameObject IPower.PrefabPower => gameObject;

		int IPower.Price => _data.GloryPrice;
		#endregion

		#region Methods
		void Awake()
		{
			_kdTree = Services.Instance.Get<EntitiesDetectorManager>();
		}

		private void OnEnable()
		{
			StartCoroutine(CastSpellMethods());
		}

		private void OnDestroy()
		{
			Destroy(_castVFX);
		}

		IEnumerator CastSpellMethods()
		{
			InstanciateCastVFX();

			yield return new WaitForSeconds(_data.TimeBeforeAppliedDamage);
			int time = _animator.GetCurrentAnimatorClipInfo(0).Length;

			yield return new WaitForSeconds(time);

			ApplyDamage();
			Debug.Log("damage");

			yield return DestroyVFXAfterDelay();
		}

		private void InstanciateCastVFX()
		{
			_castVFX = GameObject.Instantiate(_data.CastVFXPrefab, transform.position, Quaternion.identity, gameObject.transform);
			_animator = _castVFX.GetComponent<Animator>();
		}

		private void ApplyDamage()
		{
			Entity[] entities = _kdTree.GetEveryEntityInRadius(Team.Enemy, transform.position, _data.SpellRadius);

			for (int i = 0; i < entities.Length; i++)
			{
				//IAttackable attackable = entity[i].GetComponent<IAttackable>();
				entities[i].Kill();
			}
		}

		// TODO TF: create auto destroy VFX component, set it on cast vfx; then remove this method
		IEnumerator DestroyVFXAfterDelay()
		{
			for (float i = 0; i < _data.VFXLifeTime; i += _data.AttackFrequency)
			{
				ApplyDamage();
				yield return new WaitForSeconds(_data.AttackFrequency);
			}

			_animator.SetBool("isFinish", true);

			int time = _animator.GetCurrentAnimatorClipInfo(0).Length;

			yield return new WaitForSeconds(time);

			Destroy(gameObject);
		}
		#endregion Methods
	}
}