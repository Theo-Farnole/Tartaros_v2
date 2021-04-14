namespace Tartaros.Entities
{
	using Tartaros.Population;
	using Tartaros.ServicesLocator;
	using UnityEngine;

	public class EntityPlayerPopulationTaker : AEntityBehaviour
	{
		#region Fields
		private EntityPopulationTakerData _entityPopulationTakerData = null;

		private IPopulationManager _populationManager = null;
		#endregion Fields

		#region Properties
		public int PopulationToIncrease => _entityPopulationTakerData.PopulationTakingCount;
		#endregion Properties

		#region Methods
		private void Awake()
		{
			_populationManager = Services.Instance.Get<IPopulationManager>();

			_entityPopulationTakerData = new EntityPopulationTakerData(Entity.EntityData.Population);
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
			if (_entityPopulationTakerData != null && Entity.Team == Team.Player)
			{
				_populationManager.AddCurrentPopulation(PopulationToIncrease);
			}
		}

		public void DecrementCurrentPopulation()
		{
			if (_entityPopulationTakerData != null && Entity.Team == Team.Player)
			{
				_populationManager.RemoveCurrentPopulation(PopulationToIncrease);
			}
		}
		#endregion Methods
	}
}