namespace Tartaros.Entities.ResourcesGeneration
{
	using Tartaros.Economy;
	using Tartaros.ServicesLocator;
	using UnityEngine;

	[DisallowMultipleComponent]
	public class EntityResourcesGeneration : AEntityBehaviour, IIncomeGenerator
	{
		#region Fields
		private EntityResourcesGenerationData _data = null;
		private IPlayerIncomeManager _incomeManager = null;
		#endregion Fields

		#region Properties
		public EntityResourcesGenerationData Data
		{
			get => _data;

			set
			{
				_data = value;
				_incomeManager.AddGeneratorIncome(this);
			}
		}

		SectorRessourceType IIncomeGenerator.SectorRessourceType => _data.ResourcesType;

		int IIncomeGenerator.ResourcesPerTick => _data.ResourcesPerTick;

		int IIncomeGenerator.MaxRessourcesBeforeEmpty => _data.MaxRessourcesBeforeEmpty;
		#endregion Properties

		#region Methods
		private void Awake()
		{
			_incomeManager = Services.Instance.Get<IPlayerIncomeManager>();

			_data = Entity.GetBehaviourData<EntityResourcesGenerationData>();
			// TODO TF: Log warning if entity.Team is Enemy: The enemy will generate resource for the player
		}

		private void OnEnable()
		{
			if (_data != null)
			{
				_incomeManager.AddGeneratorIncome(this);
			}
		}


		private void OnDisable()
		{
			_incomeManager.RemoveGeneratorIncome(this);
		}

		void IIncomeGenerator.RessourcesIsEmpty()
		{
			Debug.LogFormat("ressource is {0} empty", this.gameObject);
		}
		#endregion Methods
	}
}
