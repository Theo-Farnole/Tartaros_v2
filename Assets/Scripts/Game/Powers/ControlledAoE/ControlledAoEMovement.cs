namespace Tartaros.Power
{
	using UnityEngine;
	using UnityEngine.AI;

	public class ControlledAoEMovement : MonoBehaviour
	{
		private NavMeshAgent _navAgent = null;

		private void Awake()
		{
			_navAgent = GetComponent<NavMeshAgent>();
		}

		public void Move(Vector3 position)
		{
			_navAgent.SetDestination(position);
		}

		public void Move(Transform target)
		{
			// TODO DJ: shoud follow the target
			Move(target.position);
		}

		public void AdditiveMove(Vector3 position)
		{
			_navAgent.SetDestination(position);
		}

		public void AdditiveMove(Transform target)
		{
			AdditiveMove(target.position);
		}
	}

}