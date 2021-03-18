namespace Tartaros.Construction
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Tartaros.Construction;
    using Tartaros.Economy;

    public class ConstructionManagerData : ScriptableObject
    {
        private Dictionary<IConstructable, ISectorResourcesWallet> _buildingsPrice = null;

        public ConstructionManagerData(Dictionary<IConstructable, ISectorResourcesWallet> buildingsPrice)
        {
            _buildingsPrice = buildingsPrice;
        }

        public Dictionary<IConstructable, ISectorResourcesWallet> BuildingPrice => _buildingsPrice;
    }

}