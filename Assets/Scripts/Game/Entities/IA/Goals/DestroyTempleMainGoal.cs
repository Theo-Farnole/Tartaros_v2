namespace Tartaros.Entities
{
	using System.Collections;
	using Tartaros.Entities.Detection;
	using UnityEngine;
	using UnityEngine.AI;

	public class DestroyTempleMainGoal : AGoalComposite
	{
		private Vector3 _templePosition = Vector3.zero;
		private AGoalComposite _currentMoveToTemple = null;
		private EntityDetection _entityDetection = null;
		private DestroyTarget _destroyTempleGoal = null;
		private bool _completed = false;

		public DestroyTempleMainGoal(Entity goalOwner, Vector3 templePosition) : base(goalOwner)
		{
			_templePosition = templePosition;
			_entityDetection = _goalOwner.GetComponent<EntityDetection>();
		}

		public override void OnEnter()
		{
			base.OnEnter();

			AddMoveToTemple();

		}
		public override void OnUpdate()
		{
			base.OnUpdate();

			if(_destroyTempleGoal != null && _destroyTempleGoal.IsCompleted() == true)
			{
				_completed = true;
				return;
			}
			else
			{
				if (GetSubGoals().Count != 0)
				{
					var currentSubGoal = GetSubGoals().Peek();

					if (currentSubGoal == _currentMoveToTemple)
					{
						if (currentSubGoal.IsCompleted() == true)
						{
							ReachPosition();
						}
					}
				}
				else
				{
					ReachPosition();
				}
			}
		}

		public override bool IsCompleted()
		{
			return _completed;
		}

		private void ReachPosition()
		{
			_currentMoveToTemple = null;

			if (FinalDestinationIsReach() == true)
			{
				DestroyObstacle();
			}
			else
			{
				if (IsThePathPatrial() == true)
				{
					//AddClearPath();
					AddMoveToTemple();
				}
				else
				{
					AddMoveToTemple();
				}
			}
		}

		private bool IsThePathPatrial()
		{
			if (NavMeshHelper.GetNavPathStatus(_goalOwner.transform.position, _templePosition) == NavMeshPathStatus.PathPartial)
			{
				return true;
			}
			else if (NavMeshHelper.GetNavPathStatus(_goalOwner.transform.position, _templePosition) == NavMeshPathStatus.PathComplete)
			{
				return false;
			}
			else
			{
				Debug.LogError("Path is invalide");
				return false;
			}
		}

		private void AddClearPath()
		{
			Debug.Log("ClearPathEnable");
			base.AddSubGoal(new ClearPath(_goalOwner));
		}

		private void AddMoveToTemple()
		{
			Debug.Log("MoveToTempleEnable");
			Vector3 targetPosition = GoalPosition();

			_currentMoveToTemple = new MoveToTempleAndAttackNearest(_goalOwner, targetPosition);

			base.AddSubGoal(_currentMoveToTemple);
		}

		private bool FinalDestinationIsReach()
		{
			float distance = Vector3.Distance(_goalOwner.transform.position, _templePosition);

			return distance <= 10;
		}

		private void DestroyObstacle()
		{
			if (_entityDetection.GetNearestOpponentBuilding() != null)
			{
				var target = _entityDetection.GetNearestOpponentBuilding();
				Debug.Log(target);

				AddOnSubGoal(target);
			}
		}

		private void AddOnSubGoal(Entity target)
		{
			IAttackable targetAttackable = (target.GetComponent<IAttackable>());

			AddDestroySubGoal(targetAttackable);

		}

		private Vector3 GoalPosition()
		{
			return NavMeshHelper.lastPositionOnPartialNavMesh(_goalOwner.transform.position, _templePosition);
		}

		private void AddDestroySubGoal(IAttackable target)
		{
			_destroyTempleGoal = new DestroyTarget(_goalOwner, target, 5);
			base.AddSubGoal(_destroyTempleGoal);
		}
	}
}