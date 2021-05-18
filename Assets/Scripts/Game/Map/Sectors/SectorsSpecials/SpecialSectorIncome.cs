namespace Tartaros.Map
{
	using Sirenix.OdinInspector;
	using System.Collections;
	using Tartaros.Economy;
	using Tartaros.ServicesLocator;
	using UnityEngine;

	[RequireComponent(typeof(SectorObject))]
	public class SpecialSectorIncome : SerializedMonoBehaviour, IIncomeGenerator
	{
		[SerializeField] private SectorRessourceType _ressourceType = SectorRessourceType.Iron;
		[SerializeField] private int _ressourcePerTick = 5;
		[SerializeField] private int  _gloryIncomeOnCapture = 0;

		private int _maxRessourceBeforeEmpty = 0;
		private IMap _map = null;
		private IPlayerIncomeManager _playerIncomeManager = null;
		private PlayerGloryIncomeManager _playerGloryIncomeManager = null;

		public IIncomeGenerator RessourcesIncome => this;
		public int GloryIncomeOnCapture => _gloryIncomeOnCapture;

		SectorRessourceType IIncomeGenerator.SectorRessourceType => _ressourceType;

		int IIncomeGenerator.ResourcesPerTick =>_ressourcePerTick;

		int IIncomeGenerator.MaxRessourcesBeforeEmpty => _maxRessourceBeforeEmpty;

		private void Awake()
		{
			_playerIncomeManager = Services.Instance.Get<IPlayerIncomeManager>();
			_playerGloryIncomeManager = FindObjectOfType<PlayerGloryIncomeManager>();
		}

		public void AddIncome()
		{
			if(_playerIncomeManager != null)
			{
				_playerIncomeManager.AddGeneratorIncome(this);
			}
		}

		public void RemoveIncome()
		{
			if(_playerIncomeManager != null)
			{
				_playerIncomeManager.RemoveGeneratorIncome(this);
			}
		}

		public void AddGlory()
		{
			if(_playerGloryIncomeManager != null)
			{
				_playerGloryIncomeManager.AddGlory(transform, _gloryIncomeOnCapture);
			}
		}

		void IIncomeGenerator.RessourcesIsEmpty()
		{
			
		}
	}
}