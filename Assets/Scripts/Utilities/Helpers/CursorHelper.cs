namespace Tartaros.Utilities
{
	using UnityEngine;
	using UnityEngine.InputSystem;

	public static class CursorHelper
	{
		public static Vector2 CursorPosition => Mouse.current.position.ReadValue();

		public static GameObject GetGameObjectUnderCursor()
		{			
			Ray ray = Camera.main.ScreenPointToRay(CursorPosition);

			if (Physics.Raycast(ray, out RaycastHit hit))
			{
				return hit.transform.gameObject;
			}

			return null;
		}
	}
}
