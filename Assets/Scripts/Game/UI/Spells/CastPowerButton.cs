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
			_showCostOnPointerEnter.GloryCost = _powerManager.GetGloryPrice(_powerToCast);
			SetToShowData();
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
		}

		private void OnDisable()
		{
			_button.onClick.RemoveListener(OnButtonClick);
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
