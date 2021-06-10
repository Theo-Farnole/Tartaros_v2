namespace Tartaros.UI
{
	using Sirenix.OdinInspector;
	using Tartaros.Powers;
	using Tartaros.ServicesLocator;
	using Tartaros.UI.HoverPopup;
	using UnityEngine;
	using UnityEngine.UI;

	[RequireComponent(typeof(ShowCostOnPointerEnter), typeof(OpenHoverPopupOnHover))]
	public class CastPowerButton : MonoBehaviour
	{
		#region Fields
		[SerializeField, SuffixLabel("self if null")] private Button _button = null;
		[SerializeField] private Power _powerToCast = Power.LightningBolt;
		[SerializeField] private Image _lockImage = null;

		private ShowCostOnPointerEnter _showCostOnPointerEnter = null;
		private OpenHoverPopupOnHover _openHover = null;

		// SERVICES
		private PowerManager _powerManager = null;
		#endregion Fields

		#region Methods
		private void Awake()
		{
			_powerManager = Services.Instance.Get<PowerManager>();

			if (_button == null)
			{
				_button = GetComponent<Button>();
			}
			_showCostOnPointerEnter = GetComponent<ShowCostOnPointerEnter>();
			_openHover = GetComponent<OpenHoverPopupOnHover>();
		}

		private void Start()
		{
			if (_lockImage != null)
			{
				bool lockToShow = IsPowerToCastUnlocked() == false;
				_lockImage.gameObject.SetActive(lockToShow);
			}

			_showCostOnPointerEnter.GloryCost = _powerManager.GetGloryPrice(_powerToCast);
			SetToShowData();
		}

		private bool IsPowerToCastUnlocked()
		{
			return _powerManager.IsPowerUnlock(_powerToCast);
		}

		private void SetToShowData()
		{
			_openHover.ToShowData = new HoverPopupData(_openHover.ToShowData)
			{
				CooldownInSeconds = 0,
				GloryCost = _powerManager.GetGloryPrice(_powerToCast)
			}; ;
		}

		private void OnEnable()
		{
			_button.onClick.RemoveListener(OnButtonClick);
			_button.onClick.AddListener(OnButtonClick);

			_powerManager.PowerUnlocked -= PowerUnlocked;
			_powerManager.PowerUnlocked += PowerUnlocked;
		}

		private void OnDisable()
		{
			_powerManager.PowerUnlocked -= PowerUnlocked;
			_button.onClick.RemoveListener(OnButtonClick);
		}

		private void PowerUnlocked(object sender, PowerManager.PowerUnlockedArgs e)
		{
			if (e.powerUnlocked == _powerToCast && _lockImage != null)
			{
				_lockImage.gameObject.SetActive(false);
			}
		}

		private void OnButtonClick()
		{
			CastPower();
		}


		private void CastPower()
		{
			switch (_powerToCast)
			{
				case Power.LightningBolt:
					_powerManager.CastLightningBolt();
					break;

				case Power.ControlledAoE:
					_powerManager.CastControlledAoE();
					break;

				case Power.None:
					throw new System.NotSupportedException("The power that want to be cast is the value None.");

				default:
					throw new System.NotImplementedException();
			}
		}
		#endregion Methods
	}
}
