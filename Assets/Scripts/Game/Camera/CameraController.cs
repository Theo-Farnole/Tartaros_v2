namespace Tartaros.CameraSystem
{
	using Tartaros.Map;
	using Tartaros.ServicesLocator;
	using UnityEngine;
	using UnityEngine.InputSystem;

	[RequireComponent(typeof(Camera))]
	public class CameraController : MonoBehaviour
	{
		#region Fields
		[SerializeField]
		private CameraData _cameraData = null;

		private GameInputs _input = null;
		private Camera _camera = null;
		private IMap _Imap = null;
		private bool _enableScreenEdgeMovement = false;
		private bool _useUnscaledDeltaTime = false;
		private bool _isInFollowTargetMode = false;
		private Transform _targetDestination = null;
		#endregion

		#region Properties
		private float DeltaTime => _useUnscaledDeltaTime ? Time.unscaledDeltaTime : Time.deltaTime;
		public bool UseUnscaledDeltaTime { get => _useUnscaledDeltaTime; set => _useUnscaledDeltaTime = value; }
		#endregion Propeties

		#region Ctor
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
			_enableScreenEdgeMovement = _cameraData.EnableScreenEdgeMovement;
		}

		private void Start()
		{
			if (Services.Instance.TryGet<IMap>(out IMap map))
			{
				_Imap = map;
			}
		}

		private void Update()
		{
			if (_isInFollowTargetMode == false)
			{
				MovementManager();
			}
			else
			{
				FollowTargetTactical();
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
			if (_Imap != null)
			{
				finalPosition.x = Mathf.Clamp(finalPosition.x, _Imap.MapBounds.boundsX.min, _Imap.MapBounds.boundsX.max);
				finalPosition.z = Mathf.Clamp(finalPosition.z, _Imap.MapBounds.boundsY.min, _Imap.MapBounds.boundsY.max);
				finalPosition.y = Mathf.Clamp(finalPosition.y, _cameraData.ZoomBounds.min, _cameraData.ZoomBounds.max);
			}
			return finalPosition;
		}

		private Vector3 ClampZoomBounds(Vector3 finalPosition)
		{
			//finalPosition.z = Mathf.Clamp(finalPosition.z, _cameraData.CameraZoomData.ZoomBounds.min, _cameraData.CameraZoomData.ZoomBounds.max);
			return finalPosition;
		}

		public void SetCameraFollowTargetMode(bool mode)
		{
			_isInFollowTargetMode = mode;
		}

		public void SetCameraTarget(Transform target)
		{
			_targetDestination = target;
		}

		private void FollowTargetTactical()
		{
			float lerpRange = 10;
			var distanceToTarget = Vector3.Distance(transform.position, _targetDestination.position);
			Vector3 distanceBetweenCameraAndTarget = _targetDestination.position - transform.forward * distanceToTarget;
			transform.position = Vector3.Lerp(transform.position, distanceBetweenCameraAndTarget, lerpRange * DeltaTime);
		}
		#endregion
	}
}