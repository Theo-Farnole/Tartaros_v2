namespace Tartaros
{
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
	}
}
