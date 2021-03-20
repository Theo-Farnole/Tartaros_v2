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
		private TextMeshProUGUI _amountLabel = null;

		[SerializeField]
		private SectorRessourceType _sectorRessourceType = SectorRessourceType.Food;

		private IPlayerIncomeSectorResources _playerIncome = null;
		#endregion Fields

		#region Methods
		private void Awake()
		{
			if (_amountLabel == null)
			{
				_amountLabel = GetComponent<TextMeshProUGUI>();
			}
		}

		private void Start()
		{
			_playerIncome = Services.Instance.Get<IPlayerIncomeSectorResources>();
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
			_playerIncome.AmountChanged += AmountChanged;
		}

		private void UnsubcribeToEventAmountChanged()
		{
			if (_playerIncome == null) return;

			_playerIncome.AmountChanged -= AmountChanged;
		}

		private void AmountChanged(object sender, AmountChangedArgs e)
		{
			UpdateAmountLabel();
		}

		private void UpdateAmountLabel()
		{
			throw new System.NotImplementedException();
			//if (_playerIncome > 0)
			//{
			//	_amountLabel.text = "+" + _playerIncome.GetAmount(_sectorRessourceType).ToString();
			//}
		}
		#endregion Methods
	}
}
