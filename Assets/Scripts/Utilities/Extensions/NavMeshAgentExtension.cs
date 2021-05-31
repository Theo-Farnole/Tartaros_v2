namespace Tartaros
{
	using DG.Tweening;
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

		public static DG.Tweening.Core.TweenerCore<float, float, DG.Tweening.Plugins.Options.FloatOptions> DORadius(this NavMeshAgent agent, float radius, float duration)
		{
			return DOTween.To(
				() => agent.radius,
				x => agent.radius = x,
				radius,
				duration);
		}
	}

}