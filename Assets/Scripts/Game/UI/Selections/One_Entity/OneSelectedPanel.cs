namespace Tartaros.UI
{
	using System;
	using System.Linq;
	using Tartaros.Entities;
	using Tartaros.Map;
	using Tartaros.Orders;
	using Tartaros.Selection;
	using Tartaros.ServicesLocator;
	using UnityEngine;

	public class OneSelectedPanel : APanel
	{
		#region Fields
		private static readonly Type[] SIDE_BUTTONS_ORDER_TYPE = new Type[]
		{
			typeof(HealOrder),
			typeof(SelfKillOrder)
		};

		[SerializeField] private UIOrderButtonsGenerator _topButtons = null;
		[SerializeField] private UIOrderButtonsGenerator _sideButtons = null;
		[SerializeField] private RadialHealthSlider _radialHealthSlider = null;
		[SerializeField] private EntityInformationsUI _entityInformations = null;
		[SerializeField] private EntityAttackStatsUI _attacksStatsUI = null;

		private ISelection _currentSelection = null;
		private ISelectable _showSelectable = null;
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

			Entity.AnyEntityKilled -= Entity_AnyEntityKilled;
			Entity.AnyEntityKilled += Entity_AnyEntityKilled;
		}

		private void OnDisable()
		{
			Entity.AnyEntityKilled -= Entity_AnyEntityKilled;
			_currentSelection.SelectionChanged -= SelectionChanged;
		}

		private void Entity_AnyEntityKilled(object sender, Entity.EntityKilledArgs e)
		{
			if (IsShow && (sender as MonoBehaviour).GetComponent<ISelectable>() == _showSelectable)
			{
				Hide();
			}
		}

		private void SelectionChanged(object sender, SelectionChangedArgs e)
		{
			if (_currentSelection.ObjectsCount == 1)
			{
				ISelectable firstSelectable = _currentSelection.Objects[0];

				if ((firstSelectable as MonoBehaviour).GetComponent<ISector>() == null)
				{
					_showSelectable = firstSelectable;

					UpdatePanelInformations();
				}
			}
		}

		private void UpdatePanelInformations()
		{
			var showSelectableMonoBehaviour = _showSelectable as MonoBehaviour;
			var orders = showSelectableMonoBehaviour.gameObject.GenerateAvailablesOrders();

			_topButtons.SetOrders(GetTopButtons(orders));
			_sideButtons.SetOrders(GetSideButtons(orders));
			_radialHealthSlider.Healthable = showSelectableMonoBehaviour.GetComponent<IHealthable>();

			if (showSelectableMonoBehaviour.TryGetComponent(out Entity entity))
			{
				_entityInformations.Entity = entity;
				_attacksStatsUI.Entity = entity;
			}
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
			return SIDE_BUTTONS_ORDER_TYPE.Contains(order.GetType());
		}
		#endregion Methods
	}
}
