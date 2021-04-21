namespace Tartaros.Entities.Movement
{
	using UnityEngine;

	public class DebugDrawSteeringBehaviourSpatialPartioning : MonoBehaviour
	{
		private void Update()
		{
			if (Application.isPlaying == true)
			{
				SteeringBehaviourAgentsDetector.DebugDrawGrid(Color.red);
			}
		}
	}
}
