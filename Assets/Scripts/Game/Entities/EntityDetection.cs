namespace Tartaros.Entities
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using Tartaros.Entities;
	using Tartaros.Entities.Attack;

	public class EntityDetection : MonoBehaviour
	{
		#region Fields
		private EntityDetectionData _entityDetectionData = null;
		private EntityAttackData _entityAttackData = null;
		private List<Transform> _nearEntities = new List<Transform>();

		public EntityDetectionData EntityDetectionData { get => _entityDetectionData; set => _entityDetectionData = value; }
		public EntityAttackData EntityAttackData { get => _entityAttackData; set => _entityAttackData = value; }

		private float _viewRadius;
		private float _attackRange = 1;
		#endregion

		#region Methods


		public Entity GetNearest(SearchQuary searchQuary)
		{
			throw new System.NotImplementedException();
		}

		public IAttackable GetNearestAttackableEnemy()
		{
			throw new System.NotImplementedException();
		}

		public bool IsNearestEnemyInDetectionRange()
		{
			Entity nearestEntity = GetNearest(SearchQuary.Enemy | SearchQuary.Unit | SearchQuary.Building);

			return IsInDetectionRange(nearestEntity);
		}

		public bool IsInDetectionRange(Entity entity)
		{
			return IsInDetectionRange(entity.transform.position);
		}

		public bool IsInDetectionRange(Vector3 point)
		{
			return Vector3.Distance(transform.position, point) <= _entityDetectionData.DetectionRange;
		}

		public bool IsInAttackRange(Entity nearest, float attackRange) => IsInAttackRange(nearest.transform.position, attackRange);

		public bool IsInAttackRange(Vector3 point, float attackRange)
		{
			float distance = Vector3.Distance(this.transform.position, point);

			return distance <= attackRange;
		}
		#endregion
	}
}