namespace Tartaros.Entities
{
	using System.Collections;
	using UnityEngine;
	using UnityEngine.AI;

	public class StateAttackTemple : AEntityState
	{
		private Vector3 _templePosition = Vector3.zero;

		[SerializeField]
		private AGoalComposite _goal = null;
		public StateAttackTemple(Entity stateOwner, Vector3 templePosition) : base(stateOwner)
		{
			_templePosition = templePosition;
		}

		public override void OnStateEnter()
		{
			base.OnStateEnter();



			var position = NavMeshHelper.AdjustPositionToFitNavMesh(_templePosition);

			

			_goal = new DestroyTempleMainGoal(_stateOwner, position);

			_goal.OnEnter();

		}

		public override void OnUpdate()
		{
			base.OnUpdate();

			_goal.OnUpdate();
		}
	}
}