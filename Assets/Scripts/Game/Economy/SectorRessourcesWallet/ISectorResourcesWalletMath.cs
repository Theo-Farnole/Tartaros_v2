namespace Tartaros.Economy
{
	using UnityEngine;

	public static class ISectorResourcesWalletMath
	{
		public static ISectorResourcesWallet Multiply(ISectorResourcesWallet wallet, float multiplicator)
		{
			ISectorResourcesWallet output = (ISectorResourcesWallet)wallet.Clone();

			foreach (SectorRessourceType type in EnumHelper.GetValues<SectorRessourceType>())
			{
				output.SetAmount(type, Mathf.CeilToInt((float)output.GetAmount(type) * multiplicator));
			}

			return output;
		}
	}
}
