namespace Tartaros.Entities.Attack
{
	using Tartaros.Entities;
	using Tartaros.Entities.Detection;
	using Tartaros.Entities.State;
	using Tartaros.OrderGiver;
	using Tartaros.Orders;
	using UnityEngine;

	public partial class EntityAttack : MonoBehaviour, IOrderAttackReceiver, IEntityOrderable
	{
		#region Fields
		private EntityAttackData _entityAttackData = null;
		private EntityDetection _entityDetection = null;
		private EntityFSM _entityFSM = null;
		private Entity _entity = null;
		private float _lastTimeAttack = 0;
		#endregion

		#region Properties
		public EntityAttackData EntityAttackData { get => _entityAttackData; set => _entityAttackData = value; }
		public float AttackRange => _entityAttackData.AttackRange;
		#endregion Properties

		#region Methods
		private void Start()
		{
			_entity = GetComponent<Entity>();
			_entityFSM = GetComponent<EntityFSM>();
			_entityDetection = GetComponent<EntityDetection>();

			if (_entityDetection == null)
			{
				Debug.LogError(string.Format("Missing EntityDetection component on \"{0}\". Add detection behaviour on entity data.", name), gameObject);
			}
		}

		private void OnDrawGizmosSelected()
		{
			if (Application.isPlaying == true)
			{
				Gizmos.color = Color.blue;
				Gizmos.DrawWireSphere(transform.position, _entityAttackData.AttackRange);
			}
		}

		public void CastAttackIfPossible(IAttackable target)
		{
			if (IsInRange(target) == false) return;

			if (CanAttackCooldown() == false) return;

			_entityAttackData.AttackMode.Attack(transform, target);
			_lastTimeAttack = Time.time;

		}

		public void TryAttackNearestOpponent()
		{
			IAttackable attackable = _entityDetection.GetNearestAttackableOpponentInDetectionRange();

			if (attackable != null)
			{
				(this as IOrderAttackReceiver).Attack(attackable);
			}
		}

		public bool IsInRange(IAttackable target)
		{
			return _entityDetection.IsInAttackRange(target.Transform.position);
		}

		public bool CanAttackCooldown()
		{
			return Time.time > _lastTimeAttack + _entityAttackData.AttackSpeed;
		}

		void IOrderAttackReceiver.Attack(IAttackable target)
		{
			_entityFSM.SetState(new StateAttack(_entity, target));
		}

		void IOrderAttackReceiver.AttackAdditive(IAttackable target)
		{
			_entityFSM.EnqueueState(new StateAttack(_entity, target));
		}

		Order[] IEntityOrderable.GenerateOrders(Entity entity)
		{
			Order[] orders = new Order[]
			{
				new AttackOrder(entity)
			};

			return orders;
		}
		#endregion
	}

#if UNITY_EDITOR
	public partial class EntityAttack
	{
		private void OnDrawGizmos()
		{
			Editor.HandlesHelper.DrawWireCircle(transform.position, Vector3.up, AttackRange, Color.red);
		}
	}
#endif
}