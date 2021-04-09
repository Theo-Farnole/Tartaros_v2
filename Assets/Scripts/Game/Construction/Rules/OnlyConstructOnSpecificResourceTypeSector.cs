namespace Tartaros.Map
{
	using System.Linq;
	using Tartaros.Construction;
	using Tartaros.Economy;
	using Tartaros.Map;
	using Tartaros.ServicesLocator;
	using UnityEngine;

	public class OnlyConstructOnSpecificResourceTypeSector : IConstructionRule
	{
		#region Fields
		private const string DBG_ERR_NO_SECTOR_FOUND = "No sector found at position {0}. Return true by default.";

		[SerializeField]
		private SectorRessourceType _type = SectorRessourceType.Food;
		#endregion Fields

		#region Ctor
		public OnlyConstructOnSpecificResourceTypeSector(SectorRessourceType type)
		{
			_type = type;
		}

		#endregion Ctor

		#region Properties
		string IConstructionRule.ErrorMessage => "You can only construct on sector with {0} resource".Format(_type.ToString().ToLower());
		#endregion Properties

		#region Methods
		bool IConstructionRule.CanConstruct(Vector3 position)
		{
			IMap map = Services.Instance.Get<IMap>();
			ISector sectorOnPosition = map.GetSectorOnPosition(position);

			if (sectorOnPosition != null)
			{
				return ContainsResourceFlag(sectorOnPosition, _type);
			}
			else
			{
				Debug.LogErrorFormat(BuildErrorMessage_NoSectorFoundAtPosition(position));
				return true;
			}
		}

		public static string BuildErrorMessage_NoSectorFoundAtPosition(Vector3 position)
		{
			return string.Format(DBG_ERR_NO_SECTOR_FOUND, position);
		}

		private bool ContainsResourceFlag(ISector sectorOnPosition, SectorRessourceType type)
		{
			return GetResourceFlagCount(sectorOnPosition, type) > 0;
		}

		private int GetResourceFlagCount(ISector sector, SectorRessourceType type)
		{
			return sector.ObjectsInSector.Count(objectInSector => IsResourceFlag(objectInSector, type));
		}

		private bool IsResourceFlag(GameObject gameObject, SectorRessourceType type)
		{
			if (gameObject.TryGetComponent(out FlagResourceToSector resourceFlag))
			{
				return resourceFlag.Type == type;
			}
			else
			{
				return false;
			}
		}
		#endregion Methods
	}
}
