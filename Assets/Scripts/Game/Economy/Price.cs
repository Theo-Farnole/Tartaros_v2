namespace Tartaros.Economy
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Tartaros.Economy;

    public class Price
    {
        SectorRessourceType _ressourceType;
        int _amounth;

        public Price(SectorRessourceType ressourceType, int amounth)
        {
            _ressourceType = ressourceType;
            _amounth = amounth;
        }

        public SectorRessourceType RessourceType => _ressourceType;
        public int Amount => _amounth;
    }

}