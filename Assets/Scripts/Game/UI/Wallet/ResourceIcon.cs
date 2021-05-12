namespace Tartaros.UI
{
	using Tartaros.Economy;
	using Tartaros.ServicesLocator;
	using UnityEngine;
	using UnityEngine.UI;

	public class ResourceIcon : MonoBehaviour
	{
		#region Fields
		[SerializeField] private SectorRessourceType _resourceType = default;
		[SerializeField] private Image _image = null;

		private IconsDatabase _iconsDatabase = null;
		#endregion Fields

		#region Properties
		public Image Image
		{
			get => _image;
			set
			{
				_image = value;
				SetSpriteIcon();
			}
		}
		public SectorRessourceType ResourceType
		{
			get => _resourceType;

			set
			{
				_resourceType = value;
				SetSpriteIcon();
			}
		}
		#endregion Properties

		#region Methods
		private void Awake()
		{
			_iconsDatabase = Services.Instance.Get<IconsDatabase>();
		}

		private void Start()
		{
			SetSpriteIcon();
		}

		private void SetSpriteIcon()
		{
			_image.sprite = _iconsDatabase.Data.GetResourceIcon(_resourceType);
		}
		#endregion Methods
	}
}
