namespace Tartaros.Construction
{
	using System.Collections;
	using UnityEngine;
	public class SetMousePositionWithPlane : IMousePosition
	{

		private Vector3 _planeDistanceFromCamera;
		private Plane _plane;
		private GameInputs _inputs = null;
		private int _cellSize = 3;
		

		public SetMousePositionWithPlane()
		{
			_inputs = new GameInputs();
			_inputs.Camera.Enable();

			InstanciatePlane();
		}


		private Vector3 MousePositionOnGround()
		{
			Ray ray = Camera.main.ScreenPointToRay(_inputs.Camera.MousePosition.ReadValue<Vector2>());

			float enter = 0;
			if (_plane.Raycast(ray, out enter))
			{
				Vector3 hitPoint = ray.GetPoint(enter);
				return hitPoint;
			}
			else
			{
				return Vector3.zero;
			}
		}

		public Vector3 GetNearestPosition(Vector3 position)
		{
			return GetNearestPosition(position.x, position.y, position.z);
		}

		private Vector3 GetNearestPosition(float x, float y, float z)
		{
			float xCount = Mathf.Round(x / _cellSize);
			float yCount = Mathf.Round(y / _cellSize);
			float zCount = Mathf.Round(z / _cellSize);

			Vector3 result = new Vector3(
				 xCount * _cellSize,
				 yCount * _cellSize,
				 zCount * _cellSize);

			return result;
		}

		private void InstanciatePlane()
		{
			_planeDistanceFromCamera = Vector3.zero;
			_plane = new Plane(Vector3.up, _planeDistanceFromCamera);
		}

		Vector3 IMousePosition.GetPreviewPosition()
		{
			return GetNearestPosition(MousePositionOnGround());
		}
	}
}