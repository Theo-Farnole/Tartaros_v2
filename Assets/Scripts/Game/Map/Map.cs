namespace Tartaros.Map
{
	using Sirenix.OdinInspector;
	using System;
	using System.IO;
	using Tartaros.Sectors;
	using Tartaros.ServicesLocator;
	using Tartaros.Utilities;
	using UnityEngine;

	public partial class Map : MonoBehaviour, IMap
	{
		#region Fields 
		[SerializeField]
		[InlineEditor]
		private MapData _mapData = null;

		[SerializeField]
		[AssetsOnly]
		private GameObject _sectorPrefab = null;

		private ISector[] _sectors = null;
		#endregion Fields

		#region Properties
		public MapData MapData => _mapData;

		Bounds2D IMap.MapBounds => new Bounds2D(0, _mapData.MapSize.x, 0, _mapData.MapSize.y);
		#endregion Properties

		#region Methods
		private void Awake()
		{
			Services.Instance.RegisterService<IMap>(this);
			SpawnSectors();
		}

		private void OnDrawGizmos()
		{
			if (_mapData != null)
			{
				Gizmos.color = Color.green;
				Vector3 size = new Vector3(_mapData.MapSize.x, 0, _mapData.MapSize.y);
				Gizmos.DrawWireCube(size / 2, size);
			}
		}

		bool IMap.CanBuild(Vector2 buildingPosition, Vector2 buildingSize)
		{
			Debug.Log("Not implemented");
			return true;
		}

		ISector IMap.GetSectorOnPosition(Vector3 position)
		{
			foreach (var sector in _sectors)
			{
				if (sector.ContainsPosition(position))
				{
					return sector;
				}
			}

			Debug.LogFormat("No sector found at position {0}", position);
			return null;
		}

		bool IMap.IsSectorNeightborOfCapturedSectors(ISector sectorToCheck)
		{
			foreach (ISector sector in _sectors)
			{
				if (sector.IsCaptured && sectorToCheck.IsSectorNeightborOf(sector) == true)
				{
					return true;
				}
			}

			return false;
		}

		private void SpawnSectors()
		{
			_sectors = new ISector[_mapData.Sectors.Length];

			for (int i = 0; i < _mapData.Sectors.Length; i++)
			{
				// because polygon normal are forward, we must rotate to make them look up
				GameObject sectorGameObject = Instantiate(_sectorPrefab, Vector3.zero, Quaternion.Euler(90, 0, 0));
				sectorGameObject.name = string.Format("Sector {0}", i);

				if (sectorGameObject.TryGetComponent(out Sector sector))
				{
					_sectors[i] = sector;

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

#if UNITY_EDITOR
	public partial class Map
	{
		private const string path = "Assets/Databases/Maps/";

		[ShowIf("@_mapData == null")]
		[Button]
		public void CreateMapData()
		{
			MapData mapData = ScriptableObject.CreateInstance<MapData>();

			string filename = string.Format("Map-{0}.asset", gameObject.scene.name);
			string filePath = path + filename;


			string dataPath = Application.dataPath;
			string dataPathWithoutAsset = dataPath.Remove(dataPath.Length - "Assets".Length);
			Debug.Log(dataPathWithoutAsset + path);

			Directory.CreateDirectory(dataPathWithoutAsset + path);

			UnityEditor.AssetDatabase.CreateAsset(mapData, filePath);

			UnityEditor.AssetDatabase.SaveAssets();

			_mapData = mapData;

			Debug.LogFormat("Creating map data at path {0}.", filePath);
		}
	}
#endif
}
