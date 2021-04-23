namespace Tartaros.Entities
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public abstract class AGoalComposite : AGoalEntity
	{
		Stack<AGoalEntity> _subGoal = new Stack<AGoalEntity>();


		protected AGoalComposite(Entity goalOwner) : base(goalOwner)
		{

		}

		public void AddSubGoal(AGoalEntity goal)
		{
			if (_subGoal.Count > 0)
			{
				_subGoal.Peek().OnExit();
			}

			_subGoal.Push(goal);

			_subGoal.Peek().OnEnter();
		}

		public void ProcessSubGoal()
		{
			bool containsSubGoal = _subGoal.Count > 0;

			if (containsSubGoal == true)
			{
				AGoalEntity currentSubGoal = _subGoal.Peek();


				if (currentSubGoal.IsCompleted() == true)
				{
					currentSubGoal.OnExit();
					_subGoal.Pop();

					if (_subGoal.Count > 0)
					{
						var newSubGoal = _subGoal.Peek();
						newSubGoal.OnEnter();
						currentSubGoal = newSubGoal;
						Debug.Log(newSubGoal);
					}
				}

				currentSubGoal.OnUpdate();
			}
		}

		public Stack<AGoalEntity> GetSubGoals()
		{
			return _subGoal;
		}


		public override void OnUpdate()
		{
			ProcessSubGoal();

		}
	}
}