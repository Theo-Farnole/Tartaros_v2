namespace Tartaros.Entities
{
	using Sirenix.OdinInspector;
	using System.Collections.Generic;
	using Tartaros.Economy;
	using UnityEngine;

	public class BuildingsDatabaseData : SerializedScriptableObject
	{
		[SerializeField] private Dictionary<SectorRessourceType, EntityData> _buildingsByType = new Dictionary<SectorRessourceType, EntityData>();

		public EntityData GetResourceBuilding(SectorRessourceType type)
		{
			return _buildingsByType[type];
		}
	}
}
