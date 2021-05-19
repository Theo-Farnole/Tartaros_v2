namespace Tartaros.Power
{
	using UnityEngine;
	using UnityEngine.AI;

	public class ControlledAoEMovement : MonoBehaviour
	{
		private NavMeshAgent _navAgent = null;
		private Vector3 _destination = Vector3.zero;
		private float _movementSpeed = 4;

		private void Awake()
		{
			_navAgent = GetComponent<NavMeshAgent>();
		}

		private void Update()
		{
			if(_destination != Vector3.zero)
			{
				MoveToTarget();
				Debug.Log(_destination);

				if(IsDestinationReach() == true)
				{
					_destination = Vector3.zero;
				}
			}
		}

		private void MoveToTarget()
		{
			transform.position += -(transform.position - _destination).normalized * _movementSpeed * Time.deltaTime;
			Debug.DrawLine(transform.position, _destination, Color.red);
		}

		private bool IsDestinationReach()
		{
			var distanceFromTarget = Vector3.Distance(transform.position, _destination);

			return distanceFromTarget <= 1;
		}

		public void Move(Vector3 position)
		{
			//_navAgent.SetDestination(position);
			_destination = new Vector3(position.x, transform.position.y, position.z);
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