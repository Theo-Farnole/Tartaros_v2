namespace Tartaros
{
	using UnityEngine;

	public class PrefabBulkSpawner : MonoBehaviour
	{
		#region Fields
		[SerializeField]
		private int _instanceToSpawn = 1000;

		[SerializeField]
		private GameObject _prefabToSpawn = null;

		[SerializeField]
		private bool _spawnOnStart = true;

		[SerializeField]
		private float _spawnRadius = 5;
		#endregion Fields

		#region Methods
		void Start()
		{
			if (_spawnOnStart == true)
			{
				SpawnInstances();
			}
		}

#if UNITY_EDITOR
		void OnDrawGizmos()
		{
			Editor.HandlesHelper.DrawSolidCircle(transform.position, Vector3.up, _spawnRadius, Color.green);
		}
#endif

		public void SpawnInstances()
		{
			for (int i = 0; i < _instanceToSpawn; i++)
			{
				Instantiate(_prefabToSpawn, GetRandomSpawnPosition(), Quaternion.identity);
			}
		}

		private Vector3 GetRandomSpawnPosition()
		{
			return transform.position + Random.insideUnitCircle.ToXZ() * _spawnRadius;
		}
		#endregion Methods
	}
}
