namespace Tartaros.UI
{
	using Tartaros.Map;
	using Tartaros.ServicesLocator;
	using UnityEngine;
	using UnityEngine.UI;

	public class SectorResourcesSlider : MonoBehaviour
	{
		[SerializeField] private Slider _slider = null;

		private FlagResourceToSector _flagResourceToSector = null;
		private IMap _map = null;

		private void Awake()
		{
			_map = Services.Instance.Get<IMap>();

			ISector sectorOnPosition = _map.GetSectorOnPosition(transform.position);
			_flagResourceToSector = sectorOnPosition.FindObjectsInSectorOfType<FlagResourceToSector>()[0];
		}

		private void Start()
		{
			_slider.value = _flagResourceToSector.AvailableResources;
			_slider.maxValue = _flagResourceToSector.ResourcesAvailableAtStart;
		}

		private void OnEnable()
		{
			_flagResourceToSector.AvailableResourcesChanged -= AvailableResourcesChanged;
			_flagResourceToSector.AvailableResourcesChanged += AvailableResourcesChanged;
		}

		private void OnDisable()
		{
			_flagResourceToSector.AvailableResourcesChanged -= AvailableResourcesChanged;
		}

		private void AvailableResourcesChanged(object sender, FlagResourceToSector.AvailableResourcesChangedArgs e)
		{
			_slider.value = _flagResourceToSector.AvailableResources;
			_slider.maxValue = _flagResourceToSector.ResourcesAvailableAtStart;
		}
	}
}
