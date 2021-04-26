namespace Tartaros.UI.HoverPopup
{
	using Sirenix.OdinInspector;
	using Sirenix.Serialization;
	using UnityEngine;

	public class HoverPopupDataSO : SerializedScriptableObject
	{
		[OdinSerialize]
		private HoverPopupData _hoverPopupData = null;

		public HoverPopupData HoverPopupData => _hoverPopupData;
	}
}
