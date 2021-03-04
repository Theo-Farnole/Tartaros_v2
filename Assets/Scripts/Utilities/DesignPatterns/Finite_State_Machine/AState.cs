namespace Tartaros.Utilities
{
	public abstract class AState<T>
	{
		#region Fields
		private readonly T _stateOwner = default;
		#endregion Fields

		#region Ctor
		public AState(T stateOwner)
		{
			_stateOwner = stateOwner;
		} 
		#endregion Ctor

		#region Methods
		public abstract void OnUpdate();

		public virtual void OnStateEnter() { }
		public virtual void OnStateExit() { }
		#endregion Methods
	}
}