namespace Tartaros.Entities
{
	using System.Collections;
	using UnityEngine;
	using UnityEngine.AI;

	public class VillagerSpawnerManager : MonoBehaviour
	{
		private const float THRESHOLD_DISTANCE = 0.5f;

		[SerializeField]
		private Transform[] _spawnPoints = null;

		[SerializeField]
		private GameObject _villagerMalePrefab = null;

		[SerializeField]
		private GameObject _villagetFemalePrefab = null;
		private Transform _templePosition = null;

		private EntityUnitsSpawner _spawner = null;
		private Vector3 _targetPosition = Vector3.zero;
		private GameObject _villager = null;

		private void Start()
		{
			_spawner = GetComponent<EntityUnitsSpawner>();
			_templePosition = GetComponent<Transform>();
			_targetPosition = GetTargetPosition();
		}

		private void Update()
		{
			if(_villager != null)
			{
				AsReachDestination();
			}
		}

		public void SpawnFuturHoplite()
		{
			if(_spawnPoints.Length <= 0)
			{
				Debug.LogError("there is no spawnPoint to spawn villager");
				return;
			}

			Transform spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length - 1)];
			GameObject villager = GameObject.Instantiate(_villagerMalePrefab, spawnPoint.position, Quaternion.identity);
			_villager = villager;
			SetDestinationToVillager(villager);
		}

		private void SetDestinationToVillager(GameObject villager)
		{
			villager.GetComponent<NavMeshAgent>().SetDestination(_targetPosition);
		}

		private Vector3 GetTargetPosition()
		{
			var templeLenght = _templePosition.GetComponent<NavMeshObstacle>().size.z;
			var position = new Vector3(_templePosition.position.x, _templePosition.position.y, _templePosition.position.z - templeLenght);
			Debug.Log(NavMeshHelper.AdjustPositionToFitNavMesh(position));

			return NavMeshHelper.AdjustPositionToFitNavMesh(position);
		}

		private void AsReachDestination()
		{
			if(_villager == null)
			{
				return;
			}
			var distanceFromTargetPoint = Vector3.Distance(_villager.transform.position, _targetPosition);

			if(distanceFromTargetPoint <= THRESHOLD_DISTANCE)
			{
				Destroy(_villager);
			}
		}

		public void DestroySecurity()
		{
			
		}
	}
}