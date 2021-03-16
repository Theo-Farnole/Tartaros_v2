namespace Tartaros.Economy
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using Tartaros.Economy;
	using System.Linq;
	using System;

	[System.Serializable]
	public class SectorResourcesWallet : ISectorResourcesWallet
	{
		#region Fields
		[SerializeField]
		private Dictionary<SectorRessourceType, int> _ressourceAmount;

		public static readonly SectorResourcesWallet Zero = new SectorResourcesWallet(
			new Dictionary<SectorRessourceType, int>()
			{
				{ SectorRessourceType.Food, 0 },
				{ SectorRessourceType.Iron, 0 },
				{ SectorRessourceType.Stone, 0 }
			}
		);
		#endregion Fields

		#region Ctor
		public SectorResourcesWallet(SectorResourcesWallet walletToCopy)
		{
			_ressourceAmount = walletToCopy._ressourceAmount.ToDictionary(entry => entry.Key, entry => entry.Value);
		}

		public SectorResourcesWallet(Dictionary<SectorRessourceType, int> ressourceAmount)
		{
			_ressourceAmount = ressourceAmount;
		}
		#endregion

		#region Methods
		bool ISectorResourcesWallet.CanBuy(Price price)
		{
			return price.Amount <= _ressourceAmount[price.RessourceType];
		}

		void ISectorResourcesWallet.AddAmount(SectorRessourceType ressource, int amount)
		{
			_ressourceAmount[ressource] += amount;
		}

		void ISectorResourcesWallet.Buy(Price price)
		{
			(this as ISectorResourcesWallet).RemoveAmount(price.RessourceType, price.Amount);
		}

		int ISectorResourcesWallet.GetAmount(SectorRessourceType ressource)
		{
			return _ressourceAmount[ressource];
		}

		void ISectorResourcesWallet.RemoveAmount(SectorRessourceType ressource, int amount)
		{
			if (_ressourceAmount[ressource] - amount > 0)
			{
				_ressourceAmount[ressource] -= amount;
				Debug.Log(_ressourceAmount[ressource]);
			}
			else
			{
				Debug.LogError("wallet can't be under 0");
				_ressourceAmount[ressource] = 0;
			}
		}

		object ICloneable.Clone()
		{
			return new SectorResourcesWallet(this);
		}
		#endregion Methods
	}
}