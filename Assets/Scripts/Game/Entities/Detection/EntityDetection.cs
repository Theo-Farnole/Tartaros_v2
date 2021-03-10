namespace Tartaros.Entities.Detection
{
	using System;
	using System.Collections.Generic;
	using Tartaros.Entities;
	using Tartaros.ServicesLocator;
	using UnityEngine;

	public class EntityDetection : MonoBehaviour
	{
		#region Fields
		private EntityDetectionData _entityDetectionData = null;
		private EntityAttackData _entityAttackData = null;
		private Entity _entity = null;

		private EntitiesKDTrees _entitiesKDTrees = null;
		#endregion

		#region Properties
		public EntityDetectionData EntityDetectionData { get => _entityDetectionData; set => _entityDetectionData = value; }
		public EntityAttackData EntityAttackData { get => _entityAttackData; set => _entityAttackData = value; }
		public Team OpponentTeam => Entity.Team.GetOpponent();
		private Entity Entity
		{
			get
			{
				if (_entity == null)
				{
					_entity = GetComponent<Entity>();
				}

				return _entity;
			}
		}
		#endregion Properties

		#region Methods
		private void Awake()
		{
			_entitiesKDTrees = Services.Instance.Get<EntitiesKDTrees>();
		}

		public IAttackable GetNearestAttackableOpponent()
		{
			var opponents = GetOpponentsOrderByDistance();

			foreach (var entity in opponents)
			{
				if (entity.TryGetComponent(out IAttackable attackable))
				{
					return attackable;
				}
			}

			return null;
		}

		public Entity GetNearestOpponentUnit()
		{
			return GetNearestOpponentByType(EntityType.Unit);
		}

		public Entity GetNearestOpponentBuilding()
		{
			return GetNearestOpponentByType(EntityType.Building);
		}

		public Entity GetNearestOpponentByType(EntityType entityType)
		{
			IEnumerable<Entity> opponents = GetOpponentsOrderByDistance();

			foreach (Entity entity in opponents)
			{
				if (entity.entityType == entityType)
				{
					return entity;
				}
			}

			return null;
		}

		public bool IsNearestOpponentInDetectionRange()
		{
			Entity nearestEntity = _entitiesKDTrees.FindClosest(OpponentTeam, transform.position);

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
			float distance = Vector3.Distance(transform.position, point);

			return distance <= attackRange;
		}


		private IEnumerable<Entity> GetOpponentsOrderByDistance()
		{
			IEnumerable<Entity> enumerable = _entitiesKDTrees.FindClose(OpponentTeam, transform.position);

			return enumerable;
		}
		#endregion
	}
}