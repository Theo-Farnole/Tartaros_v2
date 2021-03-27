﻿namespace Tartaros.Utilities
{
	using UnityEngine;
	using UnityEngine.InputSystem;

	public static class MouseHelper
	{
		public static Vector2 CursorPosition => Mouse.current.position.ReadValue();

		public static bool IsCursorOverWindow()
		{
			if (Camera.main == null)
			{
				Debug.LogErrorFormat("Cannot get if cursor is over window. Missing camera with tag MainCamera.");
				return true;
			}

			var view = Camera.main.ScreenToViewportPoint(CursorPosition);
			return view.x >= 0 && view.x <= 1 && view.y >= 0 && view.y <= 1;
		}

		public static GameObject GetGameObjectUnderCursor()
		{
			Ray ray = Camera.main.ScreenPointToRay(CursorPosition);

			if (Physics.Raycast(ray, out RaycastHit hit))
			{
				return hit.transform.gameObject;
			}

			return null;
		}

		public static bool GetHitUnderCursor(out RaycastHit hit)
		{
			Ray ray = Camera.main.ScreenPointToRay(CursorPosition);
			return Physics.Raycast(ray, out hit);
		}
	}
}
