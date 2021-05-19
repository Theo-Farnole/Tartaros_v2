namespace Tartaros.UI.Sectors.Orders
{
	using System;

	public class SectorOrder
	{
		#region Fields
		private readonly string _buttonLabel = string.Empty;
		private readonly Action _onClick = null;
		private readonly Func<bool> _isAvailable = null;
		#endregion Fields

		#region Properties
		public string ButtonLabel => _buttonLabel;
		public bool IsAvailable => _isAvailable.Invoke();
		#endregion Properties

		#region Ctor
		public SectorOrder(string buttonLabel, Action onClick, Func<bool> isAvailable)
		{
			_buttonLabel = buttonLabel;
			_onClick = onClick ?? throw new ArgumentNullException(nameof(onClick));
			_isAvailable = isAvailable;
		}

		public void Execute()
		{
			_onClick.Invoke();
		}
		#endregion Ctor
	}
}