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
		private int _resourcesPerTick = 1;
		#endregion Fields

		#region Properties
		public SectorRessourceType ResourcesType => _resourceToGenerate;
		public int ResourcesPerTick => _resourcesPerTick;
		#endregion Properties

		#region Ctor
		public EntityResourcesGenerationData(SectorRessourceType resourceToGenerate, int amountResourcesToGeneratePerTick)
		{
			_resourceToGenerate = resourceToGenerate;
			_resourcesPerTick = amountResourcesToGeneratePerTick;
		}
		#endregion Ctor

		#region Methods
#if UNITY_EDITOR
		void IEntityBehaviourData.SpawnRequiredComponents(GameObject entityRoot)
		{
			entityRoot.GetOrAddComponent<EntityResourcesGeneration>();
		} 
#endif
		#endregion Methods
	}
}