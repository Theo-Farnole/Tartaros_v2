namespace Tartaros.Entities
{
	using Tartaros.Utilities;

	public abstract class AEntityState : AState<Entity>
	{
		public AEntityState(Entity stateOwner) : base(stateOwner)
		{

		}
	}
}