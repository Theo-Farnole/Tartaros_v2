namespace Tartaros.Map
{
	using Sirenix.OdinInspector;
	using System.Linq;
	using Tartaros.Construction;
	using Tartaros.Economy;
	using Tartaros.Entities;
	using Tartaros.ServicesLocator;
	using Tartaros.UI.MiniMap;
	using Tartaros.UI.Sectors.Orders;
	using UnityEngine;

	[RequireComponent(typeof(SectorObject)), InfoBox("Fill constructable of building slot AUTOMATICALLY")]
	public partial class FlagResourceToSector : MonoBehaviour, ISectorOrderable, ISectorUIStylizer, ISectorUIContentProvider
	{
		#region Fields
		[SerializeField] private SectorRessourceType _type = SectorRessourceType.Food;
		[SerializeField] private int _availableResources = 1000;

		private ResourceMiniMapIcon _miniMapIcon = null;
		private ISector _sectorOnPosition = null;

		// SERVICES
		private IMap _map = null;
		private BuildingsDatabase _buildingsDatabase = null;
		private UIStyles _uiStyles = null;
		#endregion Fields

		#region Properties
		public SectorRessourceType Type
		{
			get => _type;

			set
			{
				_type = value;
				_miniMapIcon.ResourceType = _type;
			}
		}

		SectorStyle ISectorUIStylizer.SectorStyle => _uiStyles.SectorStyles.GetResourceStyle(_type);

		public int AvailableResources { get => _availableResources; set => _availableResources = Mathf.Max(0, value); }
		#endregion Properties

		#region Methods
		private void Awake()
		{
			_map = Services.Instance.Get<IMap>();
			_buildingsDatabase = Services.Instance.Get<BuildingsDatabase>();
			_uiStyles = Services.Instance.Get<UIStyles>();

			_sectorOnPosition = _map.GetSectorOnPosition(transform.position);

			_miniMapIcon = gameObject.GetOrAddComponent<ResourceMiniMapIcon>();
			_miniMapIcon.ResourceType = _type;

			CheckIfBuildingSlotIsMissing();
			SetBuildingSlotConstructable();

		}

		private void OnEnable()
		{
			CheckIfCaptureBuildingIsHere();
		}

		public bool IsDepleted()
		{
			return _availableResources <= 0;
		}

		private void SetBuildingSlotConstructable()
		{
			BuildingSlot buildingSlot = _sectorOnPosition.GetBuildingSlotAvailable();

			if (buildingSlot != null)
			{
				buildingSlot.Constructable = _buildingsDatabase.GetResourceBuildingAsConstructable(_type);
				buildingSlot.Sector = _sectorOnPosition;
			}
		}

		private void CheckIfCaptureBuildingIsHere()
		{
			bool captureBuildingAvailable = _sectorOnPosition.ContainsAvailablCaptureBuilding();

			if (captureBuildingAvailable == true)
			{
				_sectorOnPosition.GetBuildingSlotAvailable().IsAvailable = false;
			}
		}



		private void CheckIfBuildingSlotIsMissing()
		{
			Debug.Assert(_sectorOnPosition != null, "Resource flag must be placed on a sector.", this);

			if (_sectorOnPosition != null)
			{
				int slotCount = _sectorOnPosition.GetBuildingSlots().Count();
				Debug.Assert(slotCount > 0, "There is no building slot whereas we have a flag resource to sector! Please add one.", this);
			}
		}

		SectorOrder ISectorOrderable.GenerateSectorOrder()
		{
			if (_sectorOnPosition.ContainsAvailableBuildingSlot())
			{
				return new ConstructAtBuildingSlotOrder(_sectorOnPosition.GetBuildingSlotAvailable());
			}
			else
			{
				return null;
			}
		}

		SectorUIContent ISectorUIContentProvider.GetSectorContent()
		{
			string name = TartarosTexts.GetResourceSectorName(_type);
			string description = TartarosTexts.GetResourceSectorDescription(_sectorOnPosition);

			return new SectorUIContent(name, description);
		}
		#endregion Methods
	}

#if UNITY_EDITOR
	public partial class FlagResourceToSector
	{
		private void OnDrawGizmos()
		{
			_type.DrawIcon(transform.position);
		}
	}
#endif
}
