namespace Tartaros.CameraSystem
{
    using Sirenix.OdinInspector;
    using Sirenix.Serialization;
    using UnityEngine;
    using Tartaros.CameraSystem;

    public class CameraData : SerializedScriptableObject
    {
        [OdinSerialize]
        CameraZoomData _zoom = null;
        [OdinSerialize]
        CameraKeyboardPanData _keyboardPan = null;
        [OdinSerialize]
        CameraScreenEdgePanData _cameraScreenEdgePan = null;
        [OdinSerialize]
        bool _enableScreenEdgeMovement = true;

        public CameraData(CameraZoomData zoom, CameraKeyboardPanData keyboardPan, CameraScreenEdgePanData cameraScreenEdgePan, bool enableScreenEdgeMovement)
        {
            _zoom = zoom;
            _keyboardPan = keyboardPan;
            _cameraScreenEdgePan = cameraScreenEdgePan;
            _enableScreenEdgeMovement = enableScreenEdgeMovement;

        }

        public CameraZoomData CameraZoomData => _zoom;
        public CameraKeyboardPanData KeyboardPan => _keyboardPan;
        public CameraScreenEdgePanData CameraScreenEdgePan => _cameraScreenEdgePan;
        public bool EnableScreenEdgeMovement => _enableScreenEdgeMovement;

    }
}