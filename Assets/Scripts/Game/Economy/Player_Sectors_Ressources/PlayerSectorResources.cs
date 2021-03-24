namespace Tartaros.Economy
{
	using ServicesLocator;
	using System;
	using UnityEngine;

	public class PlayerSectorResources : MonoBehaviour, IPlayerSectorResources
	{
		#region Fields
		[SerializeField]
		private PlayerSectorResourcesData _playerSectorRessourcesData = null;

		private ISectorResourcesWallet _playerWallet = null;
		#endregion Fields

		#region Properties
		event EventHandler<AmountChangedArgs> ISectorResourcesWallet.AmountChanged
		{
			add
			{
				_playerWallet.AmountChanged += value;
			}

			remove
			{
				_playerWallet.AmountChanged -= value;
			}
		}
		#endregion Properties

		#region Methods
		private void Awake()
		{
			if (_playerSectorRessourcesData != null)
			{
				_playerWallet = (_playerSectorRessourcesData.StartingIncome as ICloneable).Clone() as ISectorResourcesWallet;
			}
			else
			{
				Debug.LogWarning("Missing _playerSectorResourcesData field in inspector. Default wallet is equals to zero.");
				_playerWallet = SectorResourcesWallet.Zero;
			}

			Services.Instance.RegisterService<IPlayerSectorResources>(this);
		}

		int ISectorResourcesWallet.GetAmount(SectorRessourceType ressource) => _playerWallet.GetAmount(ressource);
		void ISectorResourcesWallet.AddAmount(SectorRessourceType ressource, int amount) => _playerWallet.AddAmount(ressource, amount);
		void ISectorResourcesWallet.RemoveAmount(SectorRessourceType ressource, int amount) => _playerWallet.RemoveAmount(ressource, amount);
		bool ISectorResourcesWallet.CanBuy(ISectorResourcesWallet price) => _playerWallet.CanBuy(price);
		void ISectorResourcesWallet.Buy(ISectorResourcesWallet price) => _playerWallet.Buy(price);

		public override string ToString()
		{
			return _playerWallet.ToString();
		}
		#endregion Methods
	}
}