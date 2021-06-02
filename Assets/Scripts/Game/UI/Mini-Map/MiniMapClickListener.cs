namespace Tartaros.UI.MiniMap
{
	using System.Collections;
	using UnityEngine;
	using UnityEngine.EventSystems;

	public class MiniMapClickListener : MonoBehaviour, IPointerClickHandler
	{
		private MiniMap _miniMap = null;

		private void Awake()
		{
			_miniMap = GetComponentInParent<MiniMap>();
		}


		void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
		{
			_miniMap.MoveCamera(eventData.position);
			Debug.Log(eventData.position);
		}
	}
}