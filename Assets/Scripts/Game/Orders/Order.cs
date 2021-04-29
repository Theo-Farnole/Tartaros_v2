namespace Tartaros.Orders
{
	using System;
	using Tartaros.UI.HoverPopup;
	using UnityEngine;

	public class Order
	{
		#region Fields
		protected Action _executeAction = null;
		protected readonly Sprite _portrait = null;
		protected readonly HoverPopupData _hoverPopupData = null;
		#endregion Fields

		#region Properties
		public Sprite Portrait => _portrait;
		public HoverPopupData HoverPopupData => _hoverPopupData;
		#endregion Properties

		#region Ctor
		public Order(Sprite portrait, HoverPopupData hoverPopupData)
			: this(portrait, null, hoverPopupData)
		{ }

		public Order(Sprite portrait, Action executeAction, HoverPopupData hoverPopupData)
		{
			_executeAction = executeAction;
			_portrait = portrait;
			_hoverPopupData = hoverPopupData;
		}
		#endregion Ctor

		#region Methods
		public void Execute()
		{
			_executeAction?.Invoke();
		}
		#endregion Methods
	}
}
