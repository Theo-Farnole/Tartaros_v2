namespace Tartaros.Entities.Movement
{
	using System.Collections;
	using System.Collections.Generic;
	using Tartaros.Utilities.SpatialPartioning;
	using UnityEngine;

	public static class SteeringBehaviourAgentsDetector
	{
		private const float CELL_SIZE = 2;

		private static SpatialPartioning<SteeringBehaviourAgent> _spatialPartionning = null;

		public static SpatialPartioning<SteeringBehaviourAgent> SpatialPartionning
		{
			get
			{
				if (_spatialPartionning == null)
				{
					_spatialPartionning = new SpatialPartioning<SteeringBehaviourAgent>(CELL_SIZE);
				}

				return _spatialPartionning;
			}
		}

		public static void DebugDrawGrid(Color color, float duration = 0) => SpatialPartionning.DebugDrawGrid(color, duration);
		public static void AddAgent(SteeringBehaviourAgent agent) => SpatialPartionning.AddElement(agent);

		public static void RemoveAgent(SteeringBehaviourAgent agent) => SpatialPartionning.RemoveElement(agent);

		public static void MoveAgent(SteeringBehaviourAgent agent, Vector3 position) => SpatialPartionning.Move(agent, position);

		public static SteeringBehaviourAgent[] GetAgentsInCell(Vector3 position) => SpatialPartionning.GetElementsInCell(position);

		public static IEnumerable<SteeringBehaviourAgent> GetNeighbors(Vector3 position, float neighborRadius)
		{
			float neighborDiameter = neighborRadius + neighborRadius;

			return SpatialPartionning.GetElementsInRadiusEnumerator(position, neighborDiameter);
		}
	}
}
