namespace Tartaros.Map
{
	using Sirenix.OdinInspector;
	using System.Linq;
	using Tartaros.Sectors;
	using Tartaros.ServicesLocator;
	using Tartaros.Utilities;
	using UnityEngine;

	public class Map : MonoBehaviour, IMap
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

		Bounds2D IMap.MapBounds => new Bounds2D(0, _mapData.MapSize.x, 0, _mapData.MapSize.y);
		#endregion Properties

		#region Methods
		private void Awake()
		{
			Services.Instance.RegisterService<IMap>(this);
		}

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

		bool IMap.CanBuild(Vector2 buildingPosition, Vector2 buildingSize)
		{
			Debug.LogError("Not implemented");
			return true;
		}

		ISector IMap.GetSectorOnPosition(Vector3 position)
		{
			ISector[] sectors = ObjectsFinder.FindObjectsOfInterface<ISector>();

			foreach (var sector in sectors)
			{
				if (sector.ContainsPosition(position))
				{
					Debug.LogFormat("GetSectorOnPosition returns sector {0} at position {1}.", sector.ToString(), position);
					return sector;
				}
			}

			Debug.LogFormat("No sector found at position {0}", position);
			return null;
		}
		#endregion Methods
	}
}
