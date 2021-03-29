namespace Tartaros.Sectors
{
	using Tartaros.Economy;
	using Tartaros.ServicesLocator;
	using UnityEngine;

	public class SectorsCaptureManager : MonoBehaviour, ISectorsCaptureManager
	{
		#region Fields
		private IPlayerSectorResources _playerWallet = null;
		private IMap _map = null;
		#endregion Fields

		#region Methods
		private void Awake()
		{
			Services.Instance.RegisterService<ISectorsCaptureManager>(this);
		}

		private void Start()
		{
			_playerWallet = Services.Instance.Get<IPlayerSectorResources>();
			_map = Services.Instance.Get<IMap>();
		}

		void ISectorsCaptureManager.Capture(ISector sectorToCapture)
		{
			if ((this as ISectorsCaptureManager).CanCapture(sectorToCapture)) return;
			if (sectorToCapture.IsCaptured == true) return;

			if (sectorToCapture.CapturePrice != null)
			{
				_playerWallet.Buy(sectorToCapture.CapturePrice);
			}

			sectorToCapture.IsCaptured = true;
		}

		bool ISectorsCaptureManager.CanCapture(ISector sector)
		{
			if (_map.IsSectorNeightborOfCapturedSectors(sector) == false)
			{
				Debug.Log("Sector to capture has not neightbor that is captured.");
				return false;
			}

			if (sector.CapturePrice == null)
			{
				Debug.LogErrorFormat("Capture price is not set on sector {0}. The sector is unlocked for free.", name);
				return true;
			}

			return _playerWallet.CanBuy(sector.CapturePrice);
		}
		#endregion Methods
	}
}
