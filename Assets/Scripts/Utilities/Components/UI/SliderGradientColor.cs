namespace Tartaros
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using UnityEngine;
	using UnityEngine.UI;

	[RequireComponent(typeof(Slider))]
	public class SliderGradientColor : MonoBehaviour
	{
		[SerializeField] private Graphic _sliderForeground = null;
		[SerializeField] private Gradient _gradient = null;

		private Slider _slider = null;

		private void Awake()
		{
			_slider = GetComponent<Slider>();
		}
		
		private void OnEnable()
		{
			_slider.onValueChanged.RemoveListener(ValueChanged);
			_slider.onValueChanged.AddListener(ValueChanged);
		}

		private void OnDisable()
		{
			_slider.onValueChanged.RemoveListener(ValueChanged);
		}

		private void ValueChanged(float value)
		{
			_sliderForeground.color = _gradient.Evaluate(_slider.GetPercent());
		}
	}
}
