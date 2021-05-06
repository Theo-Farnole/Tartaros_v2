namespace Tartaros.Entities
{
	using Tartaros.Construction;
	using Tartaros.Economy;
	using UnityEngine;

	public class BuildingsDatabase : MonoBehaviour
	{
		[SerializeField] private BuildingsDatabaseData _data = null;

		public EntityData GetResourceBuilding(SectorRessourceType type) => _data.GetResourceBuilding(type);
		public IConstructable GetResourceBuildingAsConstructable(SectorRessourceType type) => _data.GetResourceBuilding(type).GetBehaviour<IConstructable>();
	}
}
