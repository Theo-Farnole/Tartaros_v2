namespace Tartaros.UI
{
	using UnityEngine;
	using UnityEngine.EventSystems;

	public class ShowCostOnPointerEnter : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
	{
		#region Fields
		[SerializeField] private GloryGemsManagerUI _gloryGemsManagerUI = null;
		[SerializeField] private int _gloryCost = 1;
		#endregion Fields

		#region Methods
		void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
		{
			_gloryGemsManagerUI.ShowCostPreview(_gloryCost);
		}

		void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
		{
			_gloryGemsManagerUI.HideCostPreview();
		}
		#endregion Methods
	}
}