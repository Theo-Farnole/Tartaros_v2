namespace Tartaros.UI.HoverPopup
{
	using Sirenix.OdinInspector;
	using Tartaros.ServicesLocator;
	using UnityEngine;
	using UnityEngine.EventSystems;

	public class OpenHoverPopupOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
	{
		#region Fields
		[SerializeField, SuffixLabel("optional")] private HoverPopupDataSO _toShowDataAsset = null;
		[SerializeField] private HoverPopupManager.HoverPopupPosition _popupPosition = HoverPopupManager.HoverPopupPosition.Top;

		private HoverPopupData _toShowData = null;

		private HoverPopupManager _hoverPopup = null;
		private RectTransform _rectTransform = null;
		private ICanvasRaycastFilter _canvasRaycastable = null;
		#endregion Fields

		#region Properties
		[ShowInRuntime] public HoverPopupData ToShowData { get => _toShowData; set => _toShowData = value; }
		#endregion Properties

		#region Methods
		void Awake()
		{
			_hoverPopup = Services.Instance.Get<HoverPopupManager>();
			_rectTransform = GetComponent<RectTransform>();
			_canvasRaycastable = GetComponent<ICanvasRaycastFilter>();

			if (_toShowDataAsset != null)
			{
				_toShowData = _toShowDataAsset.HoverPopupData;
			}
		}

		void OnEnable()
		{
			if (_canvasRaycastable != null && _canvasRaycastable.IsRaycastLocationValid(MouseHelper.CursorPosition, Camera.main))
			{
				Show();
			}
		}

		void OnDisable()
		{
			Hide();
		}

		private void Show()
		{
			if (_toShowData != null)
			{
				_hoverPopup.PopupPosition = _popupPosition;
				_hoverPopup.Show(_toShowData, _rectTransform);
			}
			else
			{
				Debug.LogWarning("Missing show data asset to open hover popup.", this);
			}
		}


		private void Hide()
		{
			if (_hoverPopup.HoverPopupData == _toShowData)
			{
				_hoverPopup.PopupPosition = _popupPosition;
				_hoverPopup.Hide();
			}
		}

		void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
		{
			Show();
		}

		void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
		{
			Hide();
		}
		#endregion Methods
	}
}
