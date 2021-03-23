namespace Tartaros.Map
{
	using System.Linq;
	using Tartaros.Economy;
	using Tartaros.Sectors;
	using Tartaros.ServicesLocator;
	using UnityEngine;

	public class OnlyConstructOnSpecificResourceTypeSector : IConstructionRule
	{
		#region Fields
		[SerializeField]
		private SectorRessourceType _type = SectorRessourceType.Food;
		#endregion Fields

		#region Ctor
		public OnlyConstructOnSpecificResourceTypeSector(SectorRessourceType type)
		{
			_type = type;
		}

		#endregion Ctor

		#region Methods
		bool IConstructionRule.CanConstruct(Vector3 position)
		{
			IMap map = Services.Instance.Get<IMap>();
			ISector sectorOnPosition = map.GetSectorOnPosition(position);

			return ContainsResourceFlag(sectorOnPosition, _type);
		}

		private bool ContainsResourceFlag(ISector sectorOnPosition, SectorRessourceType type)
		{
			return GetResourceFlagCount(sectorOnPosition, type) > 0;
		}

		private int GetResourceFlagCount(ISector sector, SectorRessourceType type)
		{
			return sector.ObjectsInSector.Count(x => IsResourceFlag(x, type));
		}

		private bool IsResourceFlag(GameObject gameObject, SectorRessourceType type)
		{
			if (gameObject.TryGetComponent(out FlagResourceToSector incomeGenerator))
			{
				return incomeGenerator.Type == _type;
			}
			else
			{
				return false;
			}
		}
		#endregion Methods
	}
}
