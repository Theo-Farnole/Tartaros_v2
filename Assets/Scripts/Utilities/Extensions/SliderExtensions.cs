namespace Tartaros
{
	using UnityEngine.UI;

	public static class SliderExtensions
	{
		public static float GetPercent(this Slider slider)
		{
			if (slider.minValue != 0) throw new System.NotImplementedException("Cannot get a percent when the min value is not equals to zero.");

			float percent = slider.value / slider.maxValue;

			return percent;
		}
	}
}
