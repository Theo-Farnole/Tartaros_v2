namespace Tartaros.Entities.Attack
{
	using Tartaros.Entities;
	using Tartaros.Entities.Detection;
	using UnityEngine;

	public class EntityAttack : MonoBehaviour
	{
		#region Fields
		private EntityAttackData _entityAttackData = null;
		private EntityDetection _entityDetection = null;
		private EntityMovement _entityMovement = null;
		#endregion

		#region Properties
		public EntityAttackData EntityAttackData { get => _entityAttackData; set => _entityAttackData = value; }
		#endregion Properties

		#region Methods
		private void Awake()
		{
			_entityDetection = GetComponent<EntityDetection>();
			_entityMovement = GetComponent<EntityMovement>();
		}

		public void DoDamage(IAttackable target)
		{
			if (CanAttack(target) == false)
			{
				Debug.LogErrorFormat("Entity {0} trying to attack an out of attack range entity.", name);
				return;
			}

			target.TakeDamage(_entityAttackData.Damage);
		}

		public bool CanAttack(IAttackable target)
		{
			return _entityDetection.IsInAttackRange(target.Transform.position, _entityAttackData.AttackRange);
		}
		#endregion
	}

}