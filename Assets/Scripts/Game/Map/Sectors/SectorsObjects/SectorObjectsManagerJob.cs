namespace Tartaros.Map
{
	using Sirenix.Utilities;
	using System.Collections.Generic;
	using Tartaros.Math;
	using Tartaros.ServicesLocator;
	using Unity.Collections;
	using Unity.Jobs;
	using UnityEngine;

	class SectorObjectsManagerJob
	{
		#region Fields
		private PolygonsContainer _polygonsContainer;
		private NativeArray<Vector2> _objectsPosition;
		private NativeArray<int> _objectsSectorIndexes;
		private JobHandle _handle;

		private IMap _map = null;
		#endregion Fields

		#region Ctor
		public SectorObjectsManagerJob()
		{
			_map = Services.Instance.Get<IMap>();
		}
		#endregion Ctor

		#region Methods
		public void Update(List<SectorObject> sectorObjects)
		{
			CreateContainer_Positions(sectorObjects);
			CreateContainer_Polygons();
			_objectsSectorIndexes = new NativeArray<int>(sectorObjects.Count, Allocator.TempJob);

			CalculateSectorOnPositionsJob job = new CalculateSectorOnPositionsJob()
			{
				objectsPosition = _objectsPosition,
				objectsSectorIndexes = _objectsSectorIndexes,
				polygons = _polygonsContainer
			};

			_handle = job.Schedule(sectorObjects.Count, 64);
		}

		public void LateUpdate(List<SectorObject> sectorObjects)
		{
			_handle.Complete();

			ISector[] sectors = _map.Sectors;

			for (int i = 0, length = _objectsSectorIndexes.Length; i < length; i++)
			{
				if (_objectsSectorIndexes[i] == -1) continue;

				ISector currentSector = sectors[_objectsSectorIndexes[i]];
				sectorObjects[i].SetCurrentSector(currentSector);
			}

			_polygonsContainer.Dispose();
			_objectsSectorIndexes.Dispose();
			_objectsPosition.Dispose();
		}

		private void CreateContainer_Positions(List<SectorObject> sectorObjects)
		{
			int count = sectorObjects.Count;

			_objectsPosition = new NativeArray<Vector2>(count, Allocator.TempJob);

			for (int i = 0, length = count; i < length; i++)
			{
				Vector3 position = sectorObjects[i].transform.position;
				_objectsPosition[i] = new Vector2(position.x, position.z);
			}
		}

		private void CreateContainer_Polygons()
		{
			_polygonsContainer.Clear();

			for (int i = 0, length = _map.Sectors.Length; i < length; i++)
			{
				ISector sector = _map.Sectors[i];

				if (sector is Sector sectorPolygon)
				{
					_polygonsContainer.AddPolygon(sectorPolygon.ConvexPolygon);
				}
				else
				{
					throw new System.NotSupportedException("Sector objects manager only supports Sector with convex polygon.");
				}
			}
		}
		#endregion Methods
	}
}
