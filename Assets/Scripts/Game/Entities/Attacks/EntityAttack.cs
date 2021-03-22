namespace Tartaros.Entities.Attack
{
	using Tartaros.Entities;
	using Tartaros.Entities.Detection;
	using Tartaros.Entities.State;
	using Tartaros.OrderGiver;
	using UnityEngine;

	public class EntityAttack : MonoBehaviour, IOrderAttackReceiver
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

		public void CastAttack(IAttackable target)
		{
			if (CanAttack(target) == false) return;
			
			_entityAttackData.AttackMode.Attack(transform, target);
			_lastTimeAttack = Time.time;

		}

		public bool CanAttack(IAttackable target)
		{
			// TODO TF: extract those conditions into differents methods
			return Time.time > _lastTimeAttack + _entityAttackData.AttackSpeed && _entityDetection.IsInAttackRange(target.Transform.position);
		}

		void IOrderAttackReceiver.Attack(IAttackable target)
		{
			_entityFSM.SetState(new StateAttack(_entity, target));
		}

		void IOrderAttackReceiver.AttackAdditive(IAttackable target)
		{
			_entityFSM.EnqueueState(new StateAttack(_entity, target));
		}
		#endregion
	}

}