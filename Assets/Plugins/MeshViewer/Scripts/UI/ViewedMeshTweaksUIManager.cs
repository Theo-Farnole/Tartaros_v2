namespace Tartaros.MeshViewer
{
	using UnityEngine;
	using UnityEngine.UI;

	internal class ViewedMeshTweaksUIManager : MonoBehaviour
	{
		#region Fields
		[SerializeField]
		private Button _rotate90Degrees = null;

		[SerializeField]
		private Button _rotateAnti90Degrees = null;

		[SerializeField]
		private Slider _scaleSlider = null;

		private ViewModelManager _viewModelManager = null;
		#endregion Fields

		#region Methods
		void Start()
		{
			_viewModelManager = ViewModelManager.Instance;

			_rotate90Degrees.onClick.RemoveListener(_viewModelManager.Rotate90Degrees);
			_rotate90Degrees.onClick.AddListener(_viewModelManager.Rotate90Degrees);

			_rotateAnti90Degrees.onClick.RemoveListener(_viewModelManager.RotateAnti90Degrees);
			_rotateAnti90Degrees.onClick.AddListener(_viewModelManager.RotateAnti90Degrees);
		}

		private void OnEnable()
		{
			_scaleSlider.onValueChanged.RemoveListener(OnScaleSliderValueChanged);
			_scaleSlider.onValueChanged.AddListener(OnScaleSliderValueChanged);
		}

		private void OnDestroy()
		{
			_scaleSlider.onValueChanged.RemoveListener(OnScaleSliderValueChanged);			
		}

		private void OnScaleSliderValueChanged(float value)
		{
			_viewModelManager.SetScale(value);
		}
		#endregion Methods
	}
}
