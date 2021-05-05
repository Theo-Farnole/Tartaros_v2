namespace Tartaros.UI
{
	using UnityEngine;

	public class PausePanel : APanel
	{
		protected override void OnHide()
		{
			base.OnHide();

			Time.timeScale = 1;
		}

		protected override void OnShow()
		{
			base.OnShow();

			Time.timeScale = 0;
		}
	}
}
