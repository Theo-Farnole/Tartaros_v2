namespace Tartaros.UI.HoverPopup
{
	using Tartaros.ServicesLocator;
	using UnityEngine;
	using UnityEngine.EventSystems;

	public class OpenHoverPopupOnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
	{
		#region Fields
		private HoverPopupData _hoverPopupData = null;
		private HoverPopupManager _hoverPopup = null;
		#endregion Fields

		#region Methods
		void Awake()
		{
			_hoverPopup = Services.Instance.Get<HoverPopupManager>();
		}

		void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
		{
			_hoverPopup.Show(_hoverPopupData, transform.position);
		}

		void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
		{
			if (_hoverPopup.HoverPopupData == _hoverPopupData)
			{
				_hoverPopup.Hide();
			}
		}
		#endregion Methods
	}
}
