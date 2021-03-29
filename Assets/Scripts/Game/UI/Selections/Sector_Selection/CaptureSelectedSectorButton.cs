namespace Tartaros.UI
{
	using Sirenix.OdinInspector;
	using Tartaros.Map;
	using Tartaros.Sectors;
	using Tartaros.Selection;
	using Tartaros.ServicesLocator;
	using UnityEngine;
	using UnityEngine.UI;

	public class CaptureSelectedSectorButton : MonoBehaviour
	{
		#region Fields
		[SerializeField]
		[SuffixLabel("self is null")]
		private Button _captureButton = null;

		private ISelection _currentSelection = null;
		private ISectorsCaptureManager _sectorsCaptureManager = null;
		#endregion Fields

		#region Methods
		private void Awake()
		{
			if (_captureButton == null)
			{
				_captureButton = GetComponent<Button>();
			}
		}

		private void Start()
		{
			_currentSelection = Services.Instance.Get<CurrentSelection>();
			_sectorsCaptureManager = Services.Instance.Get<ISectorsCaptureManager>();
		}

		private void OnEnable()
		{
			_captureButton.onClick.RemoveListener(OnCaptureButtonClick);
			_captureButton.onClick.AddListener(OnCaptureButtonClick);
		}

		private void OnDisable()
		{
			_captureButton.onClick.RemoveListener(OnCaptureButtonClick);
		}

		void OnCaptureButtonClick()
		{
			foreach (ISelectable selected in _currentSelection.SelectedSelectables)
			{
				if (selected.GameObject.TryGetComponent(out ISector sector))
				{
					_sectorsCaptureManager.Capture(sector);
				}
			}
		}
		#endregion Methods
	}
}