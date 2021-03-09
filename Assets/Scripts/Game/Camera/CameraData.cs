namespace Tartaros.CameraSystem
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Tartaros.CameraSystem;

    public class CameraData : ScriptableObject
    {
        CameraZoomData _zoom = null;

        CameraKeyboardPanData _keyboardPan = null;

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