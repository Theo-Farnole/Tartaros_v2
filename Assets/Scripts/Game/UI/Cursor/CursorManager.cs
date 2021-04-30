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
	[SerializeField]
	private CursorManagerData _data = null;
	[SerializeField]
	private GamemodeManager _modeManger = null;

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


	private void OnEnable()
	{
		Security();

		_modeManger.DefaultStateEnable -= DefaultStateEnable;
		_modeManger.DefaultStateEnable += DefaultStateEnable;

		_modeManger.ConstructionStateEnable -= ConstructionStateEnable;
		_modeManger.ConstructionStateEnable += ConstructionStateEnable;

		_modeManger.PowerStateEnable -= PowerStateEnable;
		_modeManger.PowerStateEnable += PowerStateEnable;

		_modeManger.OrdersStateEnable -= OrderStateEnable;
		_modeManger.OrdersStateEnable += OrderStateEnable;
	}

	private void Start()
	{
		_enbaleState = gameModeState.defaultState;
		var cursorHotspot = new Vector2(_data.DefaultCursor.width / 2, _data.DefaultCursor.height / 2);
		ChangeCursor(_data.DefaultCursor, cursorHotspot);
	}

	private void OrderStateEnable(object sender, GamemodeManager.OrdersStateEnableArgs e)
	{
		Debug.Log("OrdersEnable");
		_enbaleState = gameModeState.ordersState;
		_ordersState = e.ordersState;
		_currentOrder = e.currentOrder;
	}

	private void PowerStateEnable(object sender, GamemodeManager.PowerStateEnableArgs e)
	{
		Debug.Log("PowerEnable");
		_enbaleState = gameModeState.powerState;
		_powerState = e.powerState;
	}

	private void DefaultStateEnable(object sender, GamemodeManager.DefaultStateEnableArgs e)
	{
		Debug.Log("DefaultEnable");
		_enbaleState = gameModeState.defaultState;
		_defaultState = e.defaultState;
	}

	private void ConstructionStateEnable(object sender, GamemodeManager.ConstructionStateEnableArgs e)
	{
		Debug.Log("ConstructionEnable");
		_enbaleState = gameModeState.constructionState;
		_constructionState = e.constructionState;
		_wallConstructionState = e.wallConstructionState;
	}

	private void Update()
	{
		Debug.Log(_enbaleState);

		SetCursorModel();
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
				cursorHotspot = SetHotspotCursor(_data.ConstructionCursor);
				ChangeCursor(_data.ConstructionCursor, cursorHotspot);
			}
			else
			{
				cursorHotspot = SetHotspotCursor(_data.ConstructionInvalideCursor);
				ChangeCursor(_data.ConstructionInvalideCursor, cursorHotspot);
			}
		}
		else if (_wallConstructionState != null)
		{
			if (_wallConstructionState.CanConstructHere() == true)
			{
				cursorHotspot = SetHotspotCursor(_data.ConstructionCursor);
				ChangeCursor(_data.ConstructionCursor, cursorHotspot);
			}
			else
			{
				cursorHotspot = SetHotspotCursor(_data.ConstructionInvalideCursor);
				ChangeCursor(_data.ConstructionInvalideCursor, cursorHotspot);
			}
		}
	}

	private void PowerStateCursorMethod()
	{
		if (_powerState != null)
		{
			var cursorHotspot = SetHotspotCursor(_data.PowerCursor);
			ChangeCursor(_data.PowerCursor, cursorHotspot);
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
					 cursorHotspot = SetHotspotCursor(_data.OrderCantMoveCursor);
					ChangeCursor(_data.OrderCantMoveCursor, cursorHotspot);
				}
				else
				{
					 cursorHotspot = SetHotspotCursor(_data.OrderMoveCursor);
					ChangeCursor(_data.OrderMoveCursor, cursorHotspot);
				}
			}
			else if (_currentOrder.GetType() == typeof(AttackOrder))
			{
				cursorHotspot = SetHotspotCursor(_data.OrderAttackCursor);
				ChangeCursor(_data.OrderAttackCursor, cursorHotspot);
			}
			else if (_currentOrder.GetType() == typeof(MoveAgressivelyOrder))
			{
				cursorHotspot = SetHotspotCursor(_data.OrderMoveAndAttackCursor);
				ChangeCursor(_data.OrderMoveAndAttackCursor, cursorHotspot);
			}
			else if (_currentOrder.GetType() == typeof(PatrolOrder))
			{
				cursorHotspot = SetHotspotCursor(_data.OrderPatrolCursor);
				ChangeCursor(_data.OrderPatrolCursor, cursorHotspot);
			}
		}
	}

	private void DefaultStateMethod()
	{
		if(IsUnitSelected() == true)
		{
			MouseHelper.GetHitUnderCursor(out RaycastHit hit);

			if(ObjectUnderCursorIsEnemy() == true)
			{
				var cursorHotspot = SetHotspotCursor(_data.OrderAttackCursor);
				ChangeCursor(_data.OrderAttackCursor, cursorHotspot);
				return;
			}

			if (NavMeshHelper.IsPositionOnNavMesh(hit.point) == false)
			{
				var cursorHotspot = SetHotspotCursor(_data.OrderCantMoveCursor);
				ChangeCursor(_data.OrderCantMoveCursor, cursorHotspot);
			}
			else
			{
				var cursorHotspot = SetHotspotCursor(_data.OrderMoveCursor);
				ChangeCursor(_data.OrderMoveCursor, cursorHotspot);
			}
		}
		else
		{
			if (IsCursorHoverSelectable() == false)
			{
				var cursorHotspot = SetHotspotCursor(_data.DefaultCursor);
				ChangeCursor(_data.DefaultCursor, cursorHotspot);
			}
			else
			{
				if (ObjectUnderCursorIsEnemy() == false)
				{
					var cursorHotspot = SetHotspotCursor(_data.DefaultCursorHoverable);
					ChangeCursor(_data.DefaultCursorHoverable, cursorHotspot);
				}
				else
				{
					var cursorHotspot = SetHotspotCursor(_data.DefaultCursorHoverableEnemy);
					ChangeCursor(_data.DefaultCursorHoverableEnemy, cursorHotspot);
				}
			}
		}
	}

	private bool IsUnitSelected()
	{
		ISelection currentSelectable = (Services.Instance.Get<CurrentSelection>() as ISelection);

		Entity entity = currentSelectable.SelectedSelectables
			.Select(x => (x as MonoBehaviour).GetComponent<Entity>())
			.Where(x => x != null)
			.FirstOrDefault();

		return entity != null && entity.Team == Team.Player;
	}

	private bool IsCursorHoverSelectable()
	{
		var underCursor = MouseHelper.GetGameObjectUnderCursor();

		return false;
		//return underCursor.TryGetComponentInParent(out ISelectable selectable);
	}

	private Vector2 SetHotspotCursor(Texture2D texture)
	{
		return new Vector2(texture.width / 2, texture.height / 2);
	}

	private bool ObjectUnderCursorIsEnemy()
	{
		var underCursor = MouseHelper.GetGameObjectUnderCursor();

		if (underCursor.TryGetComponentInParent(out Entity entity))
		{
			Debug.Log(entity);
			return entity.Team == Team.Enemy;
		}

		return false;
	}

	private void ChangeCursor(Texture2D sprite, Vector2 spot)
	{
		if (_currentCursor != sprite)
		{
			Cursor.SetCursor(sprite, spot, CursorMode.Auto);
			_currentCursor = sprite;
		}
	}

	private void Security()
	{
		if (_modeManger == null)
		{
			Debug.LogError("the field _modeManager is null");
		}

		if (_data == null)
		{
			Debug.LogError("the field _data is null");
		}
	}
}
