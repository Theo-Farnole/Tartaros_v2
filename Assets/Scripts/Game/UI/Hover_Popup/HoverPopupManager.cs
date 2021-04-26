namespace Tartaros.UI.HoverPopup
{
	using TMPro;
	using UnityEngine;

	public class HoverPopupManager : MonoBehaviour
	{
		#region Fields
		[SerializeField]
		private GameObject _root = null;
		[SerializeField]
		private HoverPopupData _hoverPopupData = null;
		[SerializeField]
		private TextMeshProUGUI _name = null;
		[SerializeField]
		private TextMeshProUGUI _description = null;
		[SerializeField]
		private TextMeshProUGUI _costLabel = null;
		[SerializeField]
		private TextMeshProUGUI _cooldownLabel = null;
		#endregion Fields

		#region Properties
		public HoverPopupData HoverPopupData => _hoverPopupData;
		#endregion Properties

		#region Methods
		public void Show(HoverPopupData hoverPopupData, Vector3 hoveredCenterPosition)
		{
			_root.SetActive(true);

			if (_name != null)
			{
				_name.text = hoverPopupData.Name;
			}

			if (_description != null)
			{
				_description.text = hoverPopupData.Description;
			}

			if (_costLabel != null)
			{
				_costLabel.text = hoverPopupData.Cost;
			}

			if (_cooldownLabel != null)
			{
				_cooldownLabel.text = hoverPopupData.Cooldown;
			}
		}

		public void Hide()
		{
			_root.SetActive(false);
		}
		#endregion Methods
	}
}