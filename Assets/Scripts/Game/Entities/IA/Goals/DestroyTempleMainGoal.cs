namespace Tartaros.Entities
{
	using System.Collections;
	using UnityEngine;

	public class DestroyTempleMainGoal : AGoalComposite
	{
		private Vector3 _templePosition = Vector3.zero;
		
		public DestroyTempleMainGoal(Entity goalOwner, Vector3 templePosition) : base(goalOwner)
		{
			_templePosition = templePosition;
		}

		public override void OnEnter()
		{
			base.OnEnter();

			base.AddSubGoal(new MoveToTempleAndAttackNearest(_goalOwner, _templePosition));
		}

		public override bool IsCompleted()
		{
			throw new System.NotImplementedException();
		}
	}
}