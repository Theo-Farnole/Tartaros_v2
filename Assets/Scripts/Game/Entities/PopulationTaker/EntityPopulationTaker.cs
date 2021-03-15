namespace Tartaros.Entities
{
    using System.Collections;
    using Tartaros.Population;
    using Tartaros.ServicesLocator;
    using UnityEngine;
    public class EntityPopulationTaker : MonoBehaviour
    {

        private EntityPopulationTakerData _entityPopulatioNtakerData = null;
        private IPopulationManager _populationManger = null;
        private int _populationToIncrease = 0;

        private void OnEnable()
        {
            if (Services.HasInstance)
            {
                if (Services.Instance.TryGet<IPopulationManager>(out IPopulationManager populationManger))
                {
                    _populationManger = populationManger;
                }
            }
            _populationToIncrease = _entityPopulatioNtakerData.PopulationTakingCount;
            IncrementCurrentPoplation();
        }

        private void OnDisable()
        {
            DecrementCurrentPopulation();
        }

        public void IncrementCurrentPoplation()
        {
            if (_populationManger.CanSpawn(_populationToIncrease))
                _populationManger.AddCurrentPopulation(_populationToIncrease);
            else
                Debug.LogError("You can't create more units");

            throw new System.NotImplementedException();
        }

        public void DecrementCurrentPopulation()
        {
            _populationManger.RemoveCurrentPopulation(_populationToIncrease);
            throw new System.NotImplementedException();
        }
    }
}