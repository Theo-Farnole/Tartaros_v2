namespace Tartaros.CameraSystem
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    [System.Serializable]
    public class CameraKeyboardPanData
    {
        [SerializeField]
        float _speed = 1;

        public CameraKeyboardPanData(float speed)
        {
            _speed = speed;
        }

        public float Speed => _speed;
    }
}