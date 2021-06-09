namespace Tartaros.Entities.ResourcesGeneration
{
	using System.Collections;
	using Tartaros.Economy;
	using Tartaros.Map;
	using Tartaros.ServicesLocator;
	using UnityEngine;

	[DisallowMultipleComponent]
	public class EntityResourcesGeneration : AEntityBehaviour
	{
		#region Fields
		private EntityResourcesGenerationData _data = null;
		private FlagResourceToSector _flagResourceToSector = null;

		// SERVICES
		private IPlayerSectorResources _playerResources = null;
		#endregion Fields

		#region Properties
		public EntityResourcesGenerationData Data
		{
			get => _data;

			set
			{
				_data = value;
			}
		}
		#endregion Properties

		#region Methods
		private void Awake()
		{
			_playerResources = Services.Instance.Get<IPlayerSectorResources>();

			_data = Entity.GetBehaviourData<EntityResourcesGenerationData>();
			_flagResourceToSector = GetComponent<SectorObject>().GetSectorOnPosition().FindObjectsInSectorOfType<FlagResourceToSector>()[0];

			// TODO TF: Log warning if entity.Team is Enemy: The enemy will generate resource for the player
		}

		private void Start()
		{
			StartCoroutine(GenerationCoroutine());
		}

		private IEnumerator GenerationCoroutine()
		{
			while (true)
			{
				yield return new WaitForSeconds(_data.TickIntervalInSeconds);

				int availableResources = Mathf.Min(_data.ResourcesPerTick, _flagResourceToSector.AvailableResources);

				_flagResourceToSector.AvailableResources -= availableResources;
				_playerResources.AddAmount(_data.ResourcesType, availableResources);
			}
		}
		#endregion Methods
	}
}
