namespace Tartaros.Map
{
	using Sirenix.OdinInspector;
	using Tartaros.Construction;
	using Tartaros.Economy;
	using Tartaros.Entities;
	using Tartaros.ServicesLocator;
	using UnityEngine;

	[RequireComponent(typeof(SectorObject))]
	public class BuildingSlot : SerializedMonoBehaviour
	{
		#region Fields
		[SerializeField] private ISectorResourcesWallet _constructionPrice = null;
		[SerializeField, SuffixLabel("get IConstructable from behaviour")] private EntityData _constructableEntity = null;

		private IConstructable _constructable = null;
		private bool _isAvailable = true;
		private IPlayerSectorResources _playerWallet = null;
		#endregion Fields

		#region Properties
		public bool IsAvailable => _isAvailable;
		public ISectorResourcesWallet ConstructionPrice => _constructionPrice;

		public IConstructable Constructable { get => _constructable; set => _constructable = value; }
		#endregion Properties

		#region Methods
		private void Awake()
		{
			_playerWallet = Services.Instance.Get<IPlayerSectorResources>();

			if (_constructableEntity != null && _constructable == null)
			{
				_constructable = _constructableEntity.GetBehaviour<IConstructable>();
			}
		}

		public bool CanConstruct()
		{
			if (_constructable == null) throw new System.NotSupportedException("Missing constructable in inspector.");

			return _isAvailable == true && _playerWallet.CanBuy(_constructionPrice);
		}

		public void Construct()
		{
			if (_constructable == null) throw new System.NotSupportedException("Missing constructable in inspector.");

			if (CanConstruct() == true)
			{
				_playerWallet.Buy(_constructionPrice);
				_constructable.InstantiateConstructionKit(transform.position);
				_isAvailable = false;
			}
		}

		private void OnDrawGizmos()
		{
			Gizmos.DrawIcon(transform.position, "gear-hammer.png");
		}
		#endregion Methods
	}
}
