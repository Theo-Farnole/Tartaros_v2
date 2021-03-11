namespace Tartaros.CameraSystem
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    [System.Serializable]
    public class CameraScreenEdgePanData 
    {
        [SerializeField]
        float _speed = 1;
        [SerializeField]
        float _borderThickness = 3;

        public CameraScreenEdgePanData(float speed, float borderThickness)
        {
            _speed = speed;
            _borderThickness = borderThickness;
        }

        public float Speed => _speed;

        public float BorderThickness => _borderThickness;
    }
}