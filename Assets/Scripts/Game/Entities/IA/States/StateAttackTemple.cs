namespace Tartaros.Entities
{
	using System.Collections;
	using UnityEngine;
	using UnityEngine.AI;

	public class StateAttackTemple : AEntityState
	{
		private Vector3 _templePosition = Vector3.zero;
		private IAttackable _templeTarget = null;
		[SerializeField]
		private AGoalComposite _goal = null;
		public StateAttackTemple(Entity stateOwner, Vector3 templePosition, IAttackable temple) : base(stateOwner)
		{
			_templePosition = templePosition;
			_templeTarget = temple;
		}

		public override void OnStateEnter()
		{
			base.OnStateEnter();



			var position = NavMeshHelper.AdjustPositionToFitNavMesh(_templePosition);

			

			_goal = new DestroyTempleMainGoal(_stateOwner, position, _templeTarget);

			_goal.OnEnter();

		}

		public override void OnUpdate()
		{
			base.OnUpdate();

			_goal.OnUpdate();
		}
	}
}