namespace Tartaros.Map.Village
{
	using Tartaros.Entities;
	using Tartaros.Population;
	using Tartaros.Map;
	using Tartaros.ServicesLocator;
	using UnityEngine;
	using System;
	using Tartaros.Dialogue;
	using Tartaros.UI.Sectors.Orders;

	public class Village : MonoBehaviour, ISectorUIStylizer, ISectorUIContentProvider, ISectorOrderable
	{
		#region Fields

		[SerializeField] private VillageData _data = null;
		[SerializeField] private BuildingSlot _buildingSlot = null;
		[SerializeField] private bool _ENABLE_DIALOGUE_STATE_EDITOR = false;

		private ISector _sector = null;

		// SERVICES
		private IMap _map = null;
		private IPopulationManager _populationManager = null;
		private DialogueManager _dialogueManager = null;
		private UIStyles _uiStyles = null;
		#endregion Fields

		#region Properties
		private int PopulationToIncrease => _data.PopulationAmount;

		SectorStyle ISectorUIStylizer.SectorStyle => _uiStyles.SectorStyles.Village;
		#endregion Properties

		#region Events
		public class VillageCapturedArgs : EventArgs
		{
		}
		public event EventHandler<VillageCapturedArgs> VillageCaptured = null;
		#endregion Events


		#region Methods		
		private void Awake()
		{
			_map = Services.Instance.Get<IMap>();
			_populationManager = Services.Instance.Get<IPopulationManager>();
			_uiStyles = Services.Instance.Get<UIStyles>();

			_data = GetComponent<Entity>().GetBehaviourData<VillageData>();
			_dialogueManager = FindObjectOfType<DialogueManager>();
		}

		private void Start()
		{
			_sector = _map.GetSectorOnPosition(transform.position);

			if (_buildingSlot is null) throw new UnassignedReferenceException(nameof(_buildingSlot));
			if (_data is null) throw new UnassignedReferenceException(nameof(_data));
		}

		private void OnEnable()
		{
			_sector.Captured -= OnCaptureSector;
			_sector.Captured += OnCaptureSector;
		}

		private void OnDisable()
		{
			_sector.Captured -= OnCaptureSector;
		}

		private void OnDrawGizmos()
		{
			if (_buildingSlot != null)
			{
				Gizmos.color = Color.green;
				Gizmos.DrawLine(transform.position, _buildingSlot.transform.position);
			}
		}

		private void OnCaptureSector(object sender, CapturedArgs e)
		{
			_populationManager.IncrementMaxPopulation(PopulationToIncrease);

			if (_dialogueManager != null)
			{
#if UNITY_EDITOR
				if (_ENABLE_DIALOGUE_STATE_EDITOR == true)
#endif
					_dialogueManager.EnterDialogueState();
			}

			VillageCaptured?.Invoke(this, new VillageCapturedArgs());
		}

		SectorOrder ISectorOrderable.GenerateSectorOrder()
		{
			if (_buildingSlot == null) throw new System.NotSupportedException("Missing building slot in inspector.");

			return new ConstructAtBuildingSlotOrder(_buildingSlot);
		}

		SectorUIContent ISectorUIContentProvider.GetSectorContent()
		{
			string name = TartarosTexts.VILLAGE;
			string description = TartarosTexts.VILLAGE_DESCRIPTION;

			return new SectorUIContent(name, description);
		}
		#endregion Methods
	}
}