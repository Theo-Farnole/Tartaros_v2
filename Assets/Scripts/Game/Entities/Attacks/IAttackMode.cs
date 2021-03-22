using UnityEngine;

namespace Tartaros.Entities.Attack
{
    public interface IAttackMode
    {
        void Attack(Transform attacker, IAttackable target);
    }
}