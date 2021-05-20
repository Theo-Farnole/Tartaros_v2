namespace Tartaros.UI
{
	using Sirenix.OdinInspector;
	using Tartaros.Map.Village;
	using Tartaros.Powers;
	using Tartaros.ServicesLocator;
	using UnityEngine;
	using UnityEngine.UI;

	[RequireComponent(typeof(ShowCostOnPointerEnter))]
	public class CastPowerButton : MonoBehaviour
	{
		#region Fields
		[SerializeField, SuffixLabel("self if null")] private Button _button = null;
		[SerializeField] private Power _powerToCast = Power.LightningBolt;

		private PowerManager _powerManager = null;
		private ShowCostOnPointerEnter _showCostOnPointerEnter = null;
		#endregion Fields

		#region Methods
		private void Awake()
		{
			_button = GetComponent<Button>();
			_powerManager = Services.Instance.Get<PowerManager>();
			_showCostOnPointerEnter = GetComponent<ShowCostOnPointerEnter>();
		}

		private void Start()
		{
			_showCostOnPointerEnter.GloryCost = _powerManager.GetGloryPrice(_powerToCast);
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
