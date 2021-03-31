namespace Tartaros.UI
{
	using Sirenix.OdinInspector;
	using Tartaros.Population;
	using Tartaros.ServicesLocator;
	using TMPro;
	using UnityEngine;

	public class PlayerMaximumPoputationLabel : MonoBehaviour
	{
		#region Fields
		[SerializeField]
		[SuffixLabel("self if null")]
		private TextMeshProUGUI _maximumPopulationLabel = null;

		private IPopulationManager _populationManager = null;
		#endregion Fields

		#region Methods
		private void Awake()
		{
			if (_maximumPopulationLabel == null)
			{
				_maximumPopulationLabel = GetComponent<TextMeshProUGUI>();
			}
		}

		private void Start()
		{
			_populationManager = Services.Instance.Get<IPopulationManager>();

			_populationManager.MaxPopulationChanged -= MaxPopulationChanged;
			_populationManager.MaxPopulationChanged += MaxPopulationChanged;

			UpdateLabel();
		}

		private void OnEnable()
		{
			if (_populationManager != null)
			{
				_populationManager.MaxPopulationChanged -= MaxPopulationChanged;
				_populationManager.MaxPopulationChanged += MaxPopulationChanged;
			}
		}

		private void OnDisable()
		{
			_populationManager.MaxPopulationChanged -= MaxPopulationChanged;
		}

		private void MaxPopulationChanged(object sender, MaxPopulationChangedArgs e)
		{
			UpdateLabel();
		}

		private void UpdateLabel()
		{
			_maximumPopulationLabel.text = _populationManager.MaximumPopulation.ToString();
		}
		#endregion Methods
	}
}
