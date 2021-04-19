namespace Tartaros.UI
{
	using System.Collections;
	using Tartaros.Construction;
	using UnityEngine;
	using UnityEngine.UI;

	public class UIConstructionDelayBar : MonoBehaviour
	{
		[SerializeField]
		private Slider _slider = null;

		private ConstructionDelay _constructionDelay = null;

		private void Start()
		{
			_constructionDelay = GetComponentInParent<ConstructionDelay>();
			SetSliderBounds();
			SetSliderValue();
		}

		private void Update()
		{
			SetSliderValue();
		}

		private void SetSliderBounds()
		{
			if (_slider != null && _constructionDelay != null)
			{
				_slider.minValue = 0;
				_slider.maxValue = _constructionDelay.TimeToConstruct;
			}
		}

		private void SetSliderValue()
		{
			if (_constructionDelay != null)
			{
				_slider.value = _constructionDelay.CurrentDelay;
			}
			else
			{
				Debug.LogError("There is no ConstructionDelayScript");
			}
		}
	}
}