namespace Tartaros.UI
{
	using System;
	using Tartaros.Economy;
	using Tartaros.ServicesLocator;
	using UnityEngine;

	/// <summary>
	/// The amount that must display in the UI. 
	/// </summary>
	public class PlayerIncomeDisplayAmount : MonoBehaviour
	{
		#region Fields
		private ISectorResourcesWallet _customWallet = SectorResourcesWallet.Zero;

		// SERVICES
		private IPlayerIncomeManager _playerIncomeManager = null;
		#endregion Fields

		#region Events
		public event EventHandler<IncomeChangedArgs> IncomeChanged = null;
		#endregion Events

		#region Methods
		private void Awake()
		{
			_playerIncomeManager = Services.Instance.Get<IPlayerIncomeManager>();
		}

		private void OnEnable()
		{
			_playerIncomeManager.IncomeChanged -= playerIncomeManager_IncomeChanged;
			_playerIncomeManager.IncomeChanged += playerIncomeManager_IncomeChanged;
		}

		private void OnDisable()
		{
			_playerIncomeManager.IncomeChanged -= playerIncomeManager_IncomeChanged;			
		}

		private void playerIncomeManager_IncomeChanged(object sender, IncomeChangedArgs e)
		{
			IncomeChanged?.Invoke(this, e);
		}

		public void AddIncomeAmount(SectorRessourceType type, int amount)
		{
			_customWallet.AddAmount(type, amount);
			IncomeChanged?.Invoke(this, new IncomeChangedArgs());
		}

		public void RemoveIncomeAmount(SectorRessourceType type, int amount)
		{
			_customWallet.RemoveAmount(type, amount);
			IncomeChanged?.Invoke(this, new IncomeChangedArgs());
		}

		public int GetIncomeAmount(SectorRessourceType type)
		{
			return _customWallet.GetAmount(type) + _playerIncomeManager.GetIncomeAmount(type);
		}
		#endregion Methods
	}
}
