namespace Tartaros
{
	using TMPro;
	using UnityEngine;
	using UnityEngine.UI;

	[RequireComponent(typeof(TMP_InputField))]
	public class SliderInputField : MonoBehaviour
	{
		#region Fields
		[SerializeField]
		private Slider _slider = null;

		private TMP_InputField _inputField = null;
		#endregion Fields

		#region Methods
		private void Awake()
		{
			_inputField = GetComponent<TMP_InputField>();
		}

		private void Start()
		{
			UpdateSliderValue();
		}

		private void OnEnable()
		{
			_slider.onValueChanged.RemoveListener(OnSliderValueChanged);
			_slider.onValueChanged.AddListener(OnSliderValueChanged);

			_inputField.onValueChanged.RemoveListener(OnInputFieldChanged);
			_inputField.onValueChanged.AddListener(OnInputFieldChanged);
		}

		private void OnDisable()
		{
			_slider.onValueChanged.RemoveListener(OnSliderValueChanged);
			_inputField.onValueChanged.RemoveListener(OnInputFieldChanged);
		}

		void OnSliderValueChanged(float value)
		{
			UpdateSliderValue();
		}

		void OnInputFieldChanged(string inputFieldText)
		{
			if (float.TryParse(inputFieldText, out float sliderValue))
			{
				_slider.value = sliderValue;
			}
		}

		private void UpdateSliderValue()
		{
			_inputField.SetTextWithoutNotify(string.Format("{0:0.##}", _slider.value));
		}
		#endregion Methods
	}
}