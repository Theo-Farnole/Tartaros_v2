namespace Tartaros.Map
{
	using System.Collections.Generic;
	using UnityEngine;

	public class SectorObjectsManager : MonoBehaviour
	{
		#region Fields
		private List<SectorObject> _sectorObjects = new List<SectorObject>();
		private List<SectorObject> _pendingAddObjects = new List<SectorObject>();
		private List<SectorObject> _pendingRemoveObjects = new List<SectorObject>();

		private SectorObjectsManagerJob _jobCalculator = null;
		#endregion Fields

		#region Methods
		private void Awake()
		{
			_jobCalculator = new SectorObjectsManagerJob();
		}

		private void Update()
		{
			ManagePendingObjects();

			_jobCalculator.Update(_sectorObjects);
		}

		private void LateUpdate()
		{
			_jobCalculator.LateUpdate(_sectorObjects);
		}

		private void ManagePendingObjects()
		{
			for (int i = 0, length = _pendingAddObjects.Count; i < length; i++)
			{
				SectorObject pendingAddObject = _pendingAddObjects[i];
				_sectorObjects.Add(pendingAddObject);
			}

			for (int i = 0, length = _pendingRemoveObjects.Count; i < length; i++)
			{
				SectorObject pendingRemoveObject = _pendingRemoveObjects[i];
				_sectorObjects.Remove(pendingRemoveObject);
			}

			_pendingAddObjects.Clear();
			_pendingRemoveObjects.Clear();
		}

		public void AddSectorObject(SectorObject sectorObject)
		{
			if (_pendingRemoveObjects.Contains(sectorObject))
			{
				_pendingRemoveObjects.Remove(sectorObject);
			}

			_pendingAddObjects.Add(sectorObject);
		}

		public void RemoveSectorObject(SectorObject sectorObject)
		{
			if (_pendingAddObjects.Contains(sectorObject))
			{
				_pendingAddObjects.Remove(sectorObject);
			}

			_pendingRemoveObjects.Add(sectorObject);
		}
		#endregion Methods
	}
}
