namespace Tartaros.Entities
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public abstract class AGoalEntity : AGoal<Entity>
	{
		protected AGoalEntity(Entity goalOwner) : base(goalOwner)
		{

		}

		public override bool IsCompleted()
		{
			throw new System.NotImplementedException();
		}

		public override void OnEnter()
		{
			base.OnEnter();
		}

		public override void OnExit()
		{
			base.OnExit();
		}

		public override void OnUpdate()
		{
			throw new System.NotImplementedException();
		}
	}
}
