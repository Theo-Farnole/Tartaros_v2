namespace Tartaros.Entities
{
	using System.Collections;
	using Tartaros.Entities.Detection;
	using UnityEditor.UIElements;
	using UnityEngine;
	using UnityEngine.AI;

	public class DestroyTempleMainGoal : AGoalComposite
	{
		private Vector3 _templePosition = Vector3.zero;
		private IAttackable _templeTarget = null;
		private AGoalComposite _currentMoveToTemple = null;
		private EntityDetection _entityDetection = null;
		private DestroyTarget _destroyTempleGoal = null;
		private Vector3[] _waypoints = null;
		private bool _completed = false;
		private int _indexWaypoints = 1;
		private NavMeshPath[] _paths = null;

		public DestroyTempleMainGoal(Entity goalOwner, Vector3 templePosition, IAttackable targetTemple, Vector3[] waypoints, NavMeshPath[] paths) : base(goalOwner)
		{
			_templePosition = templePosition;
			_entityDetection = _goalOwner.GetComponent<EntityDetection>();
			_templeTarget = targetTemple;
			_waypoints = waypoints;
			_paths = paths;
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
				AddMoveToTemple();
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
			Vector3 targetPosition = GoalPosition();
			NavMeshPath path = Path();

			_currentMoveToTemple = new MoveToTempleAndAttackNearest(_goalOwner, targetPosition, path);

			base.AddSubGoal(_currentMoveToTemple);
		}

		private bool FinalDestinationIsReach()
		{
			float distance = Vector3.Distance(_goalOwner.transform.position, new Vector3(_templePosition.x, 0, _templePosition.z));

			return distance <= 12;
		}

		private void DestroyObstacle()
		{
			if (_entityDetection.GetNearestOpponentBuilding() != null)
			{
				var target = _entityDetection.GetNearestOpponentBuilding();

				AddOnSubGoal(target);
			}
		}

		private void AddOnSubGoal(Entity target)
		{
			//IAttackable targetAttackable = (target.GetComponent<IAttackable>());

			AddDestroySubGoal(_templeTarget);

		}

		private Vector3 GoalPosition()
		{
			if(_waypoints.Length >= _indexWaypoints)
			{
				Vector3 pos =  NavMeshHelper.LastPositionOnPartialNavMesh(_goalOwner.transform.position, _waypoints[_indexWaypoints - 1]);
				_indexWaypoints++;
				return pos;
			}

			return NavMeshHelper.LastPositionOnPartialNavMesh(_goalOwner.transform.position, _templePosition);
		}

		private NavMeshPath Path()
		{

			if(_paths.Length >= _indexWaypoints)
			{
				NavMeshPath path = _paths[_indexWaypoints - 1];
				_indexWaypoints++;
				return path;
			}

			NavMeshPath output = new NavMeshPath();
			NavMesh.CalculatePath(_goalOwner.transform.position, _templePosition, NavMesh.AllAreas, output);

			return output;
		}

		private void AddDestroySubGoal(IAttackable target)
		{
			_destroyTempleGoal = new DestroyTarget(_goalOwner, target, 50);
			base.AddSubGoal(_destroyTempleGoal);
		}
	}
}