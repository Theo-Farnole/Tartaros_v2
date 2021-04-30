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
			_minimap.AddIcon(this);
		}

		void OnDisable()
		{
			_minimap.RemoveIcon(this);
		}

		void RefreshIcon()
		{
			RefreshCachedIcon();

			_minimap.AddIcon(this);
			_minimap.RemoveIcon(this);
		}

		private void RefreshCachedIcon()
		{
			_cachedIcon = _iconsDatabase.Data.GetResourceIcon(_resourceType);
		}
		#endregion Methods
	}
}
