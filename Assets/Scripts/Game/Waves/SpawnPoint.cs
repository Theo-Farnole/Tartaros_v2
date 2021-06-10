namespace Tartaros.Wave
{
	using Sirenix.OdinInspector;
	using System.Collections.Generic;
	using Tartaros;
	using UnityEngine;
	using UnityEngine.AI;

	public partial class SpawnPoint : MonoBehaviour, ISpawnPoint
	{
		#region Fields
		[SerializeField]
		private float _randomRadius = 0;

		[SerializeField]
		private SpawnPointIdentifier _identifier;

		[SerializeField]
		private Vector3[] _waypoints = null;

		private NavMeshPath[] _navPath = null;

		#endregion Fields

		#region Properties
		SpawnPointIdentifier ISpawnPoint.Identifier => _identifier;

		Vector3 ISpawnPoint.SpawnPoint => Random.insideUnitCircle.ToXZ() * _randomRadius + transform.position;

		Vector3[] ISpawnPoint.Waypoints => _waypoints;
		public Vector3[] Waypoints { get => _waypoints; set => _waypoints = value; }

		public NavMeshPath[] NavMeshPathArray => _navPath;

		NavMeshPath[] ISpawnPoint.NavPaths => _navPath;

		#endregion Properties

		private void Start()
		{
			SetNavMeshPath();
		}

		private NavMeshPath CalculeNavMeshPath(Vector3 start, Vector3 end)
		{
			NavMeshPath path = new NavMeshPath();
			NavMesh.CalculatePath(start, end, NavMesh.AllAreas, path);
			return path;
		}

		private void SetNavMeshPath()
		{
			List<NavMeshPath> list = new List<NavMeshPath>();

			for (int i = 0; i < _waypoints.Length; i++)
			{
				Vector3 start = Vector3.zero;

				if (i == 0)
				{
					start = transform.position;
				}
				else
				{
					start = _waypoints[i - 1];
				}

				list.Add(CalculeNavMeshPath(start, _waypoints[i]));
			}
			_navPath = list.ToArray();
		}
	}

#if UNITY_EDITOR
	public partial class SpawnPoint
	{
		[FoldoutGroup("Editor Preferences")]
		[SerializeField] private Color _lineColor = Color.green;


		#region Methods
		private void OnDrawGizmos()
		{
			Gizmos.DrawIcon(transform.position, "skull-crossed-bones.png");
			Tartaros.Editor.HandlesHelper.DrawWireCircle(transform.position, Vector3.up, _randomRadius, Color.white);
			UnityEditor.Handles.Label(transform.position, _identifier.ToString());
		}

		private void OnDrawGizmosSelected()
		{
			DrawWaypointsLines();
		}

		private void DrawWaypointsLines()
		{
			if (_waypoints.Length > 0)
			{
				Gizmos.color = _lineColor;

				for (int i = 0; i < Waypoints.Length; i++)
				{
					Vector3 waypoint = Waypoints[i];
					Vector3 previousWaypoint = i == 0 ? transform.position : Waypoints[i - 1];

					Gizmos.DrawLine(previousWaypoint, waypoint);
				}
			}
		}

		#endregion Methods
	}
#endif
}