namespace Tartaros.UI
{
	using Sirenix.OdinInspector;
	using Tartaros.Entities;
	using UnityEngine;
	using UnityEngine.UI;

	public class RadialHealthSlider : SerializedMonoBehaviour
	{
		#region Fields
		[SerializeField]
		private IHealthable _healthable = null;

		[SerializeField]
		private Image _radialHealth = null;

		[SerializeField]
		private RectTransform _cursor = null;
		#endregion Fields

		#region Properties
		public IHealthable Healthable
		{
			get => _healthable;

			set
			{
				UnsubcribeToHealthChangedEvent();

				_healthable = value;
				SetSliderValues();

				SubscribeToHealthChangedEvent();
			}
		}

		private float FillAmount => (float)_healthable.CurrentHealth / (float)_healthable.MaxHealth;
		#endregion Properties

		#region Methods
		private void Start()
		{
			SetSliderValues();
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
			SetSliderValues();
		}

		private void SetSliderValues()
		{
			_radialHealth.fillAmount = FillAmount;
			SetCursorRotation();
		}

		private void SetCursorRotation()
		{
			if (_cursor == null) return;

			float desiredAngleZ = Mathf.Lerp(180, 0, FillAmount);

			Vector3 eulerAngles = _cursor.eulerAngles;
			eulerAngles.z = desiredAngleZ;
			_cursor.eulerAngles = eulerAngles;
		}
		#endregion Methods
	}
}
