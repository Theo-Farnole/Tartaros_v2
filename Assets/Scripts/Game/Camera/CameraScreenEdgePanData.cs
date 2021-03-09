namespace Tartaros.CameraSystem
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class CameraScreenEdgePanData 
    {
        float _speed = 1;

        float _borderThickness = 0;

        public CameraScreenEdgePanData(float speed, float borderThickness)
        {
            _speed = speed;
            _borderThickness = borderThickness;
        }

        public float Speed => _speed;

        public float BorderThickness => _borderThickness;
    }
}