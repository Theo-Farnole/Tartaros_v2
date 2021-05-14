namespace Tartaros.UI
{
	using UnityEngine;
	using UnityEngine.EventSystems;
	using UnityEngine.UIElements;

	public class ShowCostOnPointerEnter : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
	{
		#region Fields
		[SerializeField] private GloryGemsManagerUI _gloryGemsManagerUI = null;
		[SerializeField] private int _gloryCost = 1;
		#endregion Fields

		#region Properties
		public int GloryCost { get => _gloryCost; set => _gloryCost = value; } 
		#endregion Properties

		#region Methods
		void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
		{
			if (_gloryGemsManagerUI == null)
			{
				Debug.LogError("NullReferenceException: Glory gems has not be assigned in the inspector.", this);
				return;
			}

			_gloryGemsManagerUI.ShowCostPreview(_gloryCost);
		}

		void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
		{
			if (_gloryGemsManagerUI == null)
			{
				Debug.LogError("NullReferenceException: Glory gems has not be assigned in the inspector.", this);
				return;
			}

			_gloryGemsManagerUI.HideCostPreview();
		}
		#endregion Methods
	}
}