namespace Tartaros.Entities
{
	using System.Collections;
	using UnityEngine;

	public class StateGoalPattern : AEntityState
	{
		private Vector3 _templePosition = Vector3.zero;
		public StateGoalPattern(Entity stateOwner, Vector3 templePosition) : base(stateOwner)
		{
			_templePosition = templePosition;
		}

		public override void OnStateEnter()
		{
			base.OnStateEnter();

			var destroyTempleGoal = new DestroyTempleMainGoal(_stateOwner, _templePosition);
		}
	}
}