namespace Tartaros.Gamemode.State
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Tartaros.Gamemode;
    using Tartaros.Entities;

    public class ConstructionState : AGameState
    {
        private EntityData _buildingToConstruct = null;


        public ConstructionState(GamemodeManager stateOwner) : base(stateOwner)
        {
        }

        public void ConstructBuilding()
        {

        }

    }

}