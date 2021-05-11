namespace Tartaros.UI.HoverPopup
{
	using Sirenix.OdinInspector;
	using Tartaros.ServicesLocator;
	using UnityEngine;
	using UnityEngine.EventSystems;

	public class OpenHoverPopupOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
	{
		#region Fields
		[SerializeField]
		[SuffixLabel("optional")]
		private HoverPopupDataSO _toShowDataAsset = null;

		[ShowInRuntime]
		private HoverPopupData _toShowData = null;
		private HoverPopupManager _hoverPopup = null;

		private RectTransform _rectTransform = null;
		#endregion Fields

		#region Properties
		public HoverPopupData ToShowData { get => _toShowData; set => _toShowData = value; }
		#endregion Properties

		#region Methods
		void Awake()
		{
			_hoverPopup = Services.Instance.Get<HoverPopupManager>();
			_rectTransform = GetComponent<RectTransform>();

			if (_toShowDataAsset != null)
			{
				_toShowData = _toShowDataAsset.HoverPopupData;
			}
		}

		void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
		{

			if (_toShowData != null)
			{
				_hoverPopup.Show(_toShowData, _rectTransform);
			}
			else
			{
				Debug.LogWarning("Missing show data asset to open hover popup.", this);
			}
		}

		void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
		{
			if (_hoverPopup.HoverPopupData == _toShowData)
			{
				_hoverPopup.Hide();
			}
		}
		#endregion Methods
	}
}
