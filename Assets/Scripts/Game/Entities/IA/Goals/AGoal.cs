namespace Tartaros.Entities
{
	using System.Collections;
	using UnityEngine;

	public abstract class AGoal<T>
	{
		#region Fields
		public readonly T _goalOwner = default;
		#endregion Fields

		#region Ctor
		public AGoal(T goalOwner)
		{
			_goalOwner = goalOwner;
		}
		#endregion Ctor

		public abstract void OnUpdate();
		public abstract bool IsCompleted();
		public virtual void OnEnter() { }
		public virtual void OnExit() { }
	}
}