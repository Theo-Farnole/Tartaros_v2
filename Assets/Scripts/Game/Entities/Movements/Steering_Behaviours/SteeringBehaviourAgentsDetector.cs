namespace Tartaros.Entities.Movement
{
	using System.Linq;
	using Tartaros.Utilities.SpatialPartioning;
	using UnityEditor.UI;
	using UnityEngine;

	public static class SteeringBehaviourAgentsDetector
	{
		private const float CELL_SIZE = 1;

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

		public static void AddAgent(ISteeringBehaviourAgent agent) => SpatialPartionning.AddElement(agent);

		public static void RemoveAgent(ISteeringBehaviourAgent agent) => SpatialPartionning.RemoveElement(agent);

		public static void MoveAgent(ISteeringBehaviourAgent agent, Vector3 position) => SpatialPartionning.Move(agent, position);

		public static ISteeringBehaviourAgent[] GetAgentsInRadius(Vector3 position, float neighborRadius)
		{
			float neighborDiameter = neighborRadius + neighborRadius;

			return SpatialPartionning.GetElementsInRadius(position, neighborDiameter);
		}
	}
}
