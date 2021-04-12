namespace Tartaros.Map.Village
{
	using Tartaros.Entities;
	using Tartaros.Population;
	using Tartaros.Map;
	using Tartaros.ServicesLocator;
	using UnityEngine;

	public class Village : MonoBehaviour
	{
		#region Fields
		[SerializeField]
		private VillageData _data = null;

		private IMap _map = null;
		private ISector _sector = null;
		private IPopulationManager _populationManager = null;
		#endregion Fields

		#region Properties
		private int PopulationToIncrease => _data.PopulationAmount;
		public VillageData Data { get => _data; set => _data = value; }
		#endregion Properties

		#region Methods		
		private void Start()
		{
			_map = Services.Instance.Get<IMap>();
			_populationManager = Services.Instance.Get<IPopulationManager>();

			_sector = _map.GetSectorOnPosition(transform.position);

			_sector.Captured -= OnCaptureSector;
			_sector.Captured += OnCaptureSector;

			UpdateAbilityToSpawnUnits();
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
			_populationManager.IncrementMaxPopulation(PopulationToIncrease);
			UpdateAbilityToSpawnUnits();
		}

		private void UpdateAbilityToSpawnUnits()
		{
			if (TryGetComponent(out EntityUnitsSpawner entityUnitsSpawner))
			{
				entityUnitsSpawner.enabled = _sector.IsCaptured;
			}
			else
			{
				Debug.LogErrorFormat("Missing entity spawner on village {0}. The village will not be able to spawn units.");
			}
		}
		#endregion Methods
	}
}