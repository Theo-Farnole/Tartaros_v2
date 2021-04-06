namespace Tartaros.UI
{
	using Sirenix.OdinInspector;
	using Tartaros.Power;
	using Tartaros.ServicesLocator;
	using UnityEngine;
	using UnityEngine.UI;

	public class CastPowerButton : MonoBehaviour
	{
		#region Enums
		private enum Power
		{
			LightningBolt,
			ControlledAoE
		}
		#endregion Enums

		#region Fields
		[SerializeField]
		[SuffixLabel("self if null")]
		private Button _button = null;

		[SerializeField]
		private Power _powerToCast = Power.LightningBolt;

		private PowerManager _powerManager = null;
		#endregion Fields

		#region Methods
		private void Awake()
		{
			_button = GetComponent<Button>();
		}

		private void Start()
		{
			_powerManager = Services.Instance.Get<PowerManager>();
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

				default:
					throw new System.NotImplementedException();
			}
		}
		#endregion Methods
	}
}
