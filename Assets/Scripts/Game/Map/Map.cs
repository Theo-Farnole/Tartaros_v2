namespace Tartaros.Map
{
	using Sirenix.OdinInspector;
	using System.IO;
	using Tartaros.Map;
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
		private UserErrorsLogger _logger = null;
		#endregion Fields

		#region Properties
		public MapData MapData => _mapData;
		Bounds2D IMap.MapBounds => new Bounds2D(0, _mapData.MapSize.x, 0, _mapData.MapSize.y);
		ISector[] IMap.Sectors => _sectors;
		#endregion Properties

		#region Methods
		private void Awake()
		{
			_logger = Services.Instance.Get<UserErrorsLogger>();
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

		bool IMap.CanBuild(Vector3 buildingPosition, Vector2 buildingSize)
		{
			// TODO TF: check if build is not on multiple sector at once

			ISector sector = (this as IMap).GetSectorOnPosition(buildingPosition);

			if (sector.IsCaptured == false)
			{
				_logger.Log("Cannot build on a uncaptured sector.", buildingPosition, sector.ToString());
				return false;
			}

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
		public const string FILL_SITE_ID = "MapEditor_FillSite";

		[FoldoutGroup("Display Preferences")]
		[ShowInInspector]
		public bool DisplaySitesWithColor
		{
			get => UnityEditor.EditorPrefs.GetBool(FILL_SITE_ID, false);
			set => UnityEditor.EditorPrefs.SetBool(FILL_SITE_ID, value);
		}

		private const string path = "Assets/Databases/Maps/";

		[ShowIf("@_mapData == null")]
		[Button]
#pragma warning disable IDE0051 // Remove unused private members
		private void CreateMapData()
#pragma warning restore IDE0051 // Remove unused private members
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
