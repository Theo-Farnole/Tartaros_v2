namespace Tartaros.Economy
{
	using System;

	public class AmountChangedArgs : EventArgs
	{

	}

	public interface ISectorResourcesWallet
	{
		// TODO TF: Retake this name
		event EventHandler<AmountChangedArgs> AmountChanged;

		int GetAmount(SectorRessourceType ressource);
        void AddAmount(SectorRessourceType ressource, int amount);
		void RemoveAmount(SectorRessourceType ressource, int amount);
		bool CanBuy(ISectorResourcesWallet price);
		void Buy(ISectorResourcesWallet price);
	}
}