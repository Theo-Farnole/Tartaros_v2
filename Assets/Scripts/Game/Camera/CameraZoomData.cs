namespace Tartaros.CameraSystem
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Tartaros.Utilities;
    using Tartaros.CameraSystem;

    [System.Serializable]
    public class CameraZoomData
    {
        [SerializeField]
        Bounds1D _zoomBounds = default;
        [SerializeField]
        float _zoomSpeed = 1;

        public CameraZoomData(Bounds1D zoomBoudns, float zoomSpeed)
        {
            _zoomBounds = zoomBoudns;
            _zoomSpeed = zoomSpeed;
        }

        public Bounds1D ZoomBounds => _zoomBounds;

        public float ZoomSpeed => _zoomSpeed;
    }
}