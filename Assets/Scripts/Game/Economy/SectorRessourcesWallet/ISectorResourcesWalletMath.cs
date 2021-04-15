namespace Tartaros.Economy
{
	public static class ISectorResourcesWalletMath
	{
		public static ISectorResourcesWallet Multiply(ISectorResourcesWallet wallet, int integer)
		{
			ISectorResourcesWallet output = (ISectorResourcesWallet)wallet.Clone();

			foreach (SectorRessourceType type in EnumHelper.GetValues<SectorRessourceType>())
			{
				output.SetAmount(type, output.GetAmount(type) * integer);
			}

			return output;
		}
	}
}
