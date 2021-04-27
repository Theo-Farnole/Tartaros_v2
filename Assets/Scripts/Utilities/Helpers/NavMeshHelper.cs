namespace Tartaros
{
	using System.Linq;
	using UnityEngine;
	using UnityEngine.AI;

	public static class NavMeshHelper
	{
		public static Vector3 AdjustPositionToFitNavMesh(Vector3 position)
		{
			bool positionFound = NavMesh.SamplePosition(position, out NavMeshHit hit, 500, NavMesh.AllAreas);

			if (positionFound == false)
			{
				Debug.LogWarning("No valid position found !");
			}

			return positionFound ? hit.position : position;
		}

		public static bool IsNavPathComplete(NavMeshAgent navAgent, Vector3 point)
		{
			point = AdjustPositionToFitNavMesh(point);

			var navMeshPath = new NavMeshPath();

			navAgent.CalculatePath(point, navMeshPath);

			if (navMeshPath.status == NavMeshPathStatus.PathComplete || navMeshPath.status == NavMeshPathStatus.PathPartial)
			{
				return true;
			}
			else
			{
				Debug.LogErrorFormat("Cannot move to point {0}.", navMeshPath.status);

				return false;
			}
		}

		public static bool IsNavPathComplete(Vector3 sourcePosition, Vector3 targetPosition)
		{
			Vector3 point = AdjustPositionToFitNavMesh(targetPosition);

			var navMeshPath = new NavMeshPath();

			NavMesh.CalculatePath(sourcePosition, point, NavMesh.AllAreas,navMeshPath);

			if (navMeshPath.status == NavMeshPathStatus.PathComplete)
			{
				return true;
			}
			else
			{
				Debug.LogErrorFormat("Cannot move to point {0}.", navMeshPath.status);

				return false;
			}
		}

		public static NavMeshPathStatus GetNavPathStatus(Vector3 startPosition, Vector3 targetPosition)
		{
			Vector3 point = AdjustPositionToFitNavMesh(targetPosition);

			var navMeshPath = new NavMeshPath();

			NavMesh.CalculatePath(startPosition, point, NavMesh.AllAreas, navMeshPath);

			return navMeshPath.status;
		}

		public static Vector3 LastPositionOnPartialNavMesh(Vector3 startPosition, Vector3 targetPosition)
		{
			Vector3 point = AdjustPositionToFitNavMesh(targetPosition);

			var navMeshPath = new NavMeshPath();

			NavMesh.CalculatePath(startPosition, point, NavMesh.AllAreas, navMeshPath);

			return navMeshPath.corners[navMeshPath.corners.Length - 1];
		}

		public static bool IsPositionOnNavMesh(Vector3 position)
		{
			bool positionFound = NavMesh.SamplePosition(position, out NavMeshHit hit, 0.1f, NavMesh.AllAreas);

			return positionFound;
		}
	}
}
