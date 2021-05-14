﻿namespace Tartaros.UI
{
	using Sirenix.OdinInspector;
	using Tartaros.Map.Village;
	using Tartaros.Power;
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
			if (_powerToCast == Power.ControlledAoE && _powerManager.IsAVillageToCaptureOnTheScene() == true)
			{
				_button.interactable = false;
			}

			_showCostOnPointerEnter.GloryCost = _powerManager.GetGloryCost(_powerToCast);
		}

		private void Update()
		{
			if (_button.interactable == false && _powerManager.IsVillageCaptured() == true)
			{
				_button.interactable = true;
			}
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

		public void EnablePower()
		{
			if (_powerToCast == Power.ControlledAoE)
			{
				_button.interactable = true;
			}
		}

		public void DisablePower()
		{
			if (_powerToCast == Power.ControlledAoE)
			{
				_button.interactable = false;
			}
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
