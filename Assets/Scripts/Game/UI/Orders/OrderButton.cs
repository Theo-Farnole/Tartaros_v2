namespace Tartaros.Orders
{
	using UnityEngine;
	using UnityEngine.UI;

	[RequireComponent(typeof(Button))]
	public class OrderButton : MonoBehaviour
	{
		#region Fields
		private Order _order = null;
		private Button _button = null;
		#endregion Fields

		#region Properties
		public Order Order { get => _order; set => _order = value; }
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

		private void OnButtonClick()
		{
			if (_order == null)
			{
				_order.Execute();
			}
		}
		#endregion Methods
	}
}
