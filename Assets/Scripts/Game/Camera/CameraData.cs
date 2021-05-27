namespace Tartaros.CameraSystem
{
	using Sirenix.OdinInspector;
	using Sirenix.Serialization;
	using UnityEngine;
	using Tartaros.CameraSystem;

	public class CameraData : SerializedScriptableObject
	{
		[SerializeField] private float _speedKeyBoard = 1;
		[SerializeField] private float _speedEdgePan = 1;
		[SerializeField] private float _borderThickness = 3;
		[SerializeField] private Bounds1D _zoomBounds = default;
		[SerializeField] private float _zoomSpeed = 1;
		[SerializeField] private bool _enableScreenEdgeMovement = true;
		[SerializeField] private float _speedInCinematics = 3;


		public CameraData(float speedKeyBoard, float speedEdgePan, float borderThickness, Bounds1D zoomBounds, float zoomSpeed, bool enableScreenEdgeMovement)
		{
			_speedKeyBoard = speedKeyBoard;
			_speedEdgePan = speedEdgePan;
			_borderThickness = borderThickness;
			_zoomBounds = zoomBounds;
			_zoomSpeed = zoomSpeed;
		}

		public float SpeedKeyBoard => _speedKeyBoard;
		public float BorderThickness => _borderThickness;
		public float SpeedEdgePan => _speedEdgePan;
		public Bounds1D ZoomBounds => _zoomBounds;
		public float ZoomSpeed => _zoomSpeed;
		public bool EnableScreenEdgeMovement => _enableScreenEdgeMovement;
		public float SpeedInCinematics => _speedInCinematics;
	}
}