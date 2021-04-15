namespace Tartaros.Orders
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;
	using Tartaros.Entities;
	using UnityEngine;

	public static class OrderGenerator
	{
		public static Order[] GenerateAvailablesOrders(this GameObject gameObject)
		{
			List<Order> outputOrders = new List<Order>();
			IOrderable[] orderables = gameObject.GetComponents<IOrderable>();

			foreach (IOrderable orderable in orderables)
			{
				if ((orderable as MonoBehaviour).enabled == true)
				{
					Order[] orderableOrders = orderable.GenerateOrders();

					if (orderableOrders != null)
					{
						outputOrders.AddRange(orderableOrders);
					}
				}
			}

			return outputOrders.ToArray();
		}
	}
}
