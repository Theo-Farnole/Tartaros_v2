namespace Tartaros.UI
{
	using Sirenix.OdinInspector;
	using Tartaros.Entities;
	using UnityEngine;
	using UnityEngine.UI;

	public class UIHealthBar : SerializedMonoBehaviour
	{
		#region Fields
		[SerializeField]
		private IHealthable _healthable = null;

		[SerializeField]
		private Slider _slider = null;

		[SerializeField]
		private bool _hideIfFull = true;
		#endregion Fields

		#region Properties
		public IHealthable Healthable
		{
			get => _healthable;

			set
			{
				UnsubcribeToHealthChangedEvent();

				_healthable = value;
				SetSliderBounds();
				SetSliderValue();

				SubscribeToHealthChangedEvent();
			}
		}

		[ShowInRuntime]
		private bool ShouldHideSlider
		{
			get
			{
				if (_hideIfFull == true)
				{
					return _healthable.IsFullLife(); // ONLY SHOW IF NOT FULL LIFE
				}
				else
				{
					return false; // ALWAYS SHOW
				}
			}
		}

		private bool ShouldShowSlider => !ShouldHideSlider;
		#endregion Properties

		#region Methods
		private void Start()
		{
			SetSliderBounds();
			SetSliderValue();
		}

		private void OnEnable()
		{
			SubscribeToHealthChangedEvent();
		}

		private void OnDisable()
		{
			UnsubcribeToHealthChangedEvent();
		}

		private void SubscribeToHealthChangedEvent()
		{
			if (_healthable != null)
			{
				_healthable.HealthChanged -= HealthChanged;
				_healthable.HealthChanged += HealthChanged;
			}
		}

		private void UnsubcribeToHealthChangedEvent()
		{
			if (_healthable != null)
			{
				_healthable.HealthChanged -= HealthChanged;
			}
		}

		private void HealthChanged(object sender, HealthChangedArgs e)
		{
			SetSliderValue();
		}

		private void SetSliderValue()
		{
			_slider.value = _healthable.CurrentHealth;
			_slider.gameObject.SetActive(ShouldShowSlider);
		}

		private void SetSliderBounds()
		{
			if (_slider != null && _healthable.IsInterfaceDestroyed() == false)
			{
				_slider.minValue = 0;
				_slider.maxValue = _healthable.MaxHealth;
			}
		}
		#endregion Methods
	}
}
