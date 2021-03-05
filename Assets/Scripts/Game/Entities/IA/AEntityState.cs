namespace Tartaros.Entities
{
	using Tartaros.Utilities;

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
        {
            throw new System.NotImplementedException();
        }
    }
}