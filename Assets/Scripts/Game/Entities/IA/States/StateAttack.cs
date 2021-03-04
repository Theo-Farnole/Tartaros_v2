namespace Tartaros.Entities.State
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Tartaros.Utilities;
    using Tartaros.Entities;

    public class StateAttack : AEntityState
    {
        private readonly Entity _target = null;

        public StateAttack(Entity stateOwner, Entity target) : base(stateOwner)
        {
            _target = target;
        }

        public override void OnUpdate()
        {
            throw new System.NotImplementedException();
        }
    }
}