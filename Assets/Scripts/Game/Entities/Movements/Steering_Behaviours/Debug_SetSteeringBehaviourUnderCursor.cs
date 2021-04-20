namespace Tartaros.Entities.Movement
{
	using UnityEngine;

	public class Debug_SetSteeringBehaviourUnderCursor : MonoBehaviour
	{
		#region Methods
		private void Update()
		{
			Plane plane = new Plane(Vector3.up, Vector3.zero);
			Ray ray = Camera.main.ScreenPointToRay(MouseHelper.CursorPosition);

			if (plane.Raycast(ray, out float enter))
			{
				Vector3 rawPoint = ray.GetPoint(enter);
				Vector2 point = new Vector2(rawPoint.x, rawPoint.z);

				DrawEllipse(rawPoint, Vector3.up, Vector3.forward, 0.2f, 0.2f, 10, Color.white);

				foreach (var steeringBehaviourAgent in GameObject.FindObjectsOfType<SteeringBehaviourAgent>())
				{
					steeringBehaviourAgent.Destination = point;
				}
			}
		}

		private static void DrawEllipse(Vector3 pos, Vector3 forward, Vector3 up, float radiusX, float radiusY, int segments, Color color, float duration = 0)
		{
			float angle = 0f;
			Quaternion rot = Quaternion.LookRotation(forward, up);
			Vector3 lastPoint = Vector3.zero;
			Vector3 thisPoint = Vector3.zero;

			for (int i = 0; i < segments + 1; i++)
			{
				thisPoint.x = Mathf.Sin(Mathf.Deg2Rad * angle) * radiusX;
				thisPoint.y = Mathf.Cos(Mathf.Deg2Rad * angle) * radiusY;

				if (i > 0)
				{
					Debug.DrawLine(rot * lastPoint + pos, rot * thisPoint + pos, color, duration);
				}

				lastPoint = thisPoint;
				angle += 360f / segments;
			}
		}
		#endregion Methods
	}
}
