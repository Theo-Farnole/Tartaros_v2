namespace Tartaros.Power
{
    using System.Collections;
    using System.Collections.Generic;
    using Tartaros.Editor;
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
            //HandlesHelper.DrawSolidCircle(position, Vector3.up, _rangeRadius, Color.red);
        }

        public void DestroyMethods()
        {
            GameObject.Destroy(_preview);
        }
    }
}