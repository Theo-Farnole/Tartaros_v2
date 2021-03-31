namespace Tartaros.UI.MiniMap
{
    using Tartaros.ServicesLocator;
    using UnityEngine;

    public class MiniMapIcon : MonoBehaviour, IMiniMapIcon
    {
        [SerializeField]
        private Sprite _icon = null;

        private MiniMap _miniMap = null;

        Vector3 IMiniMapIcon.WorldPosition => transform.position;

        Sprite IMiniMapIcon.Icon => _icon;

        private void Start()
        {
            _miniMap = Services.Instance.Get<MiniMap>();
            _miniMap.AddIcon(this);
        }

  
        void OnDisable()
        {
            _miniMap.RemoveIcon(this);
        }

        void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, 0.3f);
        }
    }
}