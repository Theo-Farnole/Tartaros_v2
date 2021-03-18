namespace TF.CheatsGUI
{
	using UnityEngine;

	[System.AttributeUsage(System.AttributeTargets.Method)]
	public class CheatMethodAttribute : System.Attribute
	{
		private readonly string _overridedButtonLabel = null;
		private readonly string _showIfExpressionIsTrue = null;

		public string OverridedButtonLabel => _overridedButtonLabel;
		public string ShowIfExpressionIsTrue => _showIfExpressionIsTrue;

		public CheatMethodAttribute() { }

		public CheatMethodAttribute(string showIfExpressionIsTrue)
		{
			_showIfExpressionIsTrue = showIfExpressionIsTrue;
		}

		public CheatMethodAttribute(string showIfExpressionIsTrue, string overridedButtonLabel) : this(showIfExpressionIsTrue)
		{
			_overridedButtonLabel = overridedButtonLabel;
		}
	}
}
