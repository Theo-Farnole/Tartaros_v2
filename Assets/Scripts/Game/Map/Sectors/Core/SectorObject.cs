namespace Tartaros.Map
{
	using Tartaros.ServicesLocator;
	using UnityEngine;

	public class SectorObject : MonoBehaviour
	{
		#region Fields
		private ISector _currentSector = null;
		private IMap _map = null;
		private Vector3 _lastPosition = Vector3.zero;
		#endregion Fields

		#region Methods
		private void Awake()
		{
			_map = Services.Instance.Get<IMap>();
		}

		private void Start()
		{
			SetCurrentSector(GetSectorOnPosition());
		}

		private void Update()
		{
			if (transform.position != _lastPosition)
			{
				if (IsOnNewSector())
				{
					SetCurrentSector(GetSectorOnPosition());
				}
			}
		}

		private ISector GetSectorOnPosition()
		{
			return _map.GetSectorOnPosition(transform.position);
		}

		private bool IsOnNewSector()
		{
			ISector sectorOnPosition = GetSectorOnPosition();

			return _currentSector != sectorOnPosition;
		}

		private void SetCurrentSector(ISector sector)
		{
			if (_currentSector != null)
			{
				_currentSector.RemoveObjectInSector(gameObject);
			}

			_currentSector = sector;

			if (_currentSector != null)
			{
				_currentSector.AddObjectInSector(gameObject);
			}
		}
		#endregion Methods
	}
}
