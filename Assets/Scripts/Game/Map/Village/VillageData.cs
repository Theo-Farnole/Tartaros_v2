namespace Tartaros.Map.Village
{
	using Tartaros.Entities;
	using UnityEngine;

	// TODO TF: turn into ScriptableObject
	[System.Serializable]
	public class VillageData
	{
		[SerializeField] private int _populationIncreaseAmount = 0;

		public int PopulationAmount => _populationIncreaseAmount;
	}
}