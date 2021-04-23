namespace Tartaros.Entities.Movement
{
	using System.Collections;
	using System.Collections.Generic;
	using Tartaros.Utilities.SpatialPartioning;
	using UnityEngine;

	public static class SteeringBehaviourAgentsDetector
	{
		private const float CELL_SIZE = 2;

		private static SpatialPartioning<ISteeringBehaviourAgent> _spatialPartionning = null;

		public static SpatialPartioning<ISteeringBehaviourAgent> SpatialPartionning
		{
			get
			{
				if (_spatialPartionning == null)
				{
					_spatialPartionning = new SpatialPartioning<ISteeringBehaviourAgent>(CELL_SIZE);
				}

				return _spatialPartionning;
			}
		}

		public static void DebugDrawGrid(Color color, float duration = 0) => SpatialPartionning.DebugDrawGrid(color, duration);
		public static void AddAgent(ISteeringBehaviourAgent agent) => SpatialPartionning.AddElement(agent);

		public static void RemoveAgent(ISteeringBehaviourAgent agent) => SpatialPartionning.RemoveElement(agent);

		public static void MoveAgent(ISteeringBehaviourAgent agent, Vector3 position) => SpatialPartionning.Move(agent, position);

		public static ISteeringBehaviourAgent[] GetAgentsInCell(Vector3 position) => SpatialPartionning.GetElementsInCell(position);

		public static IEnumerable<ISteeringBehaviourAgent> GetNeighbors(Vector3 position, float neighborRadius)
		{
			float neighborDiameter = neighborRadius + neighborRadius;

			return SpatialPartionning.GetElementsInRadiusEnumerator(position, neighborDiameter);
		}
	}
}
