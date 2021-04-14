namespace Tartaros.Entities
{
	using Tartaros.Population;
	using Tartaros.ServicesLocator;
	using UnityEngine;

	public class EntityPlayerPopulationTaker : MonoBehaviour
	{

		#region Fields
		private EntityPopulationTakerData _entityPopulationTakerData = null;

		private IPopulationManager _populationManager = null;
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
			_populationManager = Services.Instance.Get<IPopulationManager>();
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
				_populationManager.AddCurrentPopulation(PopulationToIncrease);
			}
		}

		public void DecrementCurrentPopulation()
		{
			if (_entityPopulationTakerData != null && _entity.Team == Team.Player)
			{
				_populationManager.RemoveCurrentPopulation(PopulationToIncrease);
			}
		}
		#endregion Methods
	}
}