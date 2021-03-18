namespace Tartaros.Entities.Detection
{
	using System;
	using System.Collections.Generic;
	using Tartaros.ServicesLocator;
	using UnityEngine;

	public class EntitiesKDTrees : MonoBehaviour
	{
		#region Fields
		private Dictionary<Team, KdTree<Entity>> _kdTrees = null;
		#endregion Fields

		#region Methods
		private void Awake()
		{
			Services.Instance.RegisterService(this);

			_kdTrees = new Dictionary<Team, KdTree<Entity>>();

			foreach (Team team in (Team[])Enum.GetValues(typeof(Team)))
			{
				_kdTrees.Add(team, new KdTree<Entity>(true));
			}
		}

		private void OnEnable()
		{
			Entity.EntityKilled -= Entity_EntityKilled;
			Entity.EntityKilled += Entity_EntityKilled;

			Entity.EntitySpawned -= Entity_EntitySpawned;
			Entity.EntitySpawned += Entity_EntitySpawned;
		}

		private void OnDisable()
		{
			Entity.EntityKilled -= Entity_EntityKilled;
			Entity.EntitySpawned -= Entity_EntitySpawned;
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
		#endregion Methods
	}
}