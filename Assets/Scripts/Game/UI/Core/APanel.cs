namespace Tartaros.UI
{
	using UnityEngine;

	[RequireComponent(typeof(Canvas))]
	public class APanel : MonoBehaviour
	{
		#region Fields
		private Canvas _canvas = null;
		#endregion Fields

		#region Properties
		public bool IsShow => _canvas.enabled;
		#endregion Properties

		#region Methods

		private void Awake()
		{
			_canvas = GetComponent<Canvas>();
		}

		public void Show()
		{
			_canvas.enabled = true;
		}

		public void Hide()
		{
			_canvas.enabled = false;
		}
		#endregion Methods
	}
}
