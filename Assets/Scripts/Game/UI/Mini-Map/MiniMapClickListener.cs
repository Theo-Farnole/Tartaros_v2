namespace Tartaros.UI.MiniMap
{
	using System.Collections;
	using UnityEngine;
	using UnityEngine.EventSystems;

	public class MiniMapClickListener : MonoBehaviour, IPointerClickHandler, IPointerDownHandler
	{
		private MiniMap _miniMap = null;

		private void Awake()
		{
			_miniMap = GetComponentInParent<MiniMap>();
		}


		void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
		{
			 RectTransformUtility.ScreenPointToLocalPointInRectangle(this.GetComponent<RectTransform>(), eventData.pointerCurrentRaycast.screenPosition, eventData.pressEventCamera, out Vector2 localPoint);

			_miniMap.MoveCamera(localPoint);
		}

		void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
		{
			RectTransformUtility.ScreenPointToLocalPointInRectangle(this.GetComponent<RectTransform>(), eventData.pointerCurrentRaycast.screenPosition, eventData.pressEventCamera, out Vector2 localPoint);

			_miniMap.MoveCamera(localPoint);
		}
	}
}