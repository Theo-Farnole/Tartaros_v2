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

		#region Properties
		public TextMeshProUGUI AmountLabel { get => _amountLabel; set => _amountLabel = value; }
		public SectorRessourceType SectorRessourceType
		{
			get => _sectorRessourceType;

			set
			{
				_sectorRessourceType = value;
				UpdateAmountLabel();
			}
		}
		#endregion Properties

		#region Methods
		private void Awake()
		{
			if (_amountLabel == null)
			{
				_amountLabel = GetComponent<TextMeshProUGUI>();
			}

			_playerSectorResources = Services.Instance.Get<IPlayerSectorResources>();
		}

		private void Start()
		{
			UpdateAmountLabel();
		}

		private void OnEnable()
		{
			_playerSectorResources.AmountChanged -= AmountChanged;
			_playerSectorResources.AmountChanged += AmountChanged;
		}

		private void OnDisable()
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