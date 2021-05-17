namespace Tartaros.UI
{
	using UnityEngine;
	using UnityEngine.UI;

	public class GloryGemUI : MonoBehaviour
	{
		#region Fields
		private readonly int SHADER_PROGRESS_ID = Shader.PropertyToID("_Progress");

		[SerializeField] private Image _fillImage = null;
		[SerializeField] private GameObject _costPreview = null;

		private int _maxGlory = 1;
		private int _gloryAmount = 0;
		#endregion Fields

		#region Properties
		public int GloryAmount
		{
			get => _gloryAmount;

			set
			{
				if (value < 0) throw new System.NotSupportedException("The glory amount cannot be negative.");


				_gloryAmount = value;
				UpdateGraphic();
			}
		}

		public int MaxGlory
		{
			get => _maxGlory;

			set
			{
				if (value < 0) throw new System.NotSupportedException("The maximum glory cannot be negative.");

				_maxGlory = value;
				UpdateGraphic();
			}
		}

		public bool ShowCostPreview { get => _costPreview.activeInHierarchy; set => _costPreview.SetActive(value); }
		#endregion Properties

		#region Methods
		private void Start()
		{
			ShowCostPreview = false;

			_fillImage.material = new Material(_fillImage.material); // makes a copy of the material
		}

		private void UpdateGraphic()
		{
			float progress = (float)_gloryAmount / (float)_maxGlory;
			_fillImage.material.SetFloat(SHADER_PROGRESS_ID, progress);
		}
		#endregion Methods
	}
}
