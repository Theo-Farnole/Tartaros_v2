namespace Tartaros.Entities
{
	using System.Collections;
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


		}

		public override bool IsCompleted()
		{
			throw new System.NotImplementedException();
		}

		private void TryClearPath()
		{
			if(_entityDetection.GetNearestOpponentBuilding() != null)
			{

			}
			
		}

		private bool IsDetectionIsPriority()
		{
			throw new System.NotImplementedException();
		}
	}
}