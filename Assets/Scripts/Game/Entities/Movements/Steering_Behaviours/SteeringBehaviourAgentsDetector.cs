namespace Tartaros.Entities.Movement
{
	using System.Linq;
	using Tartaros.Utilities.SpatialPartioning;
	using UnityEngine;

	public static class SteeringBehaviourAgentsDetector
	{
		private static SpatialPartioning<ISteeringBehaviourAgent> _spatialPartionning = null;

		public static void AddAgent(ISteeringBehaviourAgent agent) => _spatialPartionning.AddElement(agent);

		public static void RemoveAgent(ISteeringBehaviourAgent agent) => _spatialPartionning.RemoveElement(agent);

		public static void MoveAgent(ISteeringBehaviourAgent agent, Vector3 position) => _spatialPartionning.Move(agent, position);

		public static ISteeringBehaviourAgent[] GetAgentsInRadius(Vector3 position, float radius) => _spatialPartionning.GetElementsInRadius(position, radius).ToArray();
	}
}
