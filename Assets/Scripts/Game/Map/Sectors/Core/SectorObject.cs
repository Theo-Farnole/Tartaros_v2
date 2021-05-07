namespace Tartaros.Map
{
	using Tartaros.ServicesLocator;
	using UnityEngine;

	public class SectorObject : MonoBehaviour
	{
		#region Fields
		private const float MOVE_DETECTION_THRESHOLD = 0.01f;

		private ISector _currentSector = null;
		private IMap _map = null;
		private Vector3 _lastPosition = Vector3.zero;
		#endregion Fields

		#region Methods
		private void Awake()
		{
			_map = Services.Instance.Get<IMap>();

			SetCurrentSector(GetSectorOnPosition());
			_lastPosition = transform.position;
		}

		private void Update()
		{
			if (HasMoved() == true)
			{
				ISector sectorOnPosition = GetSectorOnPosition();

				bool isOnNewSector = _currentSector != sectorOnPosition;

				if (isOnNewSector == true)
				{
					SetCurrentSector(sectorOnPosition);
				}
			}

			_lastPosition = transform.position;
		}

		private bool HasMoved()
		{
			return Vector3.Distance(transform.position, _lastPosition) >= MOVE_DETECTION_THRESHOLD;
		}

		private ISector GetSectorOnPosition()
		{
			return _map.GetSectorOnPosition(transform.position);
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
