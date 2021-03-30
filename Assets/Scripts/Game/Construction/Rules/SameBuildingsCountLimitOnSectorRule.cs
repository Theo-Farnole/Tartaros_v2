namespace Tartaros.Construction
{
	using System.Linq;
	using Tartaros.Entities;
	using Tartaros.Sectors;
	using Tartaros.ServicesLocator;
	using UnityEngine;

	public class SameBuildingsCountLimitOnSectorRule : IConstructionRule
	{
		#region Fields
		private const string DBG_ERR_NO_SECTOR_FOUND = "No sector found at position {0}. Return true by default.";

		[SerializeField]
		private EntityData _buildingToCheck = null;

		[SerializeField]
		private int _buildingMaxCount = 1;
		#endregion Fields

		#region Properties
		string IConstructionRule.ErrorMessage => "You reach the limit of this building on this sector.";
		#endregion Properties

		#region Methods
		bool IConstructionRule.CanConstruct(Vector3 position)
		{
			IMap map = Services.Instance.Get<IMap>();
			ISector sectorOnPosition = map.GetSectorOnPosition(position);

			if (sectorOnPosition != null)
			{
				int buildingsCount = GetBuildingsCount(sectorOnPosition);
				return buildingsCount < _buildingMaxCount;
			}
			else
			{
				Debug.LogErrorFormat(DBG_ERR_NO_SECTOR_FOUND, position);
				return true;
			}
		}

		int GetBuildingsCount(ISector sector)
		{
			return sector.GetEntityCount(_buildingToCheck);
		}
		#endregion Methods
	}
}
