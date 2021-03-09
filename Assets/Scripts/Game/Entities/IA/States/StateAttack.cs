namespace Tartaros.Entities.State
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Tartaros.Utilities;
    using Tartaros.Entities;

    public class StateAttack : AEntityState
    {
        private readonly IAttackable _target = null;
        private readonly EntityAttack _entityAttack = null;

        public StateAttack(Entity stateOwner, IAttackable target) : base(stateOwner)
        {
            _target = target;
        }

        public override void OnStateEnter()
        {
            base.OnStateEnter();

            _entityAttack.DoDamage(_target);
            //if (_target is IAttackable attackable)
        }

        public override void OnUpdate()
        {
            throw new System.NotImplementedException();
        }
    }
}