namespace Tartaros.Entities.Movement
{
	using UnityEngine;

	public class PatrolPoints
	{
		private readonly Vector3[] waypoints;

		public Vector3 this[int i]
		{
			get => waypoints[i];
		}

		public int WaypointsCount => waypoints.Length;
		
		public PatrolPoints(params Vector3[] waypoints)
		{
			this.waypoints = waypoints;
		}
	}
}