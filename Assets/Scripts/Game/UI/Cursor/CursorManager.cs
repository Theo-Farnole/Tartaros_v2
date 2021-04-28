using System.Collections;
using System.Collections.Generic;
using Tartaros;
using Tartaros.Entities;
using Tartaros.Gamemode;
using Tartaros.UI.Cursor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
	[SerializeField]
	private CursorManagerData _data = null;
	[SerializeField]
	private GamemodeManager _modeManger = null;


	private void Awake()
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

	private void OrderStateEnable(object sender, GamemodeManager.OrdersStateEnableArgs e)
	{
		Debug.Log("OrdersEnable");
	}

	private void PowerStateEnable(object sender, GamemodeManager.PowerStateEnableArgs e)
	{
		Debug.Log("PowerEnable");
	}

	private void DefaultStateEnable(object sender, GamemodeManager.DefaultStateEnableArgs e)
	{
		Debug.Log("DefaultEnable");
	}

	private void ConstructionStateEnable(object sender, GamemodeManager.ConstructionStateEnableArgs e)
	{
		Debug.Log("ConstructionEnable");
	}

	private void Update()
	{
		
	}

	private bool IsCursorHoverSelectable()
	{
		var underCursor = MouseHelper.GetGameObjectUnderCursor();

		return underCursor.TryGetComponent(out ISelectable selectable);
	}

	private void ChangeCursor(Texture2D sprite, Vector2 spot)
	{
		Cursor.SetCursor(sprite, spot, CursorMode.Auto);
	}
	private void Security()
	{
		if (_modeManger == null)
		{
			Debug.LogError("the field _modeManager is null");
		}

		if (_data == null)
		{
			//Debug.LogError("the field _data is null");
		}
	}
}
