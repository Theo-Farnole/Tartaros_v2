namespace Tartaros.UI
{
	using UnityEngine;
	using UnityEngine.UI;

	[RequireComponent(typeof(Button))]
	public abstract class AButtonActionAttacher : MonoBehaviour
	{
		#region Fields
		private Button _button = null;
		#endregion Fields

		#region Properties
		protected Button Button => _button;
		#endregion Properties

		#region Methods
		private void Awake()
		{
			_button = GetComponent<Button>();
		}

		private void OnEnable()
		{
			_button.onClick.RemoveListener(OnButtonClick);
			_button.onClick.AddListener(OnButtonClick);
		}

		private void OnDisable()
		{
			_button.onClick.RemoveListener(OnButtonClick);
		}

		protected abstract void OnButtonClick();
		#endregion Methods
	}
}
