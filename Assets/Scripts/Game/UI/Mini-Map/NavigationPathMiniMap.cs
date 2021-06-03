namespace Tartaros.UI.MiniMap
{
	using System.Collections;
	using UnityEngine;
	using Tartaros.Wave;

	using UnityEngine.AI;
	using System.Collections.Generic;
	using Tartaros.ServicesLocator;

	public class NavigationPathMiniMap : MonoBehaviour
	{
		[SerializeField]
		private MiniMap _miniMap = null;
		[SerializeField]
		private GameObject _mapBackground = null;
		[SerializeField]
		private GameObject _navigationLine = null;
		[SerializeField]
		private Transform _targetPosition = null;

		private RectTransform _rootTransform = null;
		private ISpawnPoint[] _spawnPoints = null;
		private List<GameObject> _navigationLineInstanciate = new List<GameObject>();
		private EnemiesWavesManager _waveManager = null;
		//TODO DJ: Give the position of the Temple automaticaly 


		private void Awake()
		{
			_spawnPoints = ObjectsFinder.FindObjectsOfInterface<ISpawnPoint>();
			FindTargetPosition();
			_waveManager = _miniMap.WaveManager;
		}

		private void FindTargetPosition()
		{
			WavesEnemiesTarget wavesEnemiesTarget = FindObjectOfType<WavesEnemiesTarget>();

			if (wavesEnemiesTarget == null)
			{
				Debug.LogErrorFormat("Cannot draw the enemies path on the minimap: Missing a gameobject with the component {0} in the scene.", nameof(WavesEnemiesTarget));
			}
			else
			{
				_targetPosition = wavesEnemiesTarget.gameObject.transform;
			}
		}

		private void Start()
		{
			_rootTransform = _miniMap.RootTransform;
		}

		public void DrawPathNavigation()
		{
			if (_spawnPoints.Length == 0) return;

			if (_rootTransform == null)
			{
				_rootTransform = _miniMap.RootTransform;
			}

			foreach (NavMeshPath path in GetNavigationsPaths())
			{
				Vector3[] corners = GetCornersNavigationPath(path);
				List<Vector2> vertexs = GetVectors2(corners);
				//Debug.Log(vertexs.Count);

				GameObject navLine = GameObject.Instantiate(_navigationLine, _mapBackground.transform);
				DrawLineUI navPath = navLine.GetComponent<DrawLineUI>();

				navPath.Setup(
				Mathf.RoundToInt(_rootTransform.rect.width),
				Mathf.RoundToInt(_rootTransform.rect.height));

				navPath.SetNavigationPoints(vertexs);
				navPath.SetThickness(5);
				_navigationLineInstanciate.Add(navLine);
			}

		}

		private List<Vector2> GetVectors2(Vector3[] corners)
		{
			List<Vector2> list = new List<Vector2>();
			foreach (Vector3 corner in corners)
			{
				list.Add(_miniMap.WordToUiPosition(corner));
			}
			return list;
		}

		private Vector3[] GetCornersNavigationPath(NavMeshPath path)
		{
			List<Vector3> vertex = new List<Vector3>();

			for (int i = 0; i < path.corners.Length; i++)
			{
				vertex.Add(path.corners[i]);
			}

			return vertex.ToArray();
		}

		private NavMeshPath[] GetNavigationsPaths()
		{
			List<NavMeshPath> navPath = new List<NavMeshPath>();

			foreach (ISpawnPoint point in _spawnPoints)
			{
				if (IsSpawnPointIsActive(point) == true)
				{
					for (int i = 0; i < point.Waypoints.Length; i++)
					{
						var pathWaypoint = new NavMeshPath();

						NavMeshHit hitWaypoint;
						Vector3 positionWaypoint = Vector3.zero;
						if (NavMesh.SamplePosition(point.Waypoints[i], out hitWaypoint, 50, NavMesh.AllAreas))
						{
							positionWaypoint = hitWaypoint.position;
						}

						if (i - 1 < 0)
						{
							NavMesh.CalculatePath(point.SpawnPoint, positionWaypoint, NavMesh.AllAreas, pathWaypoint);
						}
						else
						{
							NavMesh.CalculatePath(point.Waypoints[i - 1], positionWaypoint, NavMesh.AllAreas, pathWaypoint);
						}

						navPath.Add(pathWaypoint);
					}

					var path = new NavMeshPath();

					NavMeshHit hit;
					Vector3 position = Vector3.zero;
					if (NavMesh.SamplePosition(_targetPosition.position, out hit, 50, NavMesh.AllAreas))
					{
						position = hit.position;
					}

					if (point.Waypoints.Length == 0)
					{
						NavMesh.CalculatePath(point.SpawnPoint, position, NavMesh.AllAreas, path);
					}
					else
					{
						NavMesh.CalculatePath(point.Waypoints[point.Waypoints.Length - 1], position, NavMesh.AllAreas, path);
					}

					navPath.Add(path);
				}
			}

			return navPath.ToArray();
		}

		private bool IsSpawnPointIsActive(ISpawnPoint spawnPoint)
		{
			if (_waveManager == null) _waveManager = _miniMap.WaveManager;

			WaveData waveData = _waveManager.WaveSpawnerData.Waves[_waveManager.CurrentWaveIndex];
			SpawnPointIdentifier[] pointsUses = waveData.GetSpawnPointActiveInTheWave();


			foreach (SpawnPointIdentifier identifier in pointsUses)
			{
				if (identifier == spawnPoint.Identifier)
				{
					return true;
				}
			}

			return false;
		}

		public void DisablePathLine()
		{
			if (_navigationLineInstanciate.Count != 0)
			{
				foreach (var line in _navigationLineInstanciate)
				{
					Destroy(line);
				}
				_navigationLineInstanciate.Clear();
			}
		}
	}
}