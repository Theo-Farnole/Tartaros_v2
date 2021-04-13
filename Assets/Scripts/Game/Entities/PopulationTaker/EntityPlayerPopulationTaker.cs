namespace Tartaros.Entities
{
	using Tartaros.Population;
	using Tartaros.ServicesLocator;
	using UnityEngine;

	public class EntityPlayerPopulationTaker : MonoBehaviour
	{

		#region Fields
		private EntityPopulationTakerData _entityPopulationTakerData = null;

		private IPopulationManager _populationManger = null;
		private Entity _entity = null;
		#endregion Fields

		#region Properties
		public EntityPopulationTakerData EntityPopulatioNtakerData
		{
			get => _entityPopulationTakerData;

			set
			{
				DecrementCurrentPopulation();
				_entityPopulationTakerData = value;
				IncrementCurrentPopulation();
			}
		}
		public int PopulationToIncrease => _entityPopulationTakerData.PopulationTakingCount;
		#endregion Properties

		#region Methods
		private void Awake()
		{
			_entity = GetComponent<Entity>();
			_populationManger = Services.Instance.Get<IPopulationManager>();
		}

		private void Start()
		{
		}

		private void OnEnable()
		{
			IncrementCurrentPopulation();
		}

		private void OnDisable()
		{
			DecrementCurrentPopulation();
		}

		public void IncrementCurrentPopulation()
		{
			if (_entityPopulationTakerData != null && _entity.Team == Team.Player)
			{
				_populationManger.AddCurrentPopulation(PopulationToIncrease);
			}
		}

		public void DecrementCurrentPopulation()
		{
			if (_entityPopulationTakerData != null && _entity.Team == Team.Player)
			{
				_populationManger.RemoveCurrentPopulation(PopulationToIncrease);
			}
		}
		#endregion Methods
	}
}