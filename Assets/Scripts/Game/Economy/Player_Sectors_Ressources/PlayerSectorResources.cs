namespace Tartaros.Economy
{
	using ServicesLocator;
	using System;
	using UnityEngine;
	using UnityEngine.UIElements;

	public class PlayerSectorResources : MonoBehaviour, IPlayerSectorResources
	{
		#region Fields
		[SerializeField]
		private PlayerSectorResourcesData _playerSectorRessourcesData = null;

		private ISectorResourcesWallet _playerWallet = null;
		#endregion Fields

		#region Properties
		private ISectorResourcesWallet PlayerWallet
		{
			get
			{
				if (_playerWallet == null)
				{
					InitializePlayerWallet();
				}

				return _playerWallet;
			}
		}
		#endregion Properties

		#region Events
		event EventHandler<AmountChangedArgs> ISectorResourcesWallet.AmountChanged
		{
			add
			{
				PlayerWallet.AmountChanged += value;
			}

			remove
			{
				PlayerWallet.AmountChanged -= value;
			}
		}
		#endregion Events

		#region Methods
		private void Awake()
		{
			InitializePlayerWallet();

			Services.Instance.RegisterService<IPlayerSectorResources>(this);
		}

		private void InitializePlayerWallet()
		{
			if (_playerWallet != null) return; // don't initialize if already initialized

			if (_playerSectorRessourcesData != null)
			{
				_playerWallet = (_playerSectorRessourcesData.StartingIncome as ICloneable).Clone() as ISectorResourcesWallet;
			}
			else
			{
				Debug.LogWarning("Missing _playerSectorResourcesData field in inspector. Default wallet is equals to zero.");
				_playerWallet = SectorResourcesWallet.Zero;
			}
		}

		int ISectorResourcesWallet.GetAmount(SectorRessourceType ressource) => _playerWallet.GetAmount(ressource);
		void ISectorResourcesWallet.AddAmount(SectorRessourceType ressource, int amount) => _playerWallet.AddAmount(ressource, amount);
		void ISectorResourcesWallet.RemoveAmount(SectorRessourceType ressource, int amount) => _playerWallet.RemoveAmount(ressource, amount);
		bool ISectorResourcesWallet.CanBuy(ISectorResourcesWallet price) => _playerWallet.CanBuy(price);
		void ISectorResourcesWallet.Buy(ISectorResourcesWallet price) => _playerWallet.Buy(price);

		public override string ToString()
		{
			return _playerWallet.ToString();
		}

		void ISectorResourcesWallet.SetAmount(SectorRessourceType ressource, int amount)
		{
			throw new NotImplementedException();
		}

		object ICloneable.Clone()
		{
			throw new NotImplementedException();
		}
		#endregion Methods
	}
}