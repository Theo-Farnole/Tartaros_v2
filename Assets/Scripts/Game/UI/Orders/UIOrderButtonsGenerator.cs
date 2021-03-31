namespace Tartaros.Orders
{
	using System.Collections.Generic;
	using Tartaros.Entities;
	using UnityEngine;

	public class UIOrderButtonsGenerator : MonoBehaviour
	{
		#region Fields 		
		[SerializeField]
		private GameObject _prefabButton = null;

		[SerializeField]
		private RectTransform _buttonsRoot = null;

		[SerializeField]
		private bool _destroyRootChildrenBeforeGeneration = true;

		private List<GameObject> _buttons = new List<GameObject>();
		#endregion Fields

		#region Methods		
		public void GenerateButtons(Entity entity)
		{
			if (_destroyRootChildrenBeforeGeneration == true)
			{
				_buttonsRoot.DestroyChildren();
			}

			DestroyCurrentButtons();

			Order[] orders = entity.GenerateAvailablesOrders();

			foreach (Order order in orders)
			{
				GenerateButton(order);
			}

		}
		private void DestroyCurrentButtons()
		{
			foreach (var button in _buttons)
			{
				Destroy(button);
			}
		}

		private void GenerateButton(Order order)
		{
			GameObject button = GameObject.Instantiate(_prefabButton, _buttonsRoot);
			_buttons.Add(button);

			button.GetComponent<OrderButton>().Order = order;
		}
		#endregion Methods
	}
}
