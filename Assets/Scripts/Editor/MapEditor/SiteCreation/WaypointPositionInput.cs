namespace Tartaros.Map.Editor
{
	using UnityEngine;

	public class WaypointPositionInput
	{
		public Vector3 GetPositionUnderCursor()
		{
			Camera camera = Camera.current;

			if (camera == null) throw new System.NotSupportedException();

			// the Y position is flipped, so we have to account for that
			// we also have to account for parts above the "Scene" window
			Vector2 mousePosition = new Vector2(
			   Event.current.mousePosition.x,
			   Screen.height - (Event.current.mousePosition.y + 45)
			);

			Plane plane = new Plane(Vector3.up, 0 - camera.transform.position.z);
			Ray ray = camera.ScreenPointToRay(mousePosition);

			if (plane.Raycast(ray, out float distance))
			{
				Vector3 hitPoint = ray.GetPoint(distance);
				return hitPoint;
			}
			else
			{
				Debug.LogError("NOT SUPPORTED");
				return Vector3.zero;
			}
		}
	}
}
