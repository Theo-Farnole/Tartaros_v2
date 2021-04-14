namespace Tartaros.Gamemode
{
	using Tartaros.Gamemode.State;
	

	public abstract class AGameState : AState<GamemodeManager>
	{
		public AGameState(GamemodeManager stateOwner) : base(stateOwner)
		{

		}

		public override void OnStateEnter()
		{
			base.OnStateEnter();
		}

		public override void OnStateExit()
		{
			base.OnStateExit();
		}

		public override void OnUpdate()
		{

		}

		protected void LeaveState()
		{
			_stateOwner.SetState(new PlayState(_stateOwner));
		}
	}

}