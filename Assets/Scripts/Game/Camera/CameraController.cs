namespace Tartaros.CameraSystem
{
	using System;
	using Tartaros.Map;
	using Tartaros.ServicesLocator;
	using UnityEngine;
	using UnityEngine.InputSystem;

	[RequireComponent(typeof(Camera))]
	public class CameraController : MonoBehaviour
	{
		#region Fields
		[SerializeField] private CameraData _cameraData = null;
		[SerializeField] private Bounds2D _cameraMargins = null;

		private bool _enableScreenEdgeMovement = false;
		private bool _useUnscaledDeltaTime = false;

		private GameInputs _input = null;
		private Bounds2D _cameraBounds = null;

		// SERVICES
		private IMap _map = null;
		#endregion

		#region Properties
		private float DeltaTime => _useUnscaledDeltaTime ? Time.unscaledDeltaTime : Time.deltaTime;
		public bool UseUnscaledDeltaTime { get => _useUnscaledDeltaTime; set => _useUnscaledDeltaTime = value; }
		public bool EnableInputs
		{
			set
			{
				if (value == true)
				{
					_input.Camera.Enable();
				}
				else
				{
					_input.Camera.Disable();
				}
			}
		}
		#endregion Propeties

		#region Events
		public class DestinationReachedArgs : EventArgs
		{
			public readonly Vector3 destination = default;

			public DestinationReachedArgs(Vector3 destination)
			{
				this.destination = destination;
			}
		}

		public event EventHandler<DestinationReachedArgs> DestinationReached = null;
		#endregion Events

		#region Methods
		private void Awake()
		{
			_input = new GameInputs();
			_input.Camera.Enable();
			_enableScreenEdgeMovement = _cameraData.EnableScreenEdgeMovement;
		}

		private void Start()
		{
			_map = Services.Instance.Get<IMap>();

			_cameraBounds = _map.MapBounds;
			_cameraBounds.boundsX.min += _cameraMargins.boundsX.min;
			_cameraBounds.boundsX.max -= _cameraMargins.boundsX.max;

			_cameraBounds.boundsY.min += _cameraMargins.boundsY.min;
			_cameraBounds.boundsY.max -= _cameraMargins.boundsY.max;
		}

		private void Update()
		{
			MovementManager();
		}

		private void OnDrawGizmos()
		{
			if (_cameraBounds != null)
			{
				Vector3 center = new Vector3(_cameraBounds.CenterX, 1, _cameraBounds.CenterY);
				Vector3 size = new Vector3(_cameraBounds.boundsX.Size, 0, _cameraBounds.boundsY.Size);

				Gizmos.color = Color.red;
				Gizmos.DrawWireCube(center, size);
			}
		}

		private void MovementManager()
		{
			float deltaTime = DeltaTime;
			Vector3 deltaPosition = Vector3.zero;

			if (_enableScreenEdgeMovement)
			{
				ProccessTranslateScreenEdge(deltaTime, ref deltaPosition);
			}
			ProccessTranslateKeyboardInput(deltaTime, ref deltaPosition);
			ProccessZoom(deltaTime, ref deltaPosition);

			TranslateCamera(deltaPosition);
		}

		private void ProccessTranslateScreenEdge(float deltaTime, ref Vector3 deltaPosition)
		{

			if (_input.Camera.MousePosition.ReadValue<Vector2>().x >= Screen.width - _cameraData.BorderThickness)
				deltaPosition.x += _cameraData.SpeedEdgePan * deltaTime;

			if (_input.Camera.MousePosition.ReadValue<Vector2>().x <= _cameraData.BorderThickness)
				deltaPosition.x -= _cameraData.SpeedEdgePan * deltaTime;

			if (_input.Camera.MousePosition.ReadValue<Vector2>().y >= Screen.height - _cameraData.BorderThickness)
				deltaPosition.z += _cameraData.SpeedEdgePan * deltaTime;

			if (_input.Camera.MousePosition.ReadValue<Vector2>().y <= _cameraData.BorderThickness)
				deltaPosition.z -= _cameraData.SpeedEdgePan * deltaTime;
		}

		private void ProccessTranslateKeyboardInput(float deltaTime, ref Vector3 deltaPosition)
		{
			if (_input.Camera.Forward.phase == InputActionPhase.Performed)
				deltaPosition.z += _cameraData.SpeedKeyBoard * deltaTime;


			if (_input.Camera.Backward.phase == InputActionPhase.Performed)
				deltaPosition.z -= _cameraData.SpeedKeyBoard * deltaTime;


			if (_input.Camera.Right.phase == InputActionPhase.Performed)
				deltaPosition.x += _cameraData.SpeedKeyBoard * deltaTime;


			if (_input.Camera.Left.phase == InputActionPhase.Performed)
				deltaPosition.x -= _cameraData.SpeedKeyBoard * deltaTime;
		}


		private void ProccessZoom(float deltaTime, ref Vector3 deltaPosition)
		{
			if (MouseHelper.IsCursorOverWindow())
			{
				float inputDelta = _input.Camera.Zoom.ReadValue<Vector2>().y;
				deltaPosition.y += inputDelta * deltaTime * _cameraData.ZoomSpeed;
			}
		}

		private void TranslateCamera(Vector3 position)
		{
			Vector3 forward = new Vector3(transform.forward.x, 0, transform.forward.z);
			Vector3 right = transform.right;
			Vector3 up = transform.forward;

			Vector3 deltaForward = position.z * forward;
			Vector3 deltaRight = position.x * right;
			Vector3 deltaUp = position.y * up;

			// if zoom reach bounds, the camera continue to moves on Z/X axis without zooming.        
			if (transform.position.y + deltaUp.y > _cameraData.ZoomBounds.max || transform.position.y + deltaUp.y < _cameraData.ZoomBounds.min)
				deltaUp = Vector3.zero;

			Vector3 finalDelta = deltaForward + deltaRight + deltaUp;
			Vector3 finalPosition = transform.position + finalDelta;


			finalPosition = ClampMapBoundsMovement(finalPosition);

			transform.position = finalPosition;
		}

		private Vector3 ClampMapBoundsMovement(Vector3 finalPosition)
		{
			if (_map != null)
			{
				finalPosition.x = Mathf.Clamp(finalPosition.x, _cameraBounds.boundsX.min, _cameraBounds.boundsX.max);
				finalPosition.z = Mathf.Clamp(finalPosition.z, _cameraBounds.boundsY.min, _cameraBounds.boundsY.max);
				finalPosition.y = Mathf.Clamp(finalPosition.y, _cameraData.ZoomBounds.min, _cameraData.ZoomBounds.max);
			}
			return finalPosition;
		}

		private Vector3 ClampZoomBounds(Vector3 finalPosition)
		{
			//finalPosition.z = Mathf.Clamp(finalPosition.z, _cameraData.CameraZoomData.ZoomBounds.min, _cameraData.CameraZoomData.ZoomBounds.max);
			return finalPosition;
		}
		#endregion
	}
}