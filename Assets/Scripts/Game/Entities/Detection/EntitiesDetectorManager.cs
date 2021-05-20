namespace Tartaros.Entities.Detection
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Tartaros.Entities.Health;
	using UnityEngine;

	public class EntitiesDetectorManager : MonoBehaviour
	{
		#region Fields
		private Dictionary<Team, KdTree<Entity>> _kdTrees = null;
		#endregion Fields

		#region Methods
		private void Awake()
		{
			_kdTrees = new Dictionary<Team, KdTree<Entity>>();

			foreach (Team team in (Team[])Enum.GetValues(typeof(Team)))
			{
				// TODO TF: (perf) use 2D kd tree if possible
				_kdTrees.Add(team, new KdTree<Entity>(false));
			}
		}

		private void OnEnable()
		{
			Entity.AnyEntityKilled -= Entity_EntityKilled;
			Entity.AnyEntityKilled += Entity_EntityKilled;

			Entity.AnyEntitySpawned -= Entity_EntitySpawned;
			Entity.AnyEntitySpawned += Entity_EntitySpawned;
		}

		private void OnDisable()
		{
			Entity.AnyEntityKilled -= Entity_EntityKilled;
			Entity.AnyEntitySpawned -= Entity_EntitySpawned;
		}

		private void Entity_EntitySpawned(object sender, Entity.EntitySpawnedArgs e)
		{
			AddEntityFromKDTree(e.entity.Team, e.entity);
		}

		private void Entity_EntityKilled(object sender, Entity.EntityKilledArgs e)
		{
			RemoveEntityFromKDTree(e.entity.Team, e.entity);
		}

		public Entity FindClosest(Team entityTeamToGet, Vector3 position) => _kdTrees[entityTeamToGet].FindClosest(position);
		public IEnumerable<Entity> FindClose(Team entityTeamToGet, Vector3 position) => FindAllEntitiesOfTeam(entityTeamToGet).OrderBy(entity => Vector3.Distance(position, entity.transform.position));

		private void AddEntityFromKDTree(Team team, Entity entity) => _kdTrees[team].Add(entity);
		private void RemoveEntityFromKDTree(Team team, Entity entity) => _kdTrees[team].RemoveAll(x => x == entity);

		// TODO TF: (perf)
		public Entity[] GetEveryEntityInRadius(Team team, Vector3 position, float radius)
		{
			var entitiesOfTeam = FindAllEntitiesOfTeam(team);
			List<Entity> output = new List<Entity>();

			foreach (Entity entity in entitiesOfTeam)
			{
				float distance = Vector3.Distance(position, entity.transform.position);
				float targetRadius = entity.GetComponent<IAttackable>().SizeRadius;

				if(IsTheTwoRadiusAreOverlapping(radius, targetRadius, distance))
				{
					output.Add(entity);
				}
			}

			return output.ToArray();
		}

		public bool IsTheTwoRadiusAreOverlapping(float entityRadius, float targetRadius, float distance)
		{
			var radius = entityRadius + targetRadius;

			return radius >= distance; 
		}

		public Entity[] FindAllEntitiesOfTeam(Team team)
		{
			return GameObject.FindObjectsOfType<Entity>().Where(x => x.Team == team).ToArray();
		}

		public IAttackable GetNearestAttackable(Vector3 position, Team team, float radius)
		{
			Entity nearestOpponent = FindClosest(team, position);

			// let's find the nearest using the KD-Tree
			if (nearestOpponent != null && nearestOpponent.TryGetComponent(out IAttackable nearestAttackable) == true)
			{
				if (IsInRadius(position, radius, nearestOpponent) == true)
				{
					return nearestAttackable;
				}
				else
				{
					return null;
				}
			}
			// if the nearest entity has not a IAttackable component, let's use the hard way
			else
			{
				Debug.Log(string.Format("Nearest entity using KD-Tree is {0} of team {1}. It is not a attackable.", nearestOpponent, team), nearestOpponent);

				Entity[] entitiesInRange = this.GetEveryEntityInRadius(team, transform.position, radius);

				foreach (Entity entity in entitiesInRange)
				{
					if (entity.TryGetComponent(out IAttackable entityAttackable) && IsInRadius(position, radius, entity))
					{
						return entityAttackable;
					}
				}

				return null;
			}
		}

		private static bool IsInRadius(Vector3 position, float radius, Entity entity)
		{
			return Vector3.Distance(entity.transform.position, position) <= radius;
		}
		#endregion Methods
	}
}