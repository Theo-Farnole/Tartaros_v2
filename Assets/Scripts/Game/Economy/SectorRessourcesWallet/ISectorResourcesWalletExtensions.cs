namespace Tartaros
{
	using System.Text;
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

		public static bool CanBuyWallet(this ISectorResourcesWallet w1, ISectorResourcesWallet w2)
		{
			if (w1 is null) throw new System.ArgumentNullException(nameof(w1));
			if (w2 is null) throw new System.ArgumentNullException(nameof(w2));

			foreach (SectorRessourceType resourceType in EnumHelper.GetValues<SectorRessourceType>())
			{
				bool hasEnoughtMoney = w1.GetAmount(resourceType) >= w2.GetAmount(resourceType);

				if (hasEnoughtMoney == false)
				{
					return false;
				}
			}

			return true;
		}

		public static string ToRichTextString(this ISectorResourcesWallet w1)
		{
			if (w1 is null) throw new System.ArgumentNullException(nameof(w1));

			StringBuilder sb = new StringBuilder();

			foreach (SectorRessourceType resourceType in EnumHelper.GetValues<SectorRessourceType>())
			{
				int amount = w1.GetAmount(resourceType);

				if (amount != 0)
				{
					string richTextSprite = resourceType.GetRichTextSprite();

					sb.AppendFormat("{0}{1}", amount, richTextSprite);
					sb.AppendFormat(" ");
				}

			}

			string output = sb.ToString().Trim();

			if (output != string.Empty)
			{
				return output;
			}
			else
			{
				return TartarosTexts.CAPTURE_SECTOR_FREE;
			}
		}

	}
}
