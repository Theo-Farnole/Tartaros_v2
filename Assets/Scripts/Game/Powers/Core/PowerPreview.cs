namespace Tartaros.Powers
{
	using UnityEngine;

	public class PowerPreview
    {
        private GameObject _preview = null;

        public PowerPreview(float rangeRadius, Vector3 positionToInstanciate)
        {

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
    }
}