namespace Tartaros.Economy
{
	using System;

	public class GloryAmountChangedArgs : EventArgs
	{ }

	public interface IGloryWallet
	{
		int GetAmount();
		void AddAmount(int amount);
		bool CanSpend(int price);
		void Spend(int price);
		event EventHandler<GloryAmountChangedArgs> AmountChanged;
	}
}