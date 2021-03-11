namespace Tartaros.Construction
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Tartaros.Construction;
    using Tartaros.Economy;

    public class ConstructionManagerData : ScriptableObject
    {
        private Dictionary<IConstructable, Price> _buildingsPrice;

        public ConstructionManagerData(Dictionary<IConstructable, Price> buildingsPrice)
        {
            _buildingsPrice = buildingsPrice;
        }

        public Dictionary<IConstructable, Price> BuildingPrice => _buildingsPrice;
    }

}