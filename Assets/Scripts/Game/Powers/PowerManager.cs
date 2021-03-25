namespace Tartaros.Power
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Tartaros.Gamemode;
    using Tartaros.ServicesLocator;
    using Tartaros.Gamemode.State;

    public class PowerManager : MonoBehaviour
    {
        private GamemodeManager _gameModeManager = null; 
        private GameObject _lightningBoltPrefab = null;
        private GameObject _controlledAoEPrefab = null;


        private void Awake()
        {
            Services.Instance.RegisterService(this);
            _gameModeManager = Services.Instance.Get<GamemodeManager>();
        }

        public bool CanCastSpell(IPower power)
        {
            return true;
            //throw new System.NotImplementedException();
        }


        public void EnterPowerState(IPower power)
        {
            _gameModeManager.SetState(new PowerState(_gameModeManager, power));
            Debug.Log(power);
        }
    }
}