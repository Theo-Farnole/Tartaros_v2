namespace Tartaros.OrderGiver
{
    using UnityEngine;

    public interface IOrderMoveReceiver
    {
        void Move(Vector3 position);
        void Follow(Transform toFollow);
        void EnqueueMove(Vector3 position);
        void EnqueueFollow(Transform toFollow);
    }
}