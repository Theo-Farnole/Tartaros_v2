namespace Tartaros.UI
{
	using Tartaros.Economy;
	using Tartaros.ServicesLocator;
	using UnityEngine;
	using UnityEngine.UI;

	public class UIGloryBar : MonoBehaviour
	{
		#region Fields
		[SerializeField]
		private Slider _slider = null;

		[SerializeField]
		private float _gloryMaximumViewable = 100;

		private IPlayerGloryWallet _gloryWallet = null;
		#endregion Fields

		#region Methods
		private void Awake()
		{
			if (_slider == null)
			{
				Debug.LogErrorFormat("Missing slider reference in {0}.", this.name);
			}

			_gloryWallet = Services.Instance.Get<IPlayerGloryWallet>();
		}

		private void Start()
		{
			SetSliderBounds();
			SetSliderValue();
		}

		private void OnEnable()
		{
			_gloryWallet.AmountChanged -= AmountChanged;
			_gloryWallet.AmountChanged += AmountChanged;
		}

		private void OnDisable()
		{
			_gloryWallet.AmountChanged -= AmountChanged;
		}

		private void AmountChanged(object sender, GloryAmountChangedArgs e)
		{
			SetSliderValue();
		}

		private void SetSliderValue()
		{
			_slider.value = _gloryWallet.GetAmount();
		}

		private void SetSliderBounds()
		{
			_slider.minValue = 0;
			_slider.maxValue = _gloryMaximumViewable;
		}
		#endregion Methods
	}
}
