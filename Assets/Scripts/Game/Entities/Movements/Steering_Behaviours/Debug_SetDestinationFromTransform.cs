namespace Tartaros.Entities.Movement
{
	using UnityEngine;

	public class Debug_SetDestinationFromTransform : MonoBehaviour
	{
		[SerializeField]
		private Transform _destination = null;

		private void Start()
		{
			var agents = GameObject.FindObjectsOfType<SteeringBehaviourAgent>();

			foreach (var agent in agents)
			{
				agent.Destination = _destination.position;
			}
		}
	}
}