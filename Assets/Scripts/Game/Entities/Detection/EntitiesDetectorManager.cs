namespace Tartaros.Entities.Detection
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
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
		public IEnumerable<Entity> FindClose(Team entityTeamToGet, Vector3 position) => _kdTrees[entityTeamToGet].FindClose(position);

		private void AddEntityFromKDTree(Team team, Entity entity) => _kdTrees[team].Add(entity);
		private void RemoveEntityFromKDTree(Team team, Entity entity) => _kdTrees[team].RemoveAll(x => x == entity);

		// TODO TF: (perf)
		public Entity[] GetEveryEntityInRadius(Team team, Vector3 position, float radius)
		{
			var entitiesOfTeam = FindAllEntitiesOfTeam(team);
			List<Entity> output = new List<Entity>();

			foreach (Entity entity in entitiesOfTeam)
			{
				if (Vector3.Distance(position, entity.transform.position) <= radius)
				{
					output.Add(entity);
				}
			}

			return output.ToArray();
		}

		public Entity[] FindAllEntitiesOfTeam(Team team)
		{
			return GameObject.FindObjectsOfType<Entity>().Where(x => x.Team == team).ToArray();
		}
		#endregion Methods
	}
}