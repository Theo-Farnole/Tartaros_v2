namespace Tartaros.OrderGiver
{
    using UnityEngine;
    public interface IOrderMoveAggresivellyReceiver
    {
        void MoveAggressively(Vector3 position);
        void MoveAggressively(Transform target);
        void MoveAggressivelyAdditive(Vector3 position);
        void MoveAggressivelyAdditive(Transform target);
    }
}