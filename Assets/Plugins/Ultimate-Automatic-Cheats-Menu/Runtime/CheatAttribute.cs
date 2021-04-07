namespace TF.CheatsGUI
{
	[System.AttributeUsage(System.AttributeTargets.Method)]
	public class CheatAttribute : System.Attribute
	{
		private readonly string _overridedButtonLabel = null;
		private readonly string _showIfExpressionIsTrue = null;

		public string OverridedButtonLabel => _overridedButtonLabel;
		public string ShowIfExpressionIsTrue => _showIfExpressionIsTrue;

		public CheatAttribute() { }

		public CheatAttribute(string showIfExpressionIsTrue)
		{
			_showIfExpressionIsTrue = showIfExpressionIsTrue;
		}

		public CheatAttribute(string showIfExpressionIsTrue, string overridedButtonLabel) : this(showIfExpressionIsTrue)
		{
			_overridedButtonLabel = overridedButtonLabel;
		}
	}
}
