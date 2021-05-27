namespace Tartaros.UI
{
	using Sirenix.OdinInspector;
	using UnityEngine;

	public class APanel : MonoBehaviour
	{
		#region Fields
		[SerializeField]
		[SuffixLabel("self if null")]
		private Canvas _canvas = null;

		[SerializeField]
		private bool _showAtStart = true;
		#endregion Fields

		#region Properties
		public bool IsShow => _canvas.enabled;
		public bool IsHide => !IsShow;
		public Canvas Canvas => _canvas;
		#endregion Properties

		#region Methods

		protected virtual void Awake()
		{
			_canvas = GetComponent<Canvas>();

			if (_showAtStart == true)
			{
				Show();
			}
			else
			{
				Hide();
			}
		}

		public void Show()
		{
			if (IsShow) return;

			_canvas.enabled = true;
			OnShow();
		}

		public void Hide()
		{
			if (IsHide) return;

			_canvas.enabled = false;
			OnHide();
		}

		protected virtual void OnShow() { }
		protected virtual void OnHide() { }
		#endregion Methods
	}
}
