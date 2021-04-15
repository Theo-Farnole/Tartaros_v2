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
			typeof(HealOrder),
			typeof(SelfKillOrder)
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
		private Entity _showEntity = null;
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
			if (IsShow && sender as Entity == _showEntity)
			{
				Hide();
			}
		}

		private void SelectionChanged(object sender, SelectionChangedArgs e)
		{
			if (_currentSelection.SelectedSelectables.Length == 1)
			{
				ISelectable firtSelectable = _currentSelection.SelectedSelectables[0];

				if (firtSelectable.GameObject.TryGetComponent(out Entity entity))
				{
					_showEntity = entity;
					UpdatePanelInformations();
					Show();
				}
			}
			else
			{
				Hide();
			}
		}

		private void UpdatePanelInformations()
		{
			var orders = _showEntity.GenerateAvailablesOrders();

			foreach (var order in orders)
				Debug.Log(order.GetType());

			Debug.LogFormat("Side buttons length is {0}.", GetSideButtons(orders).Length);

			_topButtons.SetOrders(GetTopButtons(orders));
			_sideButtons.SetOrders(GetSideButtons(orders));
			_radialHealthSlider.Healthable = _showEntity.GetComponent<IHealthable>();
			_entityInformations.Entity = _showEntity;
			_attacksStatsUI.Entity = _showEntity;
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
