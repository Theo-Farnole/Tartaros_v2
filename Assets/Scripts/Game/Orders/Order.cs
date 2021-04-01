namespace Tartaros.Orders
{
	using System;
	using UnityEngine;

	public class Order
	{
		#region Fields
		protected readonly Action _executeAction = null;
		protected readonly Sprite _portrait = null;
		#endregion Fields

		#region Properties
		public Sprite Portrait => _portrait;
		#endregion Properties

		#region Ctor
		public Order(Sprite portrait, Action executeAction)
		{
			_executeAction = executeAction;
			_portrait = portrait;
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
