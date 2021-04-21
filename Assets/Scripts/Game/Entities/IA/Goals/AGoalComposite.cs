namespace Tartaros.Entities
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public abstract class AGoalComposite : AGoalEntity
	{
		List<AGoalEntity> _subGoal = new List<AGoalEntity>();

		protected AGoalComposite(Entity goalOwner) : base(goalOwner)
		{

		}

		public void AddSubGoal(AGoalEntity goal)
		{
			_subGoal.Add(goal);
		}

		public void ProcessSubGoal()
		{

			if (_subGoal.Count >= 1)
			{
				AGoalEntity currentSubGoal = _subGoal[_subGoal.Count - 1];


				if(currentSubGoal.IsCompleted() == true)
				{
					_subGoal.RemoveAt(_subGoal.Count - 1);
					return;
				}

				currentSubGoal.OnUpdate();
			}
		}

		public override void OnUpdate()
		{
			ProcessSubGoal();
		}
	}
}