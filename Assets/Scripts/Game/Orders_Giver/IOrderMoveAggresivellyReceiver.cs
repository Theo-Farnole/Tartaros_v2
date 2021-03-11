namespace Tartaros.OrderGiver
{
    using UnityEngine;

    public interface IOrderMoveAggresivellyReceiver
    {
        void MoveAggressively(Vector3 position);
        void MoveAggressivelyAdditive(Vector3 position);
    }
}