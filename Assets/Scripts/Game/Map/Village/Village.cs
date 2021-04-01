namespace Tartaros.Sectors.Village
{
    using System.Collections;
    using UnityEngine;
    using Tartaros.Sectors;
    using Tartaros.ServicesLocator;
    using Tartaros.Population;
    using Tartaros.Entities;

    public class Village : Entity
    {
        [SerializeField]
        private VillageData _data = null;

        private int _populationToAugmant = 10;
        private IMap _map = null;
        private ISector _sector = null;
        private IPopulationManager _popManager = null;
        //TODO DJ: Add spawn option when captured

        private void Start()
        {
            _map = Services.Instance.Get<IMap>();
            _popManager = Services.Instance.Get<IPopulationManager>();

            _populationToAugmant = _data.PopulationAmount;
            _sector = _map.GetSectorOnPosition(transform.position);

            _sector.Captured -= OnCaptureSector;
            _sector.Captured += OnCaptureSector;
        }

        private void OnEnable()
        {
            if (_sector != null)
            {
                _sector.Captured -= OnCaptureSector;
                _sector.Captured += OnCaptureSector;
            }
        }

        private void OnDisable()
        {
            _sector.Captured -= OnCaptureSector;
        }

        private void OnCaptureSector(object sender, CapturedArgs e)
        {
            _popManager.IncrementMaxPopulation(_populationToAugmant);
        }
    }
}