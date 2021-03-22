namespace Tartaros.UI
{
	using Sirenix.OdinInspector;
	using Tartaros.Economy;
	using Tartaros.ServicesLocator;
	using TMPro;
	using UnityEngine;

	public class PlayerResourceAmountLabel : MonoBehaviour
	{
		#region Fields
		[SerializeField]
		[SuffixLabel("self is null")]
		private TextMeshProUGUI _amountLabel = null;

		[SerializeField]
		private SectorRessourceType _sectorRessourceType = SectorRessourceType.Food;

		private IPlayerSectorResources _playerSectorResources = null;
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
			_playerSectorResources = Services.Instance.Get<IPlayerSectorResources>();
			SubscribeToEventAmountChanged();
			UpdateAmountLabel();
		}

		private void OnEnable()
		{
			if (_playerSectorResources != null)
			{
				SubscribeToEventAmountChanged();
			}
		}

		private void OnDisable()
		{
			UnsubcribeToEventAmountChanged();
		}

		private void SubscribeToEventAmountChanged()
		{
			UnsubcribeToEventAmountChanged();
			_playerSectorResources.AmountChanged += AmountChanged;
		}

		private void UnsubcribeToEventAmountChanged()
		{
			_playerSectorResources.AmountChanged -= AmountChanged;
		}

		private void AmountChanged(object sender, AmountChangedArgs e)
		{
			UpdateAmountLabel();
		}

		private void UpdateAmountLabel()
		{
			_amountLabel.text = _playerSectorResources.GetAmount(_sectorRessourceType).ToString();
		}
		#endregion Methods
	}
}