namespace Tartaros.Entities
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;

	public abstract class AGoalEntity : AGoal<Entity>
	{

		[ShowInRuntime]
#pragma warning disable IDE0051 // Supprimer les membres privés non utilisés
		private string MyType => this.GetType().Name;
#pragma warning restore IDE0051 // Supprimer les membres privés non utilisés

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
