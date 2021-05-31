using System;
using System.Linq;
using Tartaros;
using Tartaros.Construction;
using Tartaros.Entities;
using Tartaros.Gamemode;
using Tartaros.Gamemode.State;
using Tartaros.Orders;
using Tartaros.Selection;
using Tartaros.ServicesLocator;
using Tartaros.UI.Cursor;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
	[SerializeField] private CursorManagerData _data = null;
	
	private GamemodeManager _gamemodeManager = null;

	private enum gameModeState
	{
		defaultState,
		constructionState,
		powerState,
		ordersState
	}

	private gameModeState _enbaleState = gameModeState.defaultState;
	private Texture2D _currentCursor = null;
	private ConstructionState _constructionState = null;
	private WallConstructionState _wallConstructionState = null;
	private PlayState _defaultState = null;
	private PowerState _powerState = null;
	private CatchRightClickState _ordersState = null;
	private Order _currentOrder = null;

	private void Awake()
	{
		_gamemodeManager = Services.Instance.Get<GamemodeManager>();
	}

	private void OnEnable()
	{
		CheckForMissingScripts();

		_gamemodeManager.DefaultStateEnable -= DefaultStateEnable;
		_gamemodeManager.DefaultStateEnable += DefaultStateEnable;

		_gamemodeManager.ConstructionStateEnable -= ConstructionStateEnable;
		_gamemodeManager.ConstructionStateEnable += ConstructionStateEnable;

		_gamemodeManager.PowerStateEnable -= PowerStateEnable;
		_gamemodeManager.PowerStateEnable += PowerStateEnable;

		_gamemodeManager.OrdersStateEnable -= OrderStateEnable;
		_gamemodeManager.OrdersStateEnable += OrderStateEnable;
	}

	private void Start()
	{
		_enbaleState = gameModeState.defaultState;
		var cursorHotspot = new Vector2(_data.DefaultCursor.width / 2, _data.DefaultCursor.height / 2);
		ChangeCursor(_data.DefaultCursor);
	}

	private void OrderStateEnable(object sender, GamemodeManager.OrdersStateEnableArgs e)
	{
		_enbaleState = gameModeState.ordersState;
		_ordersState = e.ordersState;
		_currentOrder = e.currentOrder;
	}

	private void PowerStateEnable(object sender, GamemodeManager.PowerStateEnableArgs e)
	{
		_enbaleState = gameModeState.powerState;
		_powerState = e.powerState;
	}

	private void DefaultStateEnable(object sender, GamemodeManager.DefaultStateEnableArgs e)
	{
		_enbaleState = gameModeState.defaultState;
		_defaultState = e.defaultState;
	}

	private void ConstructionStateEnable(object sender, GamemodeManager.ConstructionStateEnableArgs e)
	{
		_enbaleState = gameModeState.constructionState;
		_constructionState = e.constructionState;
		_wallConstructionState = e.wallConstructionState;
	}

	private void Update()
	{
		if(MouseHelper.IsCursorOverWindow() == true)
		{
			SetCursorModel();
		}
	}

	private void SetCursorModel()
	{
		if (_enbaleState == gameModeState.constructionState)
		{
			ConstructionCursorMethod();
		}

		if (_enbaleState == gameModeState.powerState)
		{
			PowerStateCursorMethod();
		}

		if (_enbaleState == gameModeState.ordersState)
		{
			OrderStateCursorMethod();
		}

		if (_enbaleState == gameModeState.defaultState)
		{
			DefaultStateMethod();
		}
	}

	private void ConstructionCursorMethod()
	{
		Vector2 cursorHotspot = Vector2.zero;
		if (_constructionState != null)
		{

			if (_constructionState.CanConstructHere() == true)
			{
				ChangeCursor(_data.ConstructionCursor);
			}
			else
			{
				ChangeCursor(_data.ConstructionInvalideCursor);
			}
		}
		else if (_wallConstructionState != null)
		{
			if (_wallConstructionState.CanConstructHere() == true)
			{
				ChangeCursor(_data.ConstructionCursor);
			}
			else
			{
				ChangeCursor(_data.ConstructionInvalideCursor);
			}
		}
	}

	private void PowerStateCursorMethod()
	{
		if (_powerState != null)
		{
			ChangeCursor(_data.PowerCursor);
		}
	}

	private void OrderStateCursorMethod()
	{
		if (_ordersState != null)
		{
			Vector2 cursorHotspot = Vector2.zero;

			if (_currentOrder.GetType() == typeof(MoveOrder))
			{
				MouseHelper.GetHitUnderCursor(out RaycastHit hit);

				if (NavMeshHelper.IsPositionOnNavMesh(hit.point) == false)
				{
					ChangeCursor(_data.OrderCantMoveCursor);
				}
				else
				{
					ChangeCursor(_data.OrderMoveCursor);
				}
			}
			else if (_currentOrder.GetType() == typeof(AttackOrder))
			{
				ChangeCursor(_data.OrderAttackCursor);
			}
			else if (_currentOrder.GetType() == typeof(MoveAgressivelyOrder))
			{
				ChangeCursor(_data.OrderMoveAndAttackCursor);
			}
			else if (_currentOrder.GetType() == typeof(PatrolOrder))
			{
				ChangeCursor(_data.OrderPatrolCursor);
			}
		}
	}

	private void DefaultStateMethod()
	{
		if (IsUnitSelected() == true)
		{
			MouseHelper.GetHitUnderCursor(out RaycastHit hit);

			if (ObjectUnderCursorIsEnemy() == true)
			{
				ChangeCursor(_data.OrderAttackCursor);
				return;
			}

			if (NavMeshHelper.IsPositionOnNavMesh(hit.point) == false)
			{
				ChangeCursor(_data.OrderCantMoveCursor);
			}
			else
			{
				ChangeCursor(_data.OrderMoveCursor);
			}
		}
		else
		{
			if (IsCursorHoverSelectable() == false)
			{
				ChangeCursor(_data.DefaultCursor);
			}
			else
			{
				if (ObjectUnderCursorIsEnemy() == false)
				{
					ChangeCursor(_data.DefaultCursorHoverable);
				}
				else
				{
					ChangeCursor(_data.DefaultCursorHoverableEnemy);
				}
			}
		}
	}

	private bool IsUnitSelected()
	{
		ISelection currentSelectable = (Services.Instance.Get<CurrentSelection>() as ISelection);

		Entity entity = currentSelectable.Objects
			.Select(x => (x as MonoBehaviour).GetComponent<Entity>())
			.Where(x => x != null)
			.FirstOrDefault();

		return entity != null && entity.Team == Team.Player && entity.EntityType == EntityType.Unit;
	}

	private bool IsCursorHoverSelectable()
	{
		var underCursor = MouseHelper.GetGameObjectUnderCursor();

		return false;
		//return underCursor.TryGetComponentInParent(out ISelectable selectable);
	}

	private bool ObjectUnderCursorIsEnemy()
	{
		var underCursor = MouseHelper.GetGameObjectUnderCursor();

		if (underCursor.TryGetComponentInParent(out Entity entity))
		{
			return entity.Team == Team.Enemy;
		}

		return false;
	}

	private void ChangeCursor(Texture2D sprite)
	{
		if (_currentCursor != sprite)
		{
			Cursor.SetCursor(sprite, new Vector2(0, 0), CursorMode.Auto);
			_currentCursor = sprite;
		}
	}

	private void CheckForMissingScripts()
	{
		if (_gamemodeManager == null)
		{
			Debug.LogError("the field _modeManager is null");
		}

		if (_data == null)
		{
			Debug.LogError("the field _data is null");
		}
	}
}
