namespace Tartaros.CameraSystem
{
    using Sirenix.OdinInspector;
    using Sirenix.Serialization;
    using UnityEngine;
    using Tartaros.CameraSystem;

    public class CameraData : SerializedScriptableObject
    {
        [SerializeField]
        float _speedKeyBoard = 1;
		[SerializeField]
		float _speedEdgePan = 1;
		[SerializeField]
        float _borderThickness = 3;
        [SerializeField]
        Bounds1D _zoomBounds = default;
        [SerializeField]
        float _zoomSpeed = 1;
        [SerializeField]
        bool _enableScreenEdgeMovement = true;


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
    }
}