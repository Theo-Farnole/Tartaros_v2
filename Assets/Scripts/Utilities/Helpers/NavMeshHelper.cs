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

		// source: https://forum.unity.com/threads/check-if-there-is-a-navmesh-in-the-scene.445816/
		public static bool IsThereANavMeshInScene()
		{
			return NavMesh.SamplePosition(Vector3.zero, out NavMeshHit hit, 1000.0f, NavMesh.AllAreas);
		}
	}
}
