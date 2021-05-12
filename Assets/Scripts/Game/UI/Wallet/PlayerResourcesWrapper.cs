namespace Tartaros.UI
{
	using Sirenix.OdinInspector;
	using Tartaros.Economy;
	using Tartaros.ServicesLocator;
	using TMPro;
	using UnityEngine;
	using UnityEngine.UI;

	public class PlayerResourcesWrapper : MonoBehaviour
	{

		#region Fields
		[SerializeField] private bool _isPopulation = false;

		[SerializeField] private Image _icon = null;

		[SerializeField, HideIf(nameof(_isPopulation))] private SectorRessourceType _resourceType = default;
		[SerializeField, HideIf(nameof(_isPopulation))] private TextMeshProUGUI _amountText = null;
		[SerializeField, HideIf(nameof(_isPopulation))] private TextMeshProUGUI _incomeText = null;

		[SerializeField, ShowIf(nameof(_isPopulation))] private TextMeshProUGUI _currentPopulationText = null;
		[SerializeField, ShowIf(nameof(_isPopulation))] private TextMeshProUGUI _maximumPopulationText = null;

		private IconsDatabase _iconsDatabase = null;
		#endregion Fields

		#region Methods
		private void Awake()
		{
			_iconsDatabase = Services.Instance.Get<IconsDatabase>();
		}

		private void Start()
		{
			if (_isPopulation == true)
			{
				SetupCurrentPopulationLabel();
				SetupMaximumPopulationLabel();
				SetupPopulationIcon();
			}
			else
			{
				SetupIncomeLabel();
				SetupAmountLabel();
				SetupResourcesIcons();

			}
		}

		private void SetupPopulationIcon()
		{
			_icon.sprite = _iconsDatabase.Data.PopulationIcon;
		}

		private void SetupResourcesIcons()
		{
			var resourceIcon = gameObject.AddComponent<ResourceIcon>();
			resourceIcon.Image = _icon;
			resourceIcon.ResourceType = _resourceType;
		}

		private void SetupCurrentPopulationLabel()
		{
			var currentLabel = gameObject.AddComponent<PlayerCurrentPoputationLabel>();
			currentLabel.CurrentPopulationLabel = _currentPopulationText;
		}

		private void SetupMaximumPopulationLabel()
		{
			var maximumPopulationLabel = gameObject.AddComponent<PlayerMaximumPoputationLabel>();
			maximumPopulationLabel.MaximumPopulationLabel = _maximumPopulationText;
		}

		private void SetupIncomeLabel()
		{
			PlayerResourceIncomeLabel income = gameObject.AddComponent<PlayerResourceIncomeLabel>();
			income.IncomeLabel = _incomeText;
			income.SectorRessourceType = _resourceType;
		}

		private void SetupAmountLabel()
		{
			PlayerResourceAmountLabel amount = gameObject.AddComponent<PlayerResourceAmountLabel>();
			amount.AmountLabel = _amountText;
			amount.SectorRessourceType = _resourceType;
		}
		#endregion Methods
	}
}
