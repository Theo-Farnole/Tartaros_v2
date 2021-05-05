namespace Tartaros.UI
{
	using UnityEngine;

	public class ClosePanelButton : AButtonActionAttacher
	{
		[SerializeField] private APanel _panel = null;

		protected override void OnButtonClick()
		{
			_panel.Hide();
		}
	}
}
