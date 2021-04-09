namespace Tartaros
{
	using UnityEngine.AI;

	public static class NavMeshAgentExtension
	{
		public static bool HasReachedDestination(this NavMeshAgent navMeshAgent)
		{
			if (!navMeshAgent.pathPending)
			{
				if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
				{
					if (!navMeshAgent.hasPath || navMeshAgent.velocity.sqrMagnitude == 0f)
					{
						return true;
					}
				}
			}

			return false;
		}
	}

}