namespace Tartaros.Map
{
	using Tartaros.Economy;
	using Tartaros.ServicesLocator;
	using UnityEngine;

	public class SectorsCaptureManager : MonoBehaviour, ISectorsCaptureManager
	{
		#region Fields
		private const string DBG_CANNOT_CAPTURE = "Cannot capture sector {0} : {1}";

		private IPlayerSectorResources _playerWallet = null;
		private IMap _map = null;
		private UserErrorsLogger _userErrorsLogger = null;
		#endregion Fields

		#region Methods
		private void Awake()
		{
			_playerWallet = Services.Instance.Get<IPlayerSectorResources>();
			_map = Services.Instance.Get<IMap>();
			_userErrorsLogger = Services.Instance.Get<UserErrorsLogger>();
		}

		private void CaptureSectorBuilding(ISector sector) 
		{
			BuildingSlot buildingSlot = sector.GetBuildingSlotAvailable();

			if (buildingSlot != null && buildingSlot.CanConstruct() == true)
			{
				buildingSlot.Construct();
			}
		}

		void ISectorsCaptureManager.Capture(ISector sectorToCapture)
		{
			if (sectorToCapture.IsCaptured == true) return;

			if ((this as ISectorsCaptureManager).CanCapture(sectorToCapture) == true)
			{
				if (sectorToCapture.CapturePrice != null)
				{
					_playerWallet.Buy(sectorToCapture.CapturePrice);
				}

				CaptureSectorBuilding(sectorToCapture);
				sectorToCapture.IsCaptured = true;
			}
			else
            {
				Debug.LogFormat("Cannot capture sector {0}.", sectorToCapture.ToString());
            }
		}

		bool ISectorsCaptureManager.CanCapture(ISector sector)
		{
			// TODO TF: (refactor) check if there is another way
			if (sector.IsThereEnemiesOnSector() == true)
			{
				Debug.LogFormat(DBG_CANNOT_CAPTURE, name, "there is ennemies on the sector.");
				_userErrorsLogger.Log("Cannot capture this sector: there is ennemies on the sector.");
				return false;
			}

			if (sector.IsTherePlayersEntitiesOnSector() == false)
			{
				Debug.LogFormat(DBG_CANNOT_CAPTURE, name, "must contains players entities on the sector.");
				_userErrorsLogger.Log("Cannot capture this sector: one of your unit must be on it.");
				return false;
			}

			if (_map.IsSectorNeightborOfCapturedSectors(sector) == false)
			{
				Debug.LogFormat(DBG_CANNOT_CAPTURE, name, "must be neightbor of a captured sector.");
				_userErrorsLogger.Log("Cannot capture this sector: it must be a neightbor of an already captured sector.");
				return false;
			}

			if (sector.CapturePrice == null)
			{
				Debug.LogErrorFormat("Capture price is not set on sector {0}. The sector is unlocked for free.", name);				
				return true;
			}

			return _playerWallet.CanBuy(sector.CapturePrice);
		}

		void ISectorsCaptureManager.ForceCapture(ISector sectorToCapture)
		{
			sectorToCapture.IsCaptured = true;
		}
		#endregion Methods
	}
}
