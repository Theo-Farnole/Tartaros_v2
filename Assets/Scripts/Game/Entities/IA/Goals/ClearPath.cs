namespace Tartaros.Entities
{
	using System.Collections;
	using Tartaros.Entities.Detection;
	using UnityEngine;

	public class ClearPath : AGoalComposite
	{
		private EntityDetection _entityDetection = null;

		public ClearPath(Entity goalOwner) : base(goalOwner)
		{
			_entityDetection = _goalOwner.GetComponent<EntityDetection>();
		}

		public override bool IsCompleted()
		{
			return GetSubGoals().Count == 0;
		}

		public override void OnEnter()
		{
			base.OnEnter();

			DestroyObstacle();
		}

		public override void OnUpdate()
		{
			base.OnUpdate();

		}

		private void DestroyObstacle()
		{
			if(_entityDetection.GetNearestOpponentBuilding() != null)
			{
				var target = _entityDetection.GetNearestOpponentBuilding();

				AddOnSubGoal(target);
			}
		}

		private void AddOnSubGoal(Entity target)
		{
			IAttackable targetAttackable = (target.GetComponent<IAttackable>());


			AddDestroySubGoal(targetAttackable);

		}

		private void AddDestroySubGoal(IAttackable target)
		{
			base.AddSubGoal(new DestroyTarget(_goalOwner, target, 5));
		}
	}
}