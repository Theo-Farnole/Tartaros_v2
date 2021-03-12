namespace Tartaros.Gamemode
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Tartaros.Gamemode;

    public class GamemodeManager : MonoBehaviour
    {
        private GamemodeFSM _gamemodeFSM;


        private void OnEnable()
        {
            _gamemodeFSM = new GamemodeFSM();
        }
        public void SetState(AGameState _state)
        {
            _gamemodeFSM.SetState(_state);
        }
    }
}