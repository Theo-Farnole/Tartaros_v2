namespace Tartaros.Entities
{
	using UnityEngine;


	public class EntityPopulationTakerData
	{
		#region Fields
		[SerializeField]
		private int _populationTakingCount = 1;
		#endregion Fields

		#region Properties
		public int PopulationTakingCount => _populationTakingCount;
		#endregion Properties

		#region Ctor
		public EntityPopulationTakerData(int populationTakingCount)
		{
			_populationTakingCount = populationTakingCount;
		}
		#endregion Ctor
	}
}