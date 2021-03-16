namespace Tartaros.Entities.ResourcesGeneration
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using Tartaros.Economy;

	public class EntityResourcesGenerationData : IEntityBehaviourData
	{
		#region Fields		
		[SerializeField]
		private SectorRessourceType _resourceToGenerate = SectorRessourceType.Food;

		[SerializeField]
		private int _amountResourcesToGeneratePerTick = 1;

		[SerializeField]
		private float _tickDelayInSeconds = 10;
		#endregion Fields

		#region Properties
		public SectorRessourceType SectorRessourceType => _resourceToGenerate;
		public int GeneratedResourcesPerTick => _amountResourcesToGeneratePerTick;
		public float TickDelayInSeconds => _tickDelayInSeconds;
		#endregion Properties

		#region Ctor
		public EntityResourcesGenerationData(SectorRessourceType resourceToGenerate, int amountResourcesToGeneratePerTick, float tickDelayInSeconds)
		{
			_resourceToGenerate = resourceToGenerate;
			_amountResourcesToGeneratePerTick = amountResourcesToGeneratePerTick;
			_tickDelayInSeconds = tickDelayInSeconds;
		}
		#endregion Ctor

		#region Methods
		void IEntityBehaviourData.SpawnRequiredComponents(GameObject entityRoot)
		{
			entityRoot.AddComponent<EntityResourcesGeneration>().Data = this;
		}
		#endregion Methods
	}
}