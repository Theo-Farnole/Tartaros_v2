namespace Tartaros
{
	using System;
	using Tartaros.Construction;
	using UnityEngine;

	public class SnapMousePositionOnPlane : IMousePosition
	{
		#region Fields
		private readonly Plane _plane;
		private readonly GameInputs _inputs = null;
		#endregion Fields

		#region Ctor
		public SnapMousePositionOnPlane()
		{
			_inputs = new GameInputs();
			_inputs.Camera.Enable();

			_plane = new Plane(Vector3.up, Vector3.zero);
		}
		#endregion Ctor

		#region Methods
		private Vector3 MousePositionOnGround()
		{
			Ray ray = Camera.main.ScreenPointToRay(_inputs.Camera.MousePosition.ReadValue<Vector2>());

			if (_plane.Raycast(ray, out float enter))
			{
				Vector3 hitPoint = ray.GetPoint(enter);
				return hitPoint;
			}
			else
			{
				return Vector3.zero;
			}
		}

		Vector3 IMousePosition.GetPreviewPosition()
		{
			return MousePositionOnGround();
		}
		#endregion Methods
	}
}
