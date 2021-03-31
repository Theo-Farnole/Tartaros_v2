namespace Tartaros.UI
{
	using Sirenix.OdinInspector;
	using Tartaros.Population;
	using Tartaros.ServicesLocator;
	using TMPro;
	using UnityEngine;

	public class PlayerCurrentPoputationLabel : MonoBehaviour
	{
		#region Fields
		[SerializeField]
		[SuffixLabel("self if null")]
		private TextMeshProUGUI _currentPopulationLabel = null;

		private IPopulationManager _populationManager = null;
		#endregion Fields

		#region Methods
		private void Awake()
		{
			if (_currentPopulationLabel == null)
			{
				_currentPopulationLabel = GetComponent<TextMeshProUGUI>();
			}
		}

		private void Start()
		{
			_populationManager = Services.Instance.Get<IPopulationManager>();

			_populationManager.CurrentPopulationChanged -= CurrentPopulationChanged;
			_populationManager.CurrentPopulationChanged += CurrentPopulationChanged;

			UpdateLabel();
		}

		private void OnEnable()
		{
			if (_populationManager != null)
			{
				_populationManager.CurrentPopulationChanged -= CurrentPopulationChanged;
				_populationManager.CurrentPopulationChanged += CurrentPopulationChanged;
			}
		}

		private void OnDisable()
		{
			_populationManager.CurrentPopulationChanged -= CurrentPopulationChanged;
		}

		private void CurrentPopulationChanged(object sender, CurrentPopulationChangedArgs e)
		{
			UpdateLabel();
		}

		private void UpdateLabel()
		{
			_currentPopulationLabel.text = _populationManager.CurrentPopulation.ToString();
		}
		#endregion Methods
	}
}
