namespace Tartaros.Orders
{
	using System;
	using UnityEngine;

	public class Order
	{
		#region Fields
		private readonly Action _executeAction = null;
		private readonly Sprite _portrait = null;
		#endregion Fields

		#region Properties
		public Sprite Portrait => _portrait;
		#endregion Properties

		#region Ctor
		public Order(Action executeAction, Sprite portrait)
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
