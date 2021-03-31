namespace Tartaros.UI
{
	using Sirenix.OdinInspector;
	using Tartaros.Economy;
	using Tartaros.ServicesLocator;
	using TMPro;
	using UnityEngine;

	public class PlayerResourceIncomeLabel : MonoBehaviour
	{
		#region Fields
		[SerializeField]
		[SuffixLabel("self is null")]
		private TextMeshProUGUI _incomeLabel = null;

		[SerializeField]
		private SectorRessourceType _sectorRessourceType = SectorRessourceType.Food;

		private IPlayerIncomeManager _playerIncome = null;
		#endregion Fields

		#region Properties
		private int PlayerIncome => _playerIncome.GetIncomeAmount(_sectorRessourceType);
		#endregion Properties

		#region Methods
		private void Awake()
		{
			if (_incomeLabel == null)
			{
				_incomeLabel = GetComponent<TextMeshProUGUI>();
			}
		}

		private void Start()
		{
			_playerIncome = Services.Instance.Get<IPlayerIncomeManager>();
			SubscribeToEventAmountChanged();
			UpdateAmountLabel();
		}

		private void OnEnable()
		{
			SubscribeToEventAmountChanged();
		}

		private void OnDisable()
		{
			UnsubcribeToEventAmountChanged();
		}

		private void SubscribeToEventAmountChanged()
		{
			if (_playerIncome == null) return;

			UnsubcribeToEventAmountChanged();
			_playerIncome.IncomeChanged += AmountChanged;
		}

		private void UnsubcribeToEventAmountChanged()
		{
			if (_playerIncome == null) return;

			_playerIncome.IncomeChanged -= AmountChanged;
		}

		private void AmountChanged(object sender, IncomeChangedArgs e)
		{
			UpdateAmountLabel();
		}

		private void UpdateAmountLabel()
		{
			if (PlayerIncome > 0)
			{
				string format = "{0}{1}";
				string prefix = GetPrefix();
				string amount = _playerIncome.GetIncomeAmount(_sectorRessourceType).ToString();

				_incomeLabel.text = string.Format(format, prefix, amount);
			}
		}

		private string GetPrefix()
		{
			if (PlayerIncome > 0)
			{
				return "+";
			}
			else if (PlayerIncome < 0)
			{
				return "-";
			}
			else
			{
				return "~";
			}
		}
		#endregion Methods
	}
}
