namespace Tartaros.Map
{
	using Sirenix.OdinInspector;
	using UnityEngine;

	public class Map : MonoBehaviour
	{
		#region Fields 
		[SerializeField]
		private MapData _mapData = null;

		[SerializeField]
		[AssetsOnly]
		private GameObject _sectorPrefab = null;
		#endregion Fields

		#region Properties
		public MapData MapData => _mapData;
		#endregion Properties

		#region Methods
		private void Start()
		{
			SpawnSectors();
		}

		private void SpawnSectors()
		{
			for (int i = 0; i < _mapData.Sectors.Length; i++)
			{
				// because polygon normal are forward, we must rotate to make them look up
				GameObject sectorGameObject = Instantiate(_sectorPrefab, Vector3.zero, Quaternion.Euler(90, 0, 0));
				sectorGameObject.name = string.Format("Sector {0}", i);

				if (sectorGameObject.TryGetComponent(out Sector sector))
				{
					SectorData sectorData = _mapData.Sectors[i];
					sector.Initialize(sectorData);
				}
				else
				{
					Debug.LogWarningFormat("Missing Sector component on prefab {0}.", _sectorPrefab.name);
				}
			}
		}
		#endregion Methods
	}
}
