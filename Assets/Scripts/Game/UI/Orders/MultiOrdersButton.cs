namespace Tartaros.UI
{
	using System.Linq;
	using Tartaros.Orders;
	using Tartaros.UI.HoverPopup;
	using UnityEngine;
	using UnityEngine.Assertions;
	using UnityEngine.UI;

	/// <summary>
	/// A button that have similar orders.
	/// </summary>
	[RequireComponent(typeof(Button))]
	public class MultiOrdersButton : MonoBehaviour
	{
		#region Fields
		[SerializeField] private Image _icon = null;
		[SerializeField] private OpenHoverPopupOnHover _openHoverPopupOnHover = null;

		private Order[] _orders = null;
		private Button _button = null;
		#endregion Fields

		#region Properties
		public Order[] Orders
		{
			get => _orders;

			set
			{
				_orders = value;

				Debug.Assert(DoOrdersHaveSamePortraits(), "The orders doesn't have the same orders.");
				SetIcon();
				SetHoverPopupToShow();
			}
		}
		#endregion Properties

		#region Methods
		private void Awake()
		{
			_button = GetComponent<Button>();
		}

		private void OnEnable()
		{
			_button.onClick.RemoveListener(OnButtonClick);
			_button.onClick.AddListener(OnButtonClick);
		}

		private void OnDisable()
		{
			_button.onClick.RemoveListener(OnButtonClick);
		}

		private void SetIcon()
		{
			Sprite portrait = _orders != null && _orders.Length > 0 ? _orders[0].Portrait : null;
			_icon.sprite = portrait;
		}

		private void SetHoverPopupToShow()
		{
			if (_orders.Length > 0)
			{
				_openHoverPopupOnHover.ToShowData = _orders[0].HoverPopupData;
			}
		}

		private bool DoOrdersHaveSamePortraits()
		{
			return _orders.GroupBy(x => x.Portrait).Count() == _orders.Length;
		}

		private void OnButtonClick()
		{
			if (_orders != null)
			{
				foreach (Order order in _orders)
				{
					order.Execute();
				}
			}
		}
		#endregion Methods
	}
}
