namespace Tartaros.Power
{
	using Sirenix.OdinInspector;
	using System.Collections;
	using Tartaros.Entities;
	using Tartaros.Entities.Detection;
	using Tartaros.OrderGiver;
	using Tartaros.ServicesLocator;
	using UnityEngine;

	public class ControlledAoE : SerializedMonoBehaviour, IPower, IOrderMoveReceiver
	{
		#region Fields
		[SerializeField]
		private ControlledAoEData _data = null;

		private GameObject _preCastVFX = null;
		private GameObject _castVFX = null;
		private ControlledAoEMovement _movement = null;
		private EntitiesKDTrees _kdTree = null;
		#endregion

		#region Properties
		float IPower.Range => _data.SpellRadius;

		GameObject IPower.PrefabPower => gameObject;

		int IPower.Price => _data.GloryPrice;
		#endregion

		#region Methods
		void Awake()
		{
			_movement = gameObject.GetOrAddComponent<ControlledAoEMovement>();
			_kdTree = Services.Instance.Get<EntitiesKDTrees>();
		}

		void Start()
		{
			StartCoroutine(OnInstanciate());
		}

		private void OnDestroy()
		{
			Destroy(_preCastVFX);
			Destroy(_castVFX);
		}

		void OnDrawGizmos()
		{
#if UNITY_EDITOR
			Editor.HandlesHelper.DrawSolidCircle(transform.position, Vector3.up, _data.SpellRadius, Color.red);
#endif
		}

		#region IOrderMoveReceiver
		void IOrderMoveReceiver.Move(Vector3 position)
		{
			_movement.Move(position);
		}

		void IOrderMoveReceiver.Move(Transform toFollow)
		{
			_movement.Move(toFollow);
		}

		void IOrderMoveReceiver.MoveAdditive(Vector3 position)
		{
			_movement.Move(position);
		}

		void IOrderMoveReceiver.MoveAdditive(Transform toFollow)
		{
			_movement.Move(toFollow);
		}
		#endregion IOrderMoveReceiver

		private void InstanciateCastVFX()
		{
			_castVFX = GameObject.Instantiate(_data.CastVFXPrefab, transform.position, Quaternion.identity, gameObject.transform);
		}

		private void AppliedDamage()
		{
			Entity[] entities = _kdTree.GetEveryEntityInRadius(Team.Enemy, transform.position, _data.SpellRadius);

			for (int i = 0; i < entities.Length; i++)
			{
				//IAttackable attackable = entity[i].GetComponent<IAttackable>();
				entities[i].Kill();
			}
		}
		#endregion

		#region Enumerator
		IEnumerator OnInstanciate()
		{
			InstanciateCastVFX();
			yield return new WaitForSeconds(_data.TimeBeforeAppliedDamage);
			StartCoroutine(ApplyDamageFrequently());
		}

		IEnumerator ApplyDamageFrequently()
		{
			for (int i = 0; i < _data.LifeTime; i++)
			{
				AppliedDamage();
				yield return new WaitForSeconds(_data.AttackFrequency);
			}

			Destroy(gameObject);
		}
		#endregion

	}
}