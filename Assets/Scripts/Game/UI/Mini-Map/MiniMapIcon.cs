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

        Sprite IMiniMapIcon.Icon => Icon;

		public Sprite Icon
		{
			get => _icon; set
			{
				_icon = value;
				RefreshIcon(); // when the icon is changed, it must be manually updated
			}
		}

		private void Awake()
        {
            _miniMap = Services.Instance.Get<MiniMap>();
        }

        void OnEnable()
		{
            _miniMap.AddIcon(this);
		}
  
        void OnDisable()
        {
            _miniMap.RemoveIcon(this);
        }

        private void RefreshIcon()
        {
            _miniMap.RemoveIcon(this);
            _miniMap.AddIcon(this);
        }

        //void OnDrawGizmos()
        //{
        //    Gizmos.color = Color.green;
        //    Gizmos.DrawWireSphere(transform.position, 0.3f);
        //}
    }
}