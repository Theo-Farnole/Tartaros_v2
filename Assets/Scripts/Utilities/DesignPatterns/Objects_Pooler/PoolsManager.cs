namespace Tartaros
{
	using System.Collections.Generic;
	using UnityEngine;

	public partial class PoolsManager : MonoBehaviour
	{
		#region Fields
		private const string DBG_ERROR_CANNOT_FIND_POOL = "Can't find pool corresponding to prefab {0}.";
		private const string DBG_ERROR_POOLS_ALREADY_POOL = "Cannot build pools: there are already built.";
		[SerializeField]
		private GameObject[] _pooledPrefabs = new GameObject[0];

		private Dictionary<GameObject, Pool> _prefabsByPool = null;
		#endregion Fields

		#region Methods
		private void Awake()
		{
			BuildPools();
		}

		public GameObject GetObject(GameObject prefab)
		{
			if (_prefabsByPool.TryGetValue(prefab, out Pool pool))
			{
				return pool.GetObject();
			}
			else
			{
				Debug.LogErrorFormat(DBG_ERROR_CANNOT_FIND_POOL, prefab.name);

				return null;
			}
		}

		public void ReleaseObject(GameObject prefab, GameObject objectToRelease)
		{
			if (_prefabsByPool.TryGetValue(prefab, out Pool pool))
			{
				pool.ReleaseObject(objectToRelease);
			}
			else
			{
				Debug.LogErrorFormat(DBG_ERROR_CANNOT_FIND_POOL, prefab.name);
			}
		}

		void BuildPools()
		{
			if (_prefabsByPool != null)
			{
				Debug.LogError(DBG_ERROR_POOLS_ALREADY_POOL);
				return;
			}

			_prefabsByPool = new Dictionary<GameObject, Pool>(_pooledPrefabs.Length);

			foreach (GameObject prefab in _pooledPrefabs)
			{
				_prefabsByPool.Add(prefab, new Pool(prefab));
			}
		}
		#endregion Methods
	}
}
