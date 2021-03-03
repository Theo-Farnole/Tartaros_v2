namespace Tartaros.OrderGiver
{
    using UnityEngine;
    public interface IOrderPatrolReceiver
    {
        void Patrol(Vector3[] waypoints);
        void PatrolAdditive(Vector3[] waypoints);
    }
}