namespace Tartaros.UI
{
	using Sirenix.OdinInspector;
	using System.Collections.Generic;
	using Tartaros.Entities;
	using Tartaros.Orders;
	using Tartaros.Selection;
	using Tartaros.ServicesLocator;
	using UnityEngine;
	using UnityEngine.UI;

	public class MultiEntitiesSelectedPanel : APanel
	{
		#region Fields
		[SerializeField, Required] private RectTransform _portraitsRoot = null;
		[SerializeField, Required] private GameObject _prefabPortrait = null;

		[Title("Buttons")]
		[SerializeField, Required] private MultiOrdersButton _killButton = null;
		[SerializeField, Required] private MultiOrdersButton _moveButton = null;
		[SerializeField, Required] private MultiOrdersButton _attackButton = null;
		[SerializeField, Required] private MultiOrdersButton _moveAggressively = null;
		[SerializeField, Required] private MultiOrdersButton _patrolButton = null;

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
			if (_currentSelection.ObjectsCount > 1)
			{
				UpdateInformations(_currentSelection.Objects);
			}
		}

		void UpdateInformations(ISelectable[] selectables)
		{
			_portraitsRoot.DestroyChildren();

			List<SelfKillOrder> selfKillOrders = new List<SelfKillOrder>(selectables.Length);
			List<MoveOrder> moveOrders = new List<MoveOrder>(selectables.Length);
			List<MoveAgressivelyOrder> moveAgressivelyOrders = new List<MoveAgressivelyOrder>(selectables.Length);
			List<PatrolOrder> patrolOrders = new List<PatrolOrder>(selectables.Length);
			List<AttackOrder> attackOrders = new List<AttackOrder>(selectables.Length);

			foreach (ISelectable selected in selectables)
			{
				if (selected.GameObject.TryGetComponent(out Entity entity))
				{
					GameObject portrait = Instantiate(_prefabPortrait);
					portrait.transform.SetParent(_portraitsRoot);
					portrait.transform.localScale = Vector3.one;
					portrait.GetComponent<MultiSelectedEntityPortrait>().Entity = entity;

					selfKillOrders.Add(new SelfKillOrder(entity));
					attackOrders.Add(new AttackOrder(entity));

					if (entity.TryGetComponent(out EntityMovement entityMovement))
					{
						moveOrders.Add(new MoveOrder(entityMovement));
						moveAgressivelyOrders.Add(new MoveAgressivelyOrder(entityMovement));
						patrolOrders.Add(new PatrolOrder(entityMovement));
					}
				}
				else
				{
					Debug.LogWarningFormat("Skipping to display entity {0}'s portrait because it is not an Entity.", selected.ToString());
				}
			}

			_killButton.Orders = selfKillOrders.ToArray();
			_moveButton.Orders = moveOrders.ToArray();
			_moveAggressively.Orders = moveAgressivelyOrders.ToArray();
			_patrolButton.Orders = patrolOrders.ToArray();
			_attackButton.Orders = attackOrders.ToArray();
		}
		#endregion Methods
	}
}
