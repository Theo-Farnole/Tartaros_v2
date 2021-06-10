namespace Tartaros.Entities
{
	using System.Collections;
	using UnityEngine;
	using UnityEngine.AI;

	public class StateAttackTemple : AEntityState
	{
		private Vector3 _templePosition = Vector3.zero;
		private IAttackable _templeTarget = null;
		private Vector3[] _waypoints = null;
		private NavMeshPath[] _paths = null;

		[SerializeField]
		private AGoalComposite _goal = null;
		public StateAttackTemple(Entity stateOwner, Vector3 templePosition, IAttackable temple, Vector3[] waypoints, NavMeshPath[] paths) : base(stateOwner)
		{
			_templePosition = templePosition;
			_templeTarget = temple;
			_waypoints = waypoints;
			_paths = paths;
		}

		public override void OnStateEnter()
		{
			base.OnStateEnter();

			var position = NavMeshHelper.AdjustPositionToFitNavMesh(_templePosition);

			_goal = new DestroyTempleMainGoal(_stateOwner, position, _templeTarget, _waypoints, _paths);

			_goal.OnEnter();

		}

		public override void OnUpdate()
		{
			base.OnUpdate();

			_goal.OnUpdate();
		}
	}
}