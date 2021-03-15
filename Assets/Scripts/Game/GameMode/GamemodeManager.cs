namespace Tartaros.Gamemode
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Tartaros.Gamemode;
    using Tartaros.ServicesLocator;

    public class GamemodeManager : MonoBehaviour
    {
        private GamemodeFSM _gamemodeFSM;
       

        private void Awake()
        {
            Services.Instance.RegisterService<GamemodeManager>(this);
        }

        private void OnEnable()
        {
            _gamemodeFSM = new GamemodeFSM();
        }
        public void SetState(AGameState _state)
        {
            _gamemodeFSM.CurrentState = _state;
        }

        private void Update()
        {
            _gamemodeFSM.OnUpdate();
        }
    }
}