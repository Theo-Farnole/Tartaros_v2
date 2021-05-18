namespace Tartaros.Map
{
	using System;
	using Tartaros.Economy;
	using Tartaros.ServicesLocator;
	using Tartaros.UI.MiniMap;
	using UnityEngine;

	public class ResourceMiniMapIcon : MonoBehaviour, IMiniMapIcon
	{
		#region Fields
		private SectorRessourceType _resourceType = SectorRessourceType.Food;

		private Sprite _cachedIcon = null;

		private MiniMap _minimap = null;
		private IconsDatabase _iconsDatabase = null;
		#endregion Fields

		#region Properties
		public SectorRessourceType ResourceType
		{
			get => _resourceType;

			set
			{
				_resourceType = value;
				RefreshIcon();
			}
		}

		Vector3 IMiniMapIcon.WorldPosition => transform.position;

		Sprite IMiniMapIcon.Icon => _cachedIcon;
		#endregion Properties

		#region Methods
		void Awake()
		{
			_minimap = Services.Instance.Get<MiniMap>();
			_iconsDatabase = Services.Instance.Get<IconsDatabase>();

			RefreshCachedIcon();
		}

		void OnEnable()
		{
			_minimap.AddIcon(this, Vector2.one * 25);
		}

		void OnDisable()
		{
			_minimap.RemoveIcon(this);
		}

		void RefreshIcon()
		{
			RefreshCachedIcon();

			_minimap.RemoveIcon(this);
			_minimap.AddIcon(this, Vector2.one * 25);
		}

		private void RefreshCachedIcon()
		{
			_cachedIcon = _iconsDatabase.Data.GetResourceIcon(_resourceType);
		}
		#endregion Methods
	}
}
