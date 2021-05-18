namespace Tartaros.Orders
{
	using Sirenix.OdinInspector;
	using System.Collections.Generic;
	using Tartaros.UI.HoverPopup;
	using UnityEngine;

	public class UIOrderButtonsGenerator : MonoBehaviour
	{
		#region Fields 		
		[Title("References")]
		[SerializeField] private RectTransform _buttonsRoot = null;
		[SerializeField] private GameObject _prefabButton = null;
		[SerializeField] private GameObject _prefabLockedButton = null;

		[Title("Settings")]
		[SerializeField] private bool _destroyRootChildrenBeforeGeneration = true;
		[SerializeField] private int _buttonsCount = 2;

		private List<GameObject> _buttons = new List<GameObject>();
		#endregion Fields

		#region Methods		
		public void SetOrders(Order[] orders)
		{
			if (_destroyRootChildrenBeforeGeneration == true)
			{
				_buttonsRoot.DestroyChildren();
			}

			DestroyCurrentButtons();

			for (int i = 0; i < _buttonsCount; i++)
			{
				if (i < orders.Length)
				{
					GenerateButton(orders[i]);
				}
				else
				{
					GenerateLockedButton();
				}
			}

		}

		private void DestroyCurrentButtons()
		{
			foreach (var button in _buttons)
			{
				Destroy(button);
			}

			_buttons.Clear();
		}

		private void GenerateLockedButton()
		{
			if (_prefabLockedButton == null) return;

			GameObject button = GameObject.Instantiate(_prefabLockedButton, _buttonsRoot);
			_buttons.Add(button);
		}

		private void GenerateButton(Order order)
		{
			GameObject button = GameObject.Instantiate(_prefabButton, _buttonsRoot);
			_buttons.Add(button);

			button.GetOrAddComponent<OrderButton>().Order = order;
			button.GetOrAddComponent<OpenHoverPopupOnHover>().ToShowData = order.HoverPopupData;
		}
		#endregion Methods
	}
}
