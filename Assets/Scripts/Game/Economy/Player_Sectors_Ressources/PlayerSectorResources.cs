namespace Tartaros.Economy
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using ServicesLocator;
	using System;

	public class PlayerSectorResources : MonoBehaviour, IPlayerSectorResources
	{
		[SerializeField]
		private PlayerSectorResourcesData _playerSectorRessourcesData = null;

		private ISectorResourcesWallet _playerWallet = null;

		private void Awake()
		{
			if (_playerSectorRessourcesData != null)
			{
				_playerWallet = (_playerSectorRessourcesData.Wallet as ICloneable).Clone() as ISectorResourcesWallet;
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
	}
}