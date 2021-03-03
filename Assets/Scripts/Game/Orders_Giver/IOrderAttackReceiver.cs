namespace Tartaros.OrderGiver
{
    using Tartaros.Entities;

    public interface IOrderAttackReceiver
    {
        void Attack(IAttackable target);
        void AttackAdditive(IAttackable target);
    }
}