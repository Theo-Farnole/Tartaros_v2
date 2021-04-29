namespace Tartaros.Gamemode.State
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class PlayState : AGameState
    {
        public PlayState(GamemodeManager stateOwner) : base(stateOwner)
        {
        }

		public override void OnStateEnter()
		{
			base.OnStateEnter();

            _stateOwner.InvokeDefaultStateEnable(this);
		}
	}

}