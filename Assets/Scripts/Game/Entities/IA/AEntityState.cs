namespace Tartaros.Entities
{
	

	public abstract class AEntityState : AState<Entity>
	{
		public AEntityState(Entity stateOwner) : base(stateOwner)
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
        { }
    }
}