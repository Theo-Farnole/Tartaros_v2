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
		private TextMeshProUGUI _name = null;
		[SerializeField]
		private TextMeshProUGUI _description = null;
		[SerializeField]
		private TextMeshProUGUI _costLabel = null;
		[SerializeField]
		private TextMeshProUGUI _cooldownLabel = null;

		private HoverPopupData _displayedHoverPopupData = null;
		#endregion Fields

		#region Properties
		public HoverPopupData HoverPopupData => _displayedHoverPopupData;
		#endregion Properties

		#region Methods
		public void Show(HoverPopupData hoverPopupData, Vector3 hoveredCenterPosition)
		{
			_root.SetActive(true);

			UpdateName(hoverPopupData);
			UpdateDescription(hoverPopupData);
			UpdateCost(hoverPopupData);
			UpdateCooldown(hoverPopupData);
		}

		private void UpdateCooldown(HoverPopupData hoverPopupData)
		{
			if (_cooldownLabel != null)
			{
				_cooldownLabel.gameObject.SetActive(hoverPopupData.HasCooldown);
				_cooldownLabel.text = hoverPopupData.Cooldown;
			}
		}

		private void UpdateCost(HoverPopupData hoverPopupData)
		{
			if (_costLabel != null)
			{
				_costLabel.gameObject.SetActive(hoverPopupData.HasCost);
				_costLabel.text = hoverPopupData.Cost;
			}
		}

		private void UpdateDescription(HoverPopupData hoverPopupData)
		{
			if (_description != null)
			{
				_description.gameObject.SetActive(hoverPopupData.HasDescription);
				_description.text = hoverPopupData.Description;
			}
		}

		private void UpdateName(HoverPopupData hoverPopupData)
		{
			if (_name != null)
			{
				_name.gameObject.SetActive(hoverPopupData.HasName);
				_name.text = hoverPopupData.Name;
			}
		}

		public void Hide()
		{
			_root.SetActive(false);
		}
		#endregion Methods
	}
}