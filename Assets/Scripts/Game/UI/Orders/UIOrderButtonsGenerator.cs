namespace Tartaros.Orders
{
	using Sirenix.OdinInspector;
	using System;
	using System.Collections.Generic;
	using Tartaros.UI.HoverPopup;
	using UnityEngine;
	using UnityEngine.UI;

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

		#region Events
		public class AnyButtonClickedArgs : EventArgs { }
		public event EventHandler<AnyButtonClickedArgs> AnyButtonClicked = null;
		#endregion Events

		#region Methods		
		public void SetOrders(Order[] orders)
		{
			if (_destroyRootChildrenBeforeGeneration == true)
			{
				foreach (var buttonGameObject in _buttons)
				{
					buttonGameObject.GetComponent<Button>().onClick.RemoveListener(OnAnyButtonClicked);
				}

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
			GameObject buttonGameObject = GameObject.Instantiate(_prefabButton, _buttonsRoot);
			_buttons.Add(buttonGameObject);

			buttonGameObject.GetOrAddComponent<OrderButton>().Order = order;
			buttonGameObject.GetOrAddComponent<OpenHoverPopupOnHover>().ToShowData = order.HoverPopupData;
			var button = buttonGameObject.GetComponent<Button>();

			button.onClick.RemoveListener(OnAnyButtonClicked);
			button.onClick.AddListener(OnAnyButtonClicked);
		}

		private void OnAnyButtonClicked()
		{
			AnyButtonClicked?.Invoke(this, new AnyButtonClickedArgs());
		}
		#endregion Methods
	}
}
