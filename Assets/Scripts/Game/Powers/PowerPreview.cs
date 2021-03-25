namespace Tartaros.Power
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class PowerPreview
    {
        private float _rangeRadius = 1;
        private Vector3 _position = Vector3.zero;
        private GameObject _preview = null;

        public PowerPreview(float rangeRadius, Vector3 positionToInstanciate)
        {
            _rangeRadius = rangeRadius;

            _preview = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        }

        public void SetPreviewPosition(Vector3 position)
        {
            _preview.transform.position = position;
        }

        public void DestroyMethods()
        {
            GameObject.Destroy(_preview);
        }

        public void Debug()
        {

        }
    }
}