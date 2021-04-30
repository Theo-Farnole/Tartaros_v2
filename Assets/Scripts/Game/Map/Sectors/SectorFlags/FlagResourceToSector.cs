namespace Tartaros.Map
{
	using Tartaros.Economy;
	using Tartaros.ServicesLocator;
	using Tartaros.UI.MiniMap;
	using UnityEngine;

	[RequireComponent(typeof(SectorObject))]
	public class FlagResourceToSector : MonoBehaviour
	{
		#region Fields
		[SerializeField]
		private SectorRessourceType _type = SectorRessourceType.Food;

		private ResourceMiniMapIcon _miniMapIcon = null;
		#endregion Fields

		#region Properties
		public SectorRessourceType Type
		{
			get => _type;

			set
			{
				_type = value;
				_miniMapIcon.ResourceType = _type;
			}
		}
		#endregion Properties

		#region Methods
		private void Awake()
		{
			gameObject.GetOrAddComponent<SectorObject>();
			_miniMapIcon = gameObject.GetOrAddComponent<ResourceMiniMapIcon>();
			_miniMapIcon.ResourceType = _type;
		}

		private void OnDrawGizmos()
		{
			_type.DrawIcon(transform.position);
		}
		#endregion Methods
	}
}
