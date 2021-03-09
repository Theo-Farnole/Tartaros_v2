namespace Tartaros.Gamemode
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Tartaros.Utilities;

    public class GamemodeFSM : GenericFSM<GamemodeManager>
    {
        private GenericFSM<GamemodeManager> _finiteStateMachine = new GenericFSM<GamemodeManager>();

        #region Methods		
        private void Update()
        {
            if (_finiteStateMachine != null)
            {
                _finiteStateMachine.OnUpdate();
            }
        }

        public void SetState(AGameState newState)
        {
            _finiteStateMachine.CurrentState = newState;
        }
        #endregion Methods
    }
}
}