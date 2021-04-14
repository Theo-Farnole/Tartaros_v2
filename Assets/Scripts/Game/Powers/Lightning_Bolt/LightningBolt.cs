namespace Tartaros.Power
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

			ApplyDamage();

			yield return DestroyVFXAfterDelay();
		}

		private void InstanciateCastVFX()
		{
			_castVFX = GameObject.Instantiate(_data.CastVFXPrefab, transform.position, Quaternion.identity, gameObject.transform);
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
			yield return new WaitForSeconds(_data.VFXLifeTime);

			Destroy(gameObject);
		}
		#endregion Methods
	}
}