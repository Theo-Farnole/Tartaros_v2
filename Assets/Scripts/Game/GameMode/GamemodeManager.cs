namespace Tartaros.Gamemode
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Tartaros.Gamemode;

    public class GamemodeManager : MonoBehaviour
    {
        private readonly GamemodeFSM _gamemodeFSM;

        void SetState(AGameState _state)
        {
            _gamemodeFSM.SetState(_state);
        }
    }
}