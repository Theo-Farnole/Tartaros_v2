namespace Tartaros.Map
{
	using Sirenix.OdinInspector;
	using Tartaros.Economy;
	using Tartaros.ServicesLocator;
	using UnityEngine;

	public class BuildingSlot : SerializedMonoBehaviour
	{
		#region Fields
		[SerializeField] private ISectorResourcesWallet _constructionPrice = null;

		private bool _isAvailable = false;
		private IPlayerSectorResources _playerWallet = null;
		#endregion Fields

		#region Properties
		public bool IsAvailable => _isAvailable;
		public ISectorResourcesWallet ConstructionPrice => _constructionPrice;
		#endregion Properties

		#region Methods
		private void Awake()
		{
			_playerWallet = Services.Instance.Get<IPlayerSectorResources>();
		}

		public bool CanConstruct()
		{
			return _playerWallet.CanBuy(_constructionPrice);
		}

		public void Construct()
		{
			throw new System.NotImplementedException();
		}
		#endregion Methods
	}
}
