namespace Tartaros.Entities
{
	using System.Collections;
	using System.ComponentModel;
	using Tartaros.Entities.Detection;
	using Tartaros.Entities.Health;
	using UnityEngine;

	public class MoveToTempleAndAttackNearest : AGoalComposite
	{
		private Vector3 _templePosition = Vector3.zero;
		private EntityDetection _entityDetection = null;
		private EntityHealth _entityHealth = null;

		public MoveToTempleAndAttackNearest(Entity goalOwner, Vector3 templePosition) : base(goalOwner)
		{
			_templePosition = templePosition;
			_entityDetection = goalOwner.GetComponent<EntityDetection>();
			_entityHealth = goalOwner.GetComponent<EntityHealth>();
		}

		public override void OnEnter()
		{
			base.OnEnter();

			base.AddSubGoal(new MoveToDestination(_goalOwner, _templePosition));

			_entityHealth.DamageTaken -= GetDamage;
			_entityHealth.DamageTaken += GetDamage;
		}

		private void GetDamage(object sender, EntityHealth.DamageTakenArgs e)
		{
			Debug.Log("OnDmg");
			bool isDestroyAlreadyEnable = GetSubGoals().Count > 1;

			if (isDestroyAlreadyEnable == false && e.attacker != null)
			{
				AddDestroySubGoal(e.attacker);
			}
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

			//Debug.Log(GetSubGoals().Peek());

			if (_entityDetection.IsNearestOpponentInDetectionRange() == true && isDestroyAlreadyEnable == false)
			{
				Entity[] targets = _entityDetection.GetEveryOpponentInRange();

				foreach (Entity target in targets)
				{
					if (target.EntityType == EntityType.Unit)
					{
						AddOnSubGoal(target);
						return;
					}
				}

				foreach (var target in targets)
				{
					if (target.EntityType == EntityType.Building)
					{
						AddOnSubGoal(target);
						return;
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
			base.AddSubGoal(new DestroyTarget(_goalOwner, target, 5));
		}

		private bool IsDetectionIsPriority()
		{
			return true;

			throw new System.NotImplementedException();
		}
	}
}