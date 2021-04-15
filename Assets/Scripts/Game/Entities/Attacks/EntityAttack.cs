namespace Tartaros.Entities.Attack
{
	using Tartaros.Entities;
	using Tartaros.Entities.Detection;
	using Tartaros.Entities.State;
	using Tartaros.OrderGiver;
	using Tartaros.Orders;
	using UnityEngine;

	[RequireComponent(typeof(EntityDetection), typeof(EntityFSM), typeof(Entity))]
	public partial class EntityAttack : AEntityBehaviour, IOrderAttackReceiver, IOrderable
	{
		#region Fields
		private EntityAttackData _entityAttackData = null;
		private EntityDetection _entityDetection = null;
		private EntityFSM _entityFSM = null;
		private float _lastTimeAttack = 0;
		#endregion

		#region Properties
		public EntityAttackData EntityAttackData { get => _entityAttackData; set => _entityAttackData = value; }
		public float AttackRange => _entityAttackData.AttackRange;
		#endregion Properties

		#region Methods
		private void Start()
		{
			_entityFSM = GetComponent<EntityFSM>();
			_entityDetection = GetComponent<EntityDetection>();

			_entityAttackData = Entity.GetBehaviourData<EntityAttackData>();

			if (_entityDetection == null)
			{
				Debug.LogError(string.Format("Missing EntityDetection component on \"{0}\". Add detection behaviour on entity data.", name), gameObject);
			}
		}

		public void CastAttackIfPossible(IAttackable target)
		{
			if (IsInRange(target) == false) return;

			if (CanAttackCooldown() == false) return;

			if (_entityAttackData.AttackMode == null)
			{
				Debug.LogErrorFormat("Please set an attack mode in data of {0}.", name);
				return;
			}

			_entityAttackData.AttackMode.Attack(transform, target);
			_lastTimeAttack = Time.time;

		}

		public void TryOrderAttackNearestOpponent()
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
			return Time.time > _lastTimeAttack + _entityAttackData.SecondsBetweenAttacks;
		}

		void IOrderAttackReceiver.Attack(IAttackable target)
		{
			_entityFSM.OrderAttack(target);
		}

		void IOrderAttackReceiver.AttackAdditive(IAttackable target)
		{
			_entityFSM.EnqueueOrderAttack(target);
		}

		Order[] IOrderable.GenerateOrders()
		{
			Order[] orders = new Order[]
			{
				new AttackOrder(Entity)
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
			if (_entityAttackData != null)
			{
				Editor.HandlesHelper.DrawWireCircle(transform.position, Vector3.up, AttackRange, Color.red);
			}
		}
	}
#endif
}