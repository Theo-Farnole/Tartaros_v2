namespace Tartaros.CameraSystem
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Tartaros.CameraSystem;
    using Tartaros.Sectors;
    using Tartaros.ServicesLocator;
    using Tartaros.Utilities;
    using UnityEngine.InputSystem;

    [RequireComponent(typeof(Camera))]
    public class CameraController : MonoBehaviour
    {
        #region Fields
        private GameInputs _input = null;
        public CameraData _cameraData = null;
        private Camera _camera = null;
        private IMap _Imap = null;


        #endregion

        #region Properties
        public CameraController(CameraData data, Camera camera)
        {
            _cameraData = data;
            _camera = camera;
        }
        #endregion

        #region Methods


        private void Awake()
        {
            _camera = GetComponent<Camera>();
            _input = new GameInputs();
            _input.Camera.Enable();
        }

        private void Start()
        {
            if (Services.HasInstance)
            {
                if (Services.Instance.TryGet<IMap>(out IMap map))
                {
                    _Imap = map;
                }
            }
        }

        private void Update()
        {
            MovementManager();
        }

        private void MovementManager()
        {
            float deltaTime = Time.deltaTime;
            Vector3 deltaPosition = Vector3.zero;

            ProccessTranslateScreenEdge(deltaTime, ref deltaPosition);
            ProccessTranslateKeyboardInput(deltaTime, ref deltaPosition);
            ProccessZoom(deltaTime, ref deltaPosition);

            TranslateCamera(deltaPosition);
        }

        private void ProccessTranslateScreenEdge(float deltaTime, ref Vector3 deltaPosition)
        {

            if (_input.Camera.MousePosition.ReadValue<Vector2>().x >= Screen.width - _cameraData.CameraScreenEdgePan.BorderThickness)
                deltaPosition.x += _cameraData.CameraScreenEdgePan.Speed * deltaTime;

            if (_input.Camera.MousePosition.ReadValue<Vector2>().x <= _cameraData.CameraScreenEdgePan.BorderThickness)
                deltaPosition.x -= _cameraData.CameraScreenEdgePan.Speed * deltaTime;

            if (_input.Camera.MousePosition.ReadValue<Vector2>().y >= Screen.height - _cameraData.CameraScreenEdgePan.BorderThickness)
                deltaPosition.z += _cameraData.CameraScreenEdgePan.Speed * deltaTime;

            if (_input.Camera.MousePosition.ReadValue<Vector2>().y <= _cameraData.CameraScreenEdgePan.BorderThickness)
                deltaPosition.z -= _cameraData.CameraScreenEdgePan.Speed * deltaTime;
        }

        private void ProccessTranslateKeyboardInput(float deltaTime, ref Vector3 deltaPosition)
        {
            if (_input.Camera.Forward.phase == InputActionPhase.Performed)
                deltaPosition.z += _cameraData.CameraScreenEdgePan.Speed * deltaTime;


            if (_input.Camera.Backward.phase == InputActionPhase.Performed)
                deltaPosition.z -= _cameraData.CameraScreenEdgePan.Speed * deltaTime;


            if (_input.Camera.Right.phase == InputActionPhase.Performed)
                deltaPosition.x += _cameraData.CameraScreenEdgePan.Speed * deltaTime;


            if (_input.Camera.Left.phase == InputActionPhase.Performed)
                deltaPosition.x -= _cameraData.CameraScreenEdgePan.Speed * deltaTime;
        }


        private void ProccessZoom(float deltaTime, ref Vector3 deltaPosition)
        {
            float inputDelta = _input.Camera.Zoom.ReadValue<Vector2>().y;
            deltaPosition.y += inputDelta * deltaTime * _cameraData.CameraZoomData.ZoomSpeed;
        }

        private void TranslateCamera(Vector3 position)
        {
            Vector3 forward = new Vector3(transform.forward.x, 0, transform.forward.z);
            Vector3 right = transform.right;
            Vector3 up = transform.forward;

            Vector3 deltaForward = position.z * forward;
            Vector3 deltaRight = position.x * right;
            Vector3 deltaUp = position.y * up;

            Vector3 finalDelta = deltaForward + deltaRight + deltaUp;
            Vector3 finalPosition = transform.position + finalDelta;

            finalPosition = ClampMapBounds(finalPosition);

            transform.position = finalPosition;
        }

        private Vector3 ClampMapBounds(Vector3 finalPosition)
        {
            if (_Imap != null)
            {
                finalPosition.x = Mathf.Clamp(finalPosition.x, _Imap.MapBounds.boundsX.min, _Imap.MapBounds.boundsX.max);
                finalPosition.y = Mathf.Clamp(finalPosition.y, _Imap.MapBounds.boundsY.min, _Imap.MapBounds.boundsY.max);
                finalPosition.z = Mathf.Clamp(finalPosition.z, _cameraData.CameraZoomData.ZoomBounds.min, _cameraData.CameraZoomData.ZoomBounds.max);
            }

            return finalPosition;
        }
        #endregion
    }
}