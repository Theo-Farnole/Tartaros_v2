namespace Tartaros.OrderGiver
{
	using Tartaros.Entities.Movement;

	public interface IOrderPatrolReceiver
	{
		void Patrol(PatrolPoints waypoints);
		void PatrolAdditive(PatrolPoints waypoints);
	}
}