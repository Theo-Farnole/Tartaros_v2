namespace Tartaros.Entities
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using Tartaros.Entities;
	using Tartaros.Entities.Attack;
	using Tartaros.ServicesLocator;

	public class EntityDetection : MonoBehaviour
	{
		#region Fields
		private EntityDetectionData _entityDetectionData = null;
		private EntityAttackData _entityAttackData = null;
		private EntitiesKDTrees _entitiesKDTrees = null;
		#endregion

		#region Properties
		public EntityDetectionData EntityDetectionData { get => _entityDetectionData; set => _entityDetectionData = value; }
		public EntityAttackData EntityAttackData { get => _entityAttackData; set => _entityAttackData = value; }
		#endregion Properties

		#region Methods
		private void Start()
		{
			_entitiesKDTrees = Services.Instance.Get<EntitiesKDTrees>();
		}

		public Entity GetNearest(SearchQuary searchQuery)
		{
			throw new System.NotImplementedException();
		}

		public IAttackable GetNearestAttackableOpponent()
		{
			IEnumerable<Entity> opponents = _entitiesKDTrees.GetNearestOpponentsEntities(transform.position);
			IEnumerator<Entity> opponentsEnumerator = opponents.GetEnumerator();

			while (opponentsEnumerator.Current != null)
			{
				if (opponentsEnumerator.Current.TryGetComponent(out IAttackable attackable))
				{
					return attackable;
				}
				else
				{
					opponentsEnumerator.MoveNext();
				}
			}

			return null;
		}

		public bool IsNearestEnemyInDetectionRange()
		{
			Entity nearestEntity = _entitiesKDTrees.GetNearestOpponentEntity(transform.position);

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

		public bool IsInAttackRange(Entity nearest, float attackRange)
		{
			return IsInAttackRange(nearest.transform.position, attackRange);
		}

		public bool IsInAttackRange(Vector3 point, float attackRange)
		{
			float distance = Vector3.Distance(this.transform.position, point);

			return distance <= attackRange;
		}
		#endregion
	}
}