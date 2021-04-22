namespace Tartaros.Entities
{
	using System.Collections;
	using System.ComponentModel;
	using Tartaros.Entities.Detection;
	using UnityEngine;

	public class MoveToTempleAndAttackNearest : AGoalComposite
	{
		private Vector3 _templePosition = Vector3.zero;
		private EntityDetection _entityDetection = null;

		public MoveToTempleAndAttackNearest(Entity goalOwner, Vector3 templePosition) : base(goalOwner)
		{
			_templePosition = templePosition;

			_entityDetection = goalOwner.GetComponent<EntityDetection>();
		}

		public override void OnEnter()
		{
			base.OnEnter();

			base.AddSubGoal(new MoveToDestination(_goalOwner, _templePosition));
		}

		public override void OnUpdate()
		{
			base.OnUpdate();

			TryClearPath();
		}

		public override bool IsCompleted()
		{
			return GetSubGoals().Count == 0;
		}

		private void TryClearPath()
		{
			bool isDestroyAlreadyEnable = GetSubGoals().Count > 1;
			
			if(_entityDetection.IsNearestOpponentInDetectionRange() == true && isDestroyAlreadyEnable == false)
			{
				Entity[] targets = _entityDetection.GetEveryOpponentInRange();

				foreach (Entity target in targets)
				{
					if(target.EntityType == EntityType.Unit)
					{
						AddOnSubGoal(target);
					}
					else if (target.EntityType == EntityType.Building)
					{
						AddOnSubGoal(target);
					}
				}
			}
		}

		private void AddOnSubGoal(Entity target)
		{
			IAttackable targetAttackable = (target.GetComponent<IAttackable>());

			if (IsDetectionIsPriority() == true)
			{
				AddDestroySubGoal(targetAttackable);
			}
		}

		private void AddDestroySubGoal(IAttackable target)
		{
			base.AddSubGoal(new DestroyTargetGoal(_goalOwner, target, 5));
		}

		private bool IsDetectionIsPriority()
		{
			return true;

			throw new System.NotImplementedException();
		}
	}
}