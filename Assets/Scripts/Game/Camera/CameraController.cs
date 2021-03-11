namespace Tartaros.CameraSystem
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Tartaros.CameraSystem;
    using Tartaros.Sectors;
    using Tartaros.ServicesLocator;
    using Tartaros.Utilities;


    [RequireComponent(typeof(Camera))]
    public class CameraController : MonoBehaviour
    {
        #region Fields
        //public GameInputs _input = null;
        private CameraData _cameraData = null;
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
        private void Start()
        {
            _Imap = Services.Instance.Get<IMap>();
        }


        private void Awake()
        {
            _camera = GetComponent<Camera>();
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
            ProccessZoom(deltaTime, ref deltaPosition);

            TranslateCamera(deltaPosition);
        }

        private void ProccessTranslateScreenEdge(float deltaTime, ref Vector3 deltaPosition)
        {

            if (Input.mousePosition.x >= Screen.width - _cameraData.CameraScreenEdgePan.BorderThickness)
                deltaPosition.x += _cameraData.CameraScreenEdgePan.Speed * deltaTime;

            if (Input.mousePosition.x <= _cameraData.CameraScreenEdgePan.BorderThickness)
                deltaPosition.x -= _cameraData.CameraScreenEdgePan.Speed * deltaTime;

            if (Input.mousePosition.y >= Screen.width - _cameraData.CameraScreenEdgePan.BorderThickness)
                deltaPosition.z += _cameraData.CameraScreenEdgePan.Speed * deltaTime;

            if (Input.mousePosition.y <= _cameraData.CameraScreenEdgePan.BorderThickness)
                deltaPosition.z -= _cameraData.CameraScreenEdgePan.Speed * deltaTime;
        }

        private void ProccessTranslateKeyboardInput(float deltaTime, ref Vector3 deltaPosition)
        {
            throw new System.NotImplementedException();
        }
        

        private void ProccessZoom(float deltaTime, ref Vector3 deltaPosition)
        {
            float inputDelta = Input.mouseScrollDelta.y;
            deltaPosition.y += inputDelta * deltaTime * _cameraData.CameraZoomData.ZoomSpeed;
        }

        private void TranslateCamera(Vector3 position)
        {
            Vector3 forward = transform.forward;
            Vector3 right = transform.right;
            Vector3 up = forward;

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