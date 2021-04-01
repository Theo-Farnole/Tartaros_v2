namespace Tartaros.Economy
{
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using Tartaros.Economy;
	using System.Linq;
	using System;
	using System.Text;

	[System.Serializable]
	public class SectorResourcesWallet : ISectorResourcesWallet, ICloneable
	{
		#region Fields
		private static readonly SectorRessourceType[] SECTOR_RESOURCE_TYPE_VALUES = EnumHelper.GetValues<SectorRessourceType>();

		[SerializeField]
		private Dictionary<SectorRessourceType, int> _ressourceAmount = null;

		#endregion Fields

		#region Properties
		public static SectorResourcesWallet Zero
		{
			get
			{
				Dictionary<SectorRessourceType, int> EMPTY_DICTIONARY = new Dictionary<SectorRessourceType, int>()
				{
					{ SectorRessourceType.Food, 0 },
					{ SectorRessourceType.Iron, 0 },
					{ SectorRessourceType.Stone, 0 }
				};


				return new SectorResourcesWallet(EMPTY_DICTIONARY);
			}
		}

		private ISectorResourcesWallet Self => this;
		#endregion Properties

		#region Events
		public event EventHandler<AmountChangedArgs> AmountChanged = null;
		#endregion Events

		#region Ctor
		public SectorResourcesWallet() : this(Zero)
		{ }

		public SectorResourcesWallet(int food, int stone, int iron)
		{
			_ressourceAmount = new Dictionary<SectorRessourceType, int>();

			_ressourceAmount[SectorRessourceType.Food] = food;
			_ressourceAmount[SectorRessourceType.Stone] = stone;
			_ressourceAmount[SectorRessourceType.Iron] = iron;
		}

		public SectorResourcesWallet(ISectorResourcesWallet walletToCopy) : this(GenerateResourcesAmount(walletToCopy))
		{ }

		public SectorResourcesWallet(Dictionary<SectorRessourceType, int> ressourceAmount)
		{
			_ressourceAmount = ressourceAmount.ToDictionary(entry => entry.Key, entry => entry.Value);
		}
		#endregion

		#region Methods
		private static Dictionary<SectorRessourceType, int> GenerateResourcesAmount(ISectorResourcesWallet wallet)
		{
			Dictionary<SectorRessourceType, int> output = new Dictionary<SectorRessourceType, int>();

			foreach (SectorRessourceType resourceType in EnumHelper.GetValues<SectorRessourceType>())
			{
				output.Add(resourceType, wallet.GetAmount(resourceType));
			}

			return output;
		}

		void ISectorResourcesWallet.AddAmount(SectorRessourceType ressource, int amount)
		{
			if (_ressourceAmount.ContainsKey(ressource) == false)
			{
				_ressourceAmount.Add(ressource, 0);
			}

			_ressourceAmount[ressource] += amount;

			AmountChanged?.Invoke(this, new AmountChangedArgs());
		}

		void ISectorResourcesWallet.RemoveAmount(SectorRessourceType ressource, int amount)
		{
			if (_ressourceAmount[ressource] - amount < 0)
			{
				Debug.LogError("wallet can't be under 0");
				_ressourceAmount[ressource] = 0;
				return;
			}

			_ressourceAmount[ressource] -= amount;
			AmountChanged?.Invoke(this, new AmountChangedArgs());
		}

		int ISectorResourcesWallet.GetAmount(SectorRessourceType ressource)
		{
			if (_ressourceAmount.TryGetValue(ressource, out int amount))
			{
				return amount;
			}
			else
			{
				return 0;
			}
		}

		bool ISectorResourcesWallet.CanBuy(ISectorResourcesWallet price)
		{
			if (price is null) throw new ArgumentNullException(nameof(price));

			foreach (var sectorResourceType in SECTOR_RESOURCE_TYPE_VALUES)
			{
				bool hasEnoughtAmount = Self.GetAmount(sectorResourceType) >= price.GetAmount(sectorResourceType);

				if (hasEnoughtAmount == false)
				{
					return false;
				}
			}

			return true;
		}

		void ISectorResourcesWallet.Buy(ISectorResourcesWallet price)
		{
			foreach (var sectorResourceType in SECTOR_RESOURCE_TYPE_VALUES)
			{
				Self.RemoveAmount(sectorResourceType, price.GetAmount(sectorResourceType));
			}
		}

		object ICloneable.Clone()
		{
			return new SectorResourcesWallet(this);
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();

			foreach (var type in EnumHelper.GetValues<SectorRessourceType>())
			{
				sb.AppendFormat("{0}={1}", type, (this as ISectorResourcesWallet).GetAmount(type));
			}

			return sb.ToString();
		}
		#endregion Methods
	}
}