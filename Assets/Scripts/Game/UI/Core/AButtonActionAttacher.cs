namespace Tartaros.UI
{
	using Sirenix.OdinInspector;
	using System;
	using TMPro;
	using UnityEngine;
	using UnityEngine.UI;

	[RequireComponent(typeof(Button))]
	public abstract class AButtonActionAttacher : MonoBehaviour
	{
		#region Fields
		[SerializeField, SuffixLabel("optional")] private TextMeshProUGUI _label = null;

		private Button _button = null;
		#endregion Fields

		#region Properties
		public Button Button
		{
			get
			{
				if (_button == null)
				{
					_button = GetComponent<Button>();
				}

				return _button;
			}
		}
		#endregion Properties

		#region Events
		public class LateButtonClickedArgs : EventArgs { }
		/// <summary>
		/// Invoked after the button has done its stuff.
		/// </summary>
		public event EventHandler<LateButtonClickedArgs> LateButtonClicked = null;

		protected TextMeshProUGUI Label => _label;
		#endregion Events

		#region Methods
		private void OnEnable()
		{
			Button.onClick.RemoveListener(internal_OnButtonClick);
			Button.onClick.AddListener(internal_OnButtonClick);
		}

		private void OnDisable()
		{
			Button.onClick.RemoveListener(internal_OnButtonClick);
		}

		private void internal_OnButtonClick()
		{
			// make sure we d
			OnButtonClick();

			LateButtonClicked?.Invoke(this, new LateButtonClickedArgs());
		}

		protected abstract void OnButtonClick();
		#endregion Methods
	}
}
