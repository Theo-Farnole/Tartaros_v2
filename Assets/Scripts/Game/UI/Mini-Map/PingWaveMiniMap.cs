namespace Tartaros.UI.MiniMap
{
	using System.Collections;
	using System.Collections.Generic;
	using Tartaros.Wave;
	using UnityEngine;

	public class PingWaveMiniMap : MonoBehaviour
	{
		private MiniMap _miniMap = null;
		[SerializeField]
		private GameObject _mapBackground = null;
		[SerializeField]
		private GameObject _pingPrefab = null;
		[SerializeField]
		private float _pingLifeTime = 6;

		private RectTransform _rootTransform = null;
		private ISpawnPoint[] _spawnPoints = null;
		private List<GameObject> _navigationLineInstanciate = new List<GameObject>();
		private GameObject[] _pingArray = null;

		private void Awake()
		{
			_miniMap = GetComponent<MiniMap>();
			_spawnPoints = ObjectsFinder.FindObjectsOfInterface<ISpawnPoint>();
		}

		private void Start()
		{
			_rootTransform = _miniMap.RootTransform;
		}

		public void PingStartWaveCooldown()
		{
			var corners = GetVectors2(GetSapwnPointStart());
			List<GameObject> pings = new List<GameObject>();

			foreach(Vector2 corner in corners)
			{
				GameObject ping = GameObject.Instantiate(_pingPrefab, _mapBackground.transform);

				Debug.Log(ping);

				RectTransform rectPing = ping.GetComponent<RectTransform>();
				rectPing.SetParent(_mapBackground.transform, false);
				rectPing.localScale = Vector3.one;
				//rectPing.sizeDelta = size;
				rectPing.anchoredPosition = corner;
				pings.Add(ping);
			}

			_pingArray = pings.ToArray();
			StartCoroutine(PingLifeTime(_pingLifeTime));
		}

		private List<Vector2> GetVectors2(Vector3[] corners)
		{
			List<Vector2> list = new List<Vector2>();
			foreach (Vector3 corner in corners)
			{
				Debug.Log(corner);
				Debug.Log(_miniMap.WordToUiPosition(corner));
				list.Add(_miniMap.WordToUiPosition(corner));
			}
			return list;
		}

		private Vector3[] GetSapwnPointStart()
		{
			List<Vector3> output = new List<Vector3>();

			foreach (var spawn in _spawnPoints)
			{
				output.Add(spawn.SpawnPoint);
			}

			return output.ToArray();
		}

		private void DestroyPings()
		{
			if (_pingArray.Length < 1) return;

			foreach (var ping in _pingArray)
			{
				if(ping != null)
				{
					GameObject.Destroy(ping);
				}
			}
		}

		IEnumerator PingLifeTime(float lifeTime)
		{
			yield return new WaitForSeconds(lifeTime);
			DestroyPings();
		}

	}
}