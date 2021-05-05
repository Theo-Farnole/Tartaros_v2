namespace Tartaros.UI
{
	using Sirenix.OdinInspector;
	using Tartaros.Map.Village;
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

		private Village _village = null;
		private PowerManager _powerManager = null;
		private bool _powerIsLocked = false;
		#endregion Fields

		#region Methods
		private void Awake()
		{
			_button = GetComponent<Button>();
			_powerManager = Services.Instance.Get<PowerManager>();
			_village = FindObjectOfType<Village>();
		}

		private void OnEnable()
		{
			_button.onClick.RemoveListener(OnButtonClick);
			_button.onClick.AddListener(OnButtonClick);

			if (_village != null)
			{
				_village.VillageCaptured -= VillageCaptured;
				_village.VillageCaptured += VillageCaptured;
			}
		}

		private void Start()
		{
			if (_powerToCast == Power.ControlledAoE)
			{
				_button.interactable = false;
			}
		}

		private void VillageCaptured(object sender, Village.VillageCapturedArgs e)
		{
			_powerIsLocked = true;
			_button.interactable = true;
		}

		private void OnDisable()
		{
			_button.onClick.RemoveListener(OnButtonClick);

			if (_village != null)
			{
				_village.VillageCaptured -= VillageCaptured;
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

				default:
					throw new System.NotImplementedException();
			}
		}
		#endregion Methods
	}
}
