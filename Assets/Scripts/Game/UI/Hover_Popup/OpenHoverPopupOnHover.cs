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

		private HoverPopupData _toShowData = null;
		private HoverPopupManager _hoverPopup = null;
		#endregion Fields

		#region Methods
		void Awake()
		{
			_hoverPopup = Services.Instance.Get<HoverPopupManager>();
			_toShowData = _toShowDataAsset.HoverPopupData;
		}

		void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
		{
			_hoverPopup.Show(_toShowData, transform.position);
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
