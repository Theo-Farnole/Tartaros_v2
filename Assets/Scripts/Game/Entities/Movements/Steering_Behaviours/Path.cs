namespace Tartaros.Entities.Movement
{
	using UnityEngine;

	public class Path
	{
		#region Fields
		private Vector2[] _waypoints = null;
		private int _currentWaypointIndex = 0;
		#endregion Fields

		#region Properties
		public Vector2 CurrentWaypoint => _waypoints[_currentWaypointIndex];
		public bool IsLastWaypoint => _currentWaypointIndex + 1 == _waypoints.Length;
		#endregion Properties

		#region Ctor
		public Path(Vector2[] waypoints)
		{
			_waypoints = waypoints ?? throw new System.ArgumentNullException(nameof(waypoints));
		}
		#endregion Ctor

		#region Methods
		public void SetNextWaypoint()
		{
			if (IsLastWaypoint == true)
			{
				Debug.LogWarning("Cannot set next waypoint because we reach the last waypoint");
				return;
			}

			_currentWaypointIndex++;
		}
		#endregion Methods
	}
}
