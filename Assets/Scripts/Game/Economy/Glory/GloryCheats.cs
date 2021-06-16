namespace Tartaros.Glory
{
	using Tartaros.Economy;
	using Tartaros.ServicesLocator;
	using TF.CheatsGUI;

	public static class GloryCheats
	{
		[Cheat]
		public static void GiveGlory(int amount = 30)
		{
			IPlayerGloryWallet gloryWallet = Services.Instance.Get<IPlayerGloryWallet>();
			gloryWallet.AddAmount(amount);
		}
	}
}
