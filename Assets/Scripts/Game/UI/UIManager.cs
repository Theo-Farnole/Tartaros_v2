namespace Tartaros.UI
{
	using Tartaros.UI.BlackBorders;
	using UnityEngine;

	public class UIManager : MonoBehaviour
	{
		#region Fields
		[SerializeField] private BlackBordersPanel _blackBordersPanel = null;
		#endregion Fields

		#region Properties
		public BlackBordersPanel BlackBordersPanel => _blackBordersPanel;
		#endregion Properties

		#region Methods
		public void ShowBlackBorders()
		{
			_blackBordersPanel.Show();
		}

		public void HideBlackBorders()
		{
			_blackBordersPanel.Hide();
		}
		#endregion Methods
	}
}
