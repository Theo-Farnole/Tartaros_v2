namespace Tartaros.Economy
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using Tartaros.Economy;
	using ServicesLocator;
	using System;

	public class PlayerIncomeSectorResources : MonoBehaviour, IPlayerIncomeSectorResources
	{
		#region Fields
		[SerializeField]
		private PlayerSectorResourcesData _data = null;

		private IPlayerSectorResources _playerSectorRessources = null;
		#endregion Fields

		#region Properties
		public event EventHandler<AmountChangedArgs> AmountChanged = null;
		#endregion Properties

		#region Methods
		private void Awake()
		{
			Services.Instance.RegisterService<IPlayerIncomeSectorResources>(this);
			_playerSectorRessources = Services.Instance.Get<IPlayerSectorResources>();
		}

		int ISectorResourcesWallet.GetAmount(SectorRessourceType ressource) => _playerSectorRessources.GetAmount(ressource);
		void ISectorResourcesWallet.AddAmount(SectorRessourceType ressource, int amount) => _playerSectorRessources.AddAmount(ressource, amount);
		void ISectorResourcesWallet.RemoveAmount(SectorRessourceType ressource, int amount) => _playerSectorRessources.RemoveAmount(ressource, amount);
		bool ISectorResourcesWallet.CanBuy(ISectorResourcesWallet price) => _playerSectorRessources.CanBuy(price);
		void ISectorResourcesWallet.Buy(ISectorResourcesWallet price) => _playerSectorRessources.Buy(price);
		#endregion Methods
	}
}