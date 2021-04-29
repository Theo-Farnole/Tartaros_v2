namespace Tartaros.UI
{
	using DG.Tweening;
	using Sirenix.OdinInspector;
	using Tartaros.Entities;
	using UnityEngine;
	using UnityEngine.UI;

	public partial class UIHealthBar : MonoBehaviour
	{
		#region Fields
		// Contexte: this composant is often in a nested prefab
		// Because Odin struggle to serialize an interface in a nested prefab,
		// we get rid of odin serialization by getting IHeathable		
		[SerializeField]
		[SuffixLabel("(optional) will get IHeatable component this")]
		[ValidateInput("DoContainsIHealthable", "Must be not null and contains a IHeathable")]
		private GameObject _healthableContainer = null;

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
		private void Awake()
		{
			if (_healthableContainer != null)
			{
				_healthable = _healthableContainer.GetComponent<IHealthable>();
			}
		}

		private void Start()
		{
			_slider.transform.forward = -Camera.main.transform.forward;

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
			if (_healthable.IsInterfaceDestroyed() == false)
			{
				_slider.value = _healthable.CurrentHealth;
				_slider.gameObject.SetActive(ShouldShowSlider);
			}
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

#if UNITY_EDITOR
	public partial class UIHealthBar
	{
#pragma warning disable IDE0051 // Remove unused private members
		bool DoContainsIHealthable(GameObject gameObject)
#pragma warning restore IDE0051 // Remove unused private members
		{
			return gameObject == null || gameObject.GetComponent<IHealthable>() != null;
		}
	}
#endif // UNITY_EDITOR
}
