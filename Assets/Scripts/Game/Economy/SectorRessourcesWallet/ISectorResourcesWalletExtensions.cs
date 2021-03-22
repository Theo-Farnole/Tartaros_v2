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
	}
}
