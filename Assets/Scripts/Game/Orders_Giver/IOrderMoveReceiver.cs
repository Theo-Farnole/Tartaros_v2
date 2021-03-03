namespace Tartaros.OrderGiver
{
    using UnityEngine;
    public interface IOrderMoveReceiver
    {
        void Move(Vector3 position);
        void Move(Transform target);
        void MoveAdditive(Vector3 position);
        void MoveAdditive(Transform target);
    }
}