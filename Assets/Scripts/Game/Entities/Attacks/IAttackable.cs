namespace Tartaros.Entities
{
    using UnityEngine;
    public interface IAttackable
    {
       
        void TakeDamage(int damage);

        Transform TransformAttackble { get; }

    }
}