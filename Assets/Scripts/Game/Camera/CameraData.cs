namespace Tartaros.Camera
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Tartaros.Camera;

    public class CameraData : ScriptableObject
    {
        CameraZoomData _zoom = null;

        CameraKeyboardPanData _keyboardPan = null;

        CameraScreenEdgePanData _cameraScreenEdgePan = null;
    }
}