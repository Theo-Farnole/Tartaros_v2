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

        public CameraData(CameraZoomData zoom, CameraKeyboardPanData keyboardPan, CameraScreenEdgePanData cameraScreenEdgePan)
        {
            _zoom = zoom;
            _keyboardPan = keyboardPan;
            _cameraScreenEdgePan = cameraScreenEdgePan;
        }

        public CameraZoomData CameraZoomData => _zoom;
        public CameraKeyboardPanData KeyboardPan => _keyboardPan;
        public CameraScreenEdgePanData CameraScreenEdgePan => _cameraScreenEdgePan;

    }
}