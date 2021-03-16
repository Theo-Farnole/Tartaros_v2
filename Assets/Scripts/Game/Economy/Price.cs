namespace Tartaros.Economy
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Tartaros.Economy;

    [System.Serializable]
    public class Price
    {
        [SerializeField]
        SectorRessourceType _ressourceType;
        [SerializeField]
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