namespace Tartaros
{
	using Tartaros.Economy;

	public static class ISectorResourcesWalletExtensions
	{
		public static void AddWallet(this ISectorResourcesWallet wallet, ISectorResourcesWallet walletToAdd)
		{
			if (wallet is null) throw new System.ArgumentNullException(nameof(wallet));
			if (walletToAdd is null) throw new System.ArgumentNullException(nameof(walletToAdd));


			foreach (SectorRessourceType resourceType in EnumHelper.GetValues<SectorRessourceType>())
			{
				wallet.AddAmount(resourceType, walletToAdd.GetAmount(resourceType));
			}
		}

		public static void RemoveWallet(this ISectorResourcesWallet wallet, ISectorResourcesWallet walletToRemove)
		{
			if (wallet is null) throw new System.ArgumentNullException(nameof(wallet));
			if (walletToRemove is null) throw new System.ArgumentNullException(nameof(walletToRemove));

			foreach (SectorRessourceType resourceType in EnumHelper.GetValues<SectorRessourceType>())
			{
				wallet.RemoveAmount(resourceType, walletToRemove.GetAmount(resourceType));
			}
		}

		public static bool CanBuyWallet(this ISectorResourcesWallet wallet, ISectorResourcesWallet walletToBuy)
		{
			if (wallet is null) throw new System.ArgumentNullException(nameof(wallet));
			if (walletToBuy is null) throw new System.ArgumentNullException(nameof(walletToBuy));

			foreach (SectorRessourceType resourceType in EnumHelper.GetValues<SectorRessourceType>())
			{
				bool hasEnoughtMoney = wallet.GetAmount(resourceType) >= walletToBuy.GetAmount(resourceType);

				if (hasEnoughtMoney == false)
				{
					return false;
				}
			}

			return true;
		}

	}
}
