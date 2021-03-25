namespace Tartaros.Construction
{
    using System.Collections;
    using UnityEngine;
    public class SetMousePositionWithPlane : IMousePosition
    {

        private Vector3 _planeDistanceFromCamera;
        private Plane _plane;
        private float _distanceZ = 40;
        private GameInputs _inputs = null;
        private float _offsetHeightMap = 0;

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

        private void InstanciatePlane()
        {
            _planeDistanceFromCamera = Vector3.zero;
            _plane = new Plane(Vector3.up, _planeDistanceFromCamera);
        }

        Vector3 IMousePosition.GetPreviewPosition()
        {
            return MousePositionOnGround();
        }
    }
}