namespace Tartaros.Entities
{
	using System.Collections;
	using UnityEngine;

	public class ClearPath : AGoalComposite
	{
		private Vector3 _obstaclePosition = Vector3.zero;

		public ClearPath(Entity goalOwner) : base(goalOwner)
		{

		}

		public override bool IsCompleted()
		{
			return base.IsCompleted();
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
		}
	}
}