namespace Tartaros.UI
{
	using Sirenix.OdinInspector;
	using System;
	using System.Linq;
	using Tartaros.Entities;
	using Tartaros.Orders;
	using Tartaros.Selection;
	using Tartaros.ServicesLocator;
	using UnityEngine;

	public class OneEntitySelectedPanel : APanel
	{
		#region Fields
		private static readonly Type[] SIDE_BUTTONS_ORDER_TYPE = new Type[]
		{
			typeof(HealOrder)
		};

		[SerializeField]
		private UIOrderButtonsGenerator _topButtons = null;

		[SerializeField]
		private UIOrderButtonsGenerator _sideButtons = null;

		[SerializeField]
		private RadialHealthSlider _radialHealthSlider = null;

		[SerializeField]
		private EntityInformationsUI _entityInformations = null;

		[SerializeField]
		private EntityAttackStatsUI _attacksStatsUI = null;

		private ISelection _currentSelection = null;
		#endregion Fields

		#region Methods
		protected override void Awake()
		{
			base.Awake();

			_currentSelection = Services.Instance.Get<CurrentSelection>();
		}

		private void OnEnable()
		{
			_currentSelection.SelectionChanged -= SelectionChanged;
			_currentSelection.SelectionChanged += SelectionChanged;
		}

		private void OnDisable()
		{
			_currentSelection.SelectionChanged -= SelectionChanged;
		}

		private void SelectionChanged(object sender, SelectionChangedArgs e)
		{
			if (_currentSelection.SelectedSelectables.Length == 1)
			{
				ISelectable firtSelectable = _currentSelection.SelectedSelectables[0];

				if (firtSelectable.GameObject.TryGetComponent(out Entity entity))
				{
					UpdatePanelInformations(entity);
					Show();
				}
			}
			else
			{
				Hide();
			}
		}

		private void UpdatePanelInformations(Entity entity)
		{
			var orders = entity.GenerateAvailablesOrders();

			foreach (var order in orders)
				Debug.Log(order.GetType());

			_topButtons.SetOrders(GetTopButtons(orders));
			_sideButtons.SetOrders(GetSideButtons(orders));
			_radialHealthSlider.Healthable = entity.GetComponent<IHealthable>();
			_entityInformations.Entity = entity;
			_attacksStatsUI.Entity = entity;
		}

		private Order[] GetTopButtons(Order[] orders)
		{
			return orders
				.Where(x => IsSideButtonOrder(x) == false)
				.ToArray();
		}

		private Order[] GetSideButtons(Order[] orders)
		{
			return orders
				.Where(x => IsSideButtonOrder(x) == true)
				.ToArray();
		}

		private bool IsSideButtonOrder(Order order)
		{
			return Array.IndexOf(SIDE_BUTTONS_ORDER_TYPE, order.GetType()) != -1;
		}
		#endregion Methods
	}
}
