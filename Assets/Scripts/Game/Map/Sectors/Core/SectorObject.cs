namespace Tartaros.Map
{
	using System;
	using Tartaros.ServicesLocator;
	using UnityEditor;
	using UnityEngine;

	public class SectorObject : MonoBehaviour
	{
		#region Fields
		private const float MOVE_DETECTION_THRESHOLD = 0.1f;

		private ISector _currentSector = null;
		private IMap _map = null;
		private Vector3 _lastCheckPosition = Vector3.zero;
		#endregion Fields

		#region Properties
#pragma warning disable IDE0051 // Remove unused private members
		[ShowInRuntime] private string SectorName => _currentSector != null ? _currentSector.ToString() : "NO SECTOR";
#pragma warning restore IDE0051 // Remove unused private members
		public ISector CurrentSector => _currentSector;
		#endregion Properties

		#region Events
		public class SectorMovedArgs : EventArgs
		{
			private readonly ISector previousSector = null;
			private readonly ISector newSector = null;

			public ISector PreviousSector => previousSector;
			public ISector NewSector => newSector;

			public SectorMovedArgs(ISector previousSector, ISector newSector)
			{
				this.previousSector = previousSector;
				this.newSector = newSector;
			}
		}

		public event EventHandler<SectorMovedArgs> SectorMoved = null;
		#endregion Events

		#region Methods
		private void Awake()
		{
			_map = Services.Instance.Get<IMap>();
			SetCurrentSector(GetSectorOnPosition());
		}

		private void Start()
		{
			_lastCheckPosition = transform.position;
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

				_lastCheckPosition = transform.position;
			}
		}

		private bool HasMoved()
		{
			return Vector3.Distance(transform.position, _lastCheckPosition) >= MOVE_DETECTION_THRESHOLD;
		}

		private ISector GetSectorOnPosition()
		{
			return _map.GetSectorOnPosition(transform.position);
		}

		private void SetCurrentSector(ISector sector)
		{
			if (sector == _currentSector) return;

			ISector previousSector = _currentSector;

			if (_currentSector != null)
			{
				_currentSector.RemoveObjectInSector(gameObject);
			}

			_currentSector = sector;

			if (_currentSector != null)
			{
				_currentSector.AddObjectInSector(gameObject);
			}

			SectorMoved?.Invoke(this, new SectorMovedArgs(previousSector, _currentSector));
		}
		#endregion Methods
	}
}