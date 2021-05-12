namespace Tartaros.Gamemode.State
{
    using System.Collections;
    using System.Collections.Generic;
	using Tartaros.Dialogue;
	using UnityEngine;

    public class DialogueState : AGameState
    {

        private DialoguesData _data = null;
        private DialogueInputs _inputs = null;
        
        public DialogueState(GamemodeManager stateOwner, DialoguesData data) : base(stateOwner)
        {
            _data = data;
            _inputs = new DialogueInputs();
        }

        

    }
}