namespace Tartaros.UI.BlackBorders
{
	using Sirenix.OdinInspector;
	using Tartaros.UI.Dialog;
	using UnityEngine;

	public class BlackBordersPanel : APanel
	{
		[SerializeField, SceneObjectsOnly] private BlackBorder[] _blackBorders = new BlackBorder[0];		

		protected override void OnShow()
		{
			base.OnShow();

			ShowBlackBorder(true);
		}

		protected override void OnHide()
		{
			base.OnHide();

			ShowBlackBorder(false);
		}

		private void ShowBlackBorder(bool show)
		{
			foreach (var blackBorder in _blackBorders)
			{
				blackBorder.Show(show);
			}
		}
	}
}
