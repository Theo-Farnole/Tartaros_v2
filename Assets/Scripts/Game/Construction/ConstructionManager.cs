namespace Tartaros.Construction
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Tartaros.Construction;
    using Tartaros.Economy;
    using Tartaros.Gamemode.State;
    using Tartaros.Gamemode;
    

    public class ConstructionManager : MonoBehaviour
    {
        #region Fields
        private readonly ConstructionManagerData _contstructionManagerData = null;
        private GamemodeManager _gamemodeManager = null;
        #endregion

        private bool CanEnterConstruction(Price constructionPrice)
        {
            throw new System.NotImplementedException();
        }

        public void EnterConstructionMode(IConstructable toBuild, Price constructionPrice)
        {
            throw new System.NotImplementedException();
        }

        public void ExitConstructionMode()
        {
            _gamemodeManager.SetState(new PlayState(_gamemodeManager));
            throw new System.NotImplementedException();
        }

        public void ExitConstructionModeWithoutConstruct()
        {
            _gamemodeManager.SetState(new PlayState(_gamemodeManager));
            throw new System.NotImplementedException();
        }

        public void ConstructBuilding()
        {
            throw new System.NotImplementedException();
        }

        bool CanConstructBuilding()
        {
            throw new System.NotImplementedException();
        }

        public void Refund()
        {
            throw new System.NotImplementedException();
        }
    }

}