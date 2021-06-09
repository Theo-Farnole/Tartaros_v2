namespace Tartaros.Entities.ResourcesGeneration
{
	using Tartaros.Economy;
	using UnityEngine;

	public class EntityResourcesGenerationData : IEntityBehaviourData
	{
		#region Fields		
		[SerializeField]
		private SectorRessourceType _resourceToGenerate = SectorRessourceType.Food;

		[SerializeField] private int _resourcesPerTick = 1;

		[SerializeField] private int _maxRessourcesBeforeEmpty = 1000;

		[SerializeField] private float _tickIntervalInSeconds = 3;
		#endregion Fields

		#region Properties
		public SectorRessourceType ResourcesType => _resourceToGenerate;
		public int ResourcesPerTick => _resourcesPerTick;
		public int MaxRessourcesBeforeEmpty => _maxRessourcesBeforeEmpty;
		public float TickIntervalInSeconds => _tickIntervalInSeconds;
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