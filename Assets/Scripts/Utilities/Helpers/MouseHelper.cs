namespace Tartaros
{
	using UnityEngine;
	using UnityEngine.AI;
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

		public static GameObject GetGameObjectUnderCursorWithGrid()
		{
			var NearestPos = GetNearestPosition(CursorPosition.x, CursorPosition.y);

			Ray ray = Camera.main.ScreenPointToRay(NearestPos);

			if (Physics.Raycast(ray, out RaycastHit hit))
			{
				return hit.transform.gameObject;
			}

			return null;
		}

		private static Vector2 GetNearestPosition(float x, float z)
		{
			float xCount = Mathf.Round(x / 3);
			//float yCount = Mathf.Round(y / 3);
			float zCount = Mathf.Round(z / 3);

			Vector2 result = new Vector2(
				 xCount * 3,
				 zCount * 3);

			return result;
		}



		public static bool GetHitUnderCursor(out RaycastHit hit)
		{
			Ray ray = Camera.main.ScreenPointToRay(CursorPosition);
			return Physics.Raycast(ray, out hit);
		}

		public static Vector3 GetPositionOnGroundUnderCursor()
		{
			Ray ray = Camera.main.ScreenPointToRay(CursorPosition);
			RaycastHit hit;
			NavMeshHit navHit;

			Physics.Raycast(ray, out hit);

			Vector3 hitPointWithHeight = new Vector3(hit.point.x, hit.point.y + 2, hit.point.z);


			if (NavMesh.Raycast(hitPointWithHeight, Vector3.down * 10, out navHit, NavMesh.AllAreas))
			{
				return hit.point;
			}
			else
			{
				return NavMeshHelper.AdjustPositionToFitNavMesh(hit.point);
			}

		}
	}
}
