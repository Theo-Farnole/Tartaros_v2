namespace Tartaros.Entities.Detection
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Tartaros.Entities;
	using Tartaros.Entities.Attack;
	using Tartaros.ServicesLocator;
	using UnityEngine;

	[RequireComponent(typeof(Entity))]
	[DisallowMultipleComponent]
	public partial class EntityDetection : AEntityBehaviour
	{
		#region Fields
		private EntityDetectionData _entityDetectionData = null;
		private EntitiesDetectorManager _entitiesKDTrees = null;
		private EntityAttack _entityAttack = null;
		#endregion

		#region Properties
		public EntityDetectionData EntityDetectionData
		{
			get => _entityDetectionData;

			set
			{
				_entityDetectionData = value;

				if (_entityDetectionData != null)
				{
					if (DetectionRange <= 0)
					{
						Debug.LogWarningFormat("Detection range of {0} is less or equals to zero.", DetectionRange);
					}
				}
			}
		}
		public Team OpponentTeam => Entity.Team.GetOpponent();
		public float DetectionRange => _entityDetectionData.DetectionRange;

		public float AttackRange
		{
			get
			{
				if (_entityAttack == null)
				{
					throw new System.NotSupportedException(string.Format("Cannot detect entities inside the attack range because the entity {0} doesn't have an {1} component.", name, nameof(EntityAttack)));
				}

				return _entityAttack.EntityAttackData.AttackRange;
			}
		}
		#endregion Properties

		#region Methods
		private void Awake()
		{
			_entitiesKDTrees = Services.Instance.Get<EntitiesDetectorManager>();
			_entityAttack = GetComponent<EntityAttack>();

			EntityDetectionData = Entity.GetBehaviourData<EntityDetectionData>();
		}

		public IAttackable GetNearestAttackableOpponent()
		{
			IEnumerable<Entity> opponents = GetOpponentsOrderByDistance();

			foreach (Entity entity in opponents)
			{
				if (entity.TryGetComponent(out IAttackable attackable))
				{
					return attackable;
				}
			}

			return null;
		}

		public IAttackable GetNearestAttackableOpponentInDetectionRange()
		{
			return _entitiesKDTrees.GetNearestAttackable(transform.position, OpponentTeam, DetectionRange);
		}


		public Entity GetNearestOpponent()
		{
			return _entitiesKDTrees.FindClosest(OpponentTeam, transform.position);
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
				if (entity.EntityType == entityType)
				{
					return entity;
				}
			}

			return null;
		}

		public Entity GetNearestAllyUnit()
		{
			return GetNearestAllyByType(EntityType.Unit);
		}

		public Entity GetNearestAllyBuilding()
		{
			return GetNearestAllyByType(EntityType.Building);
		}

		public Entity GetNearestAllyByType(EntityType entityType)
		{
			IEnumerable<Entity> allies = GetAlliesOrderByDistance();

			foreach (Entity entity in allies)
			{
				if (entity.EntityType == entityType)
				{
					return entity;
				}
			}

			return null;
		}

		public bool IsNearestOpponentInDetectionRange()
		{
			Entity nearestEntity = GetNearestOpponent();

			if (nearestEntity == null)
			{
				return false;
			}
			else
			{
				return IsInDetectionRange(nearestEntity);
			}
		}

		public bool IsInDetectionRange(Entity entity)
		{
			return IsInDetectionRange(entity.transform.position);
		}

		public bool IsInDetectionRange(Vector3 point)
		{
			return Vector3.Distance(transform.position, point) <= _entityDetectionData.DetectionRange;
		}

		public bool IsInAttackRange(Entity nearest)
		{
			return IsInAttackRange(nearest.transform.position);
		}

		public bool IsInAttackRange(Vector3 point)
		{
			if (AttackRange == -1) Debug.LogWarningFormat("EntityDetection has not attack range. Calling IsInAttackRange requires a EntityAttack component.");

			float distance = Vector3.Distance(transform.position, point);

			return distance <= AttackRange;
		}

		public bool IsInAttackRange(IAttackable target)
		{
			if(target.IsInterfaceDestroyed() == true)
			{
				return false;
			}
			float distance = Vector3.Distance(transform.position, target.Transform.position);
			float targetRadius = target.SizeRadius;

			return _entitiesKDTrees.IsTheTwoRadiusAreOverlapping(DetectionRange, targetRadius, distance);
		}

		public Entity[] GetEveryOpponentInRange()
		{
			foreach (var entity in _entitiesKDTrees.GetEveryEntityInRadius(OpponentTeam, transform.position, AttackRange))
			{
				Vector3 direction = transform.position - entity.gameObject.transform.position;

				Debug.DrawRay(transform.position, -direction, Color.cyan);
			}
			return _entitiesKDTrees.GetEveryEntityInRadius(OpponentTeam, transform.position, AttackRange);
		}
		
		private IEnumerable<Entity> GetOpponentsOrderByDistance()
		{
			IEnumerable<Entity> enumerable = _entitiesKDTrees.FindClose(OpponentTeam, transform.position);

			return enumerable;
		}

		private IEnumerable<Entity> GetAlliesOrderByDistance()
		{
			IEnumerable<Entity> enumerable = _entitiesKDTrees.FindClose(Entity.Team, transform.position)
				.Where(ally => ally != Entity);

			return enumerable;
		}
		#endregion
	}

#if UNITY_EDITOR
	public partial class EntityDetection
	{
		private void OnDrawGizmos()
		{
			if (_entityDetectionData != null)
			{
				Editor.HandlesHelper.DrawWireCircle(transform.position, Vector3.up, DetectionRange, Color.grey);
			}
		}
	}
#endif // UNITY_EDITOR
}