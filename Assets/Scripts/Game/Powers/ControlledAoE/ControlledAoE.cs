namespace Tartaros.Powers
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
			_movement = gameObject.GetOrAddComponent<ControlledAoEMovement>();
			_kdTree = Services.Instance.Get<EntitiesDetectorManager>();
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

		void IOrderMoveReceiver.Follow(Transform toFollow)
		{
			_movement.Move(toFollow);
		}

		void IOrderMoveReceiver.EnqueueMove(Vector3 position)
		{
			_movement.Move(position);
		}

		void IOrderMoveReceiver.EnqueueFollow(Transform toFollow)
		{
			_movement.Move(toFollow);
		}
		#endregion IOrderMoveReceiver

		private void InstanciateCastVFX()
		{
			_castVFX = GameObject.Instantiate(_data.CastVFXPrefab, transform.position, Quaternion.identity, gameObject.transform);
			_castVFX.transform.localScale = Vector3.one * _data.SpellRadius * 2;
			_animator = _castVFX.GetComponent<Animator>();
		}

		private void AppliedDamage()
		{
			Entity[] entities = _kdTree.GetEntitiesInRadius(Team.Enemy, transform.position, _data.SpellRadius);

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

			int time = _animator.GetCurrentAnimatorClipInfo(0).Length;

			yield return new WaitForSeconds(time);
			
			StartCoroutine(ApplyDamageFrequently());
		}

		IEnumerator ApplyDamageFrequently()
		{
			for (float i = 0; i < _data.LifeTime; i += _data.AttackFrequency)
			{
				AppliedDamage();
				yield return new WaitForSeconds(_data.AttackFrequency);
			}

			_animator.SetBool("isFinish", true);

			int time = _animator.GetCurrentAnimatorClipInfo(0).Length;

			yield return new WaitForSeconds(time);

			Destroy(gameObject);
		}
		#endregion

	}
}