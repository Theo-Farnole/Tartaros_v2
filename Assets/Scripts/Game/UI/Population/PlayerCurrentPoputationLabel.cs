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

		#region Properties
		public TextMeshProUGUI CurrentPopulationLabel { get => _currentPopulationLabel; set => _currentPopulationLabel = value; }
		#endregion Properties

		#region Methods
		private void Awake()
		{
			if (_currentPopulationLabel == null)
			{
				_currentPopulationLabel = GetComponent<TextMeshProUGUI>();
			}

			_populationManager = Services.Instance.Get<IPopulationManager>();
		}

		private void Start()
		{
			UpdateLabel();
		}

		private void OnEnable()
		{
			_populationManager.CurrentPopulationChanged -= CurrentPopulationChanged;
			_populationManager.CurrentPopulationChanged += CurrentPopulationChanged;
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
