namespace Tartaros.Powers
{
	using UnityEngine;
    
	public class PowerPreview : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _rangeSprite = null;

        private float _range = -1;

        // equivalent of constructor for MonoBehaviour
        public void Construct(float range)
		{
            _range = range;

            _rangeSprite.transform.localScale = _range * Vector3.one;
		}

        public void SetPreviewPosition(Vector3 position)
        {
            transform.position = position;
        }

        public void Destroy()
        {
            GameObject.Destroy(gameObject);
        }
    }
}