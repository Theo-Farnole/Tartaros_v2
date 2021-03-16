namespace Tartaros.Entities.ResourcesGeneration
{
	using System.Collections;
	using Tartaros.ServicesLocator;
	using UnityEngine;
	using Tartaros.Economy;

	public class EntityResourcesGeneration : MonoBehaviour
	{
		#region Fields
		private EntityResourcesGenerationData _data = null;
		private Coroutine _resourceGeneration = null;

		private IPlayerSectorResources _playerSector = null;
		#endregion Fields

		#region Properties
		public EntityResourcesGenerationData Data { get => _data; set => _data = value; }
		#endregion Properties

		#region Methods
		private void Awake()
		{
			_playerSector = Services.Instance.Get<IPlayerSectorResources>();

			// TODO TF: Log warning if entity.Team is Enemy: The enemy will generate resource for the player
		}

		private void OnEnable()
		{
			_resourceGeneration = StartCoroutine(ResourcesGenerationCoroutine());
		}

		private void OnDisable()
		{
			StopCoroutine(_resourceGeneration);
		}

		private IEnumerator ResourcesGenerationCoroutine()
		{
			while (true)
			{
				yield return new WaitForSeconds(_data.TickDelayInSeconds);
				GenerateResources();
			}
		}

		private void GenerateResources()
		{
			_playerSector.AddAmount(_data.SectorRessourceType, _data.GeneratedResourcesPerTick);
		}
		#endregion Methods
	}
}
