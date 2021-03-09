namespace Tartaros.Entities
{
	using System.Collections.Generic;
	using Tartaros.ServicesLocator;
	using UnityEngine;

	public class EntitiesKDTrees : MonoBehaviour
	{
		#region Fields
		private KdTree<Entity> _playerEntitiesTree = null;
		private KdTree<Entity> _opponentEntitiesTree = null;
		#endregion Fields

		#region Methods
		private void Awake()
		{
			Services.Instance.RegisterService(this);
		}

		private void Start()
		{
			_playerEntitiesTree = new KdTree<Entity>(true);
			_opponentEntitiesTree = new KdTree<Entity>(true);
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
			switch (e.entity.Team)
			{
				case Team.Player:
					AddPlayerEntity(e.entity);
					break;

				case Team.Opponent:
					AddOpponentEntity(e.entity);
					break;

				default:
					throw new System.NotImplementedException();
			}
		}

		private void Entity_EntityKilled(object sender, Entity.EntityKilledArgs e)
		{
			switch (e.entity.Team)
			{
				case Team.Player:
					RemovePlayerEntity(e.entity);
					break;

				case Team.Opponent:
					AddPlayerEntity(e.entity);
					break;

				default:
					throw new System.NotImplementedException();
			}
		}

		public Entity GetNearestOpponentEntity(Vector3 position) => _opponentEntitiesTree.FindClosest(position);
		public IEnumerable<Entity> GetNearestOpponentsEntities(Vector3 position) => _opponentEntitiesTree.FindClose(position);

		public Entity GetNearestPlayerEntity(Vector3 position) => _playerEntitiesTree.FindClosest(position);
		public IEnumerable<Entity> GetNearestPlayerEntities(Vector3 position) => _opponentEntitiesTree.FindClose(position);

		public void AddOpponentEntity(Entity entity) => _opponentEntitiesTree.Add(entity);
		public void RemoveOpponentEntity(Entity entity) => _opponentEntitiesTree.RemoveAll(x => x == entity);

		public void AddPlayerEntity(Entity entity) => _playerEntitiesTree.Add(entity);
		public void RemovePlayerEntity(Entity entity) => _playerEntitiesTree.RemoveAll(x => x == entity);
		#endregion Methods
	}
}