namespace Tartaros.UI.MiniMap
{
	using Sirenix.OdinInspector;
	using System.Collections.Generic;
	using System.Linq;
	using Tartaros.Map;
	using Tartaros.ServicesLocator;
	
	using Tartaros.Wave;
	using UnityEngine;
	using UnityEngine.UI;

	public class MiniMap : MonoBehaviour
	{
		[SerializeField]
		private RectTransform _rootTransform = null;

		[SerializeField]
		private RectTransform _iconsParent = null;

		[BoxGroup("Prefabs")]
		[SerializeField]
		private GameObject _prefabIcon = null;
		[SerializeField]
		private SectorsMiniMapDisplay _sectorDisplayer = null;

		[ShowInRuntime]
		private Dictionary<IMiniMapIcon, RectTransform> _icons = new Dictionary<IMiniMapIcon, RectTransform>();

		[SerializeField]
		private NavigationPathMiniMap _navigationPathCalcule = null;

		private IMap _map = null;
		private EnemiesWavesManager _enemiesWaveManager = null;
		private FrustumCameraMiniMap _frustrumCamera = null;

		public RectTransform RootTransform => _rootTransform;

		private void Awake()
		{
			if (_rootTransform == null)
			{
				Debug.LogErrorFormat("Missing root transform in minimap {0}.", name);
			}

			_map = Services.Instance.Get<IMap>();
			_enemiesWaveManager = Services.Instance.Get<EnemiesWavesManager>();
		}

		private void Start()
		{
			if (_map.Sectors == null)
			{
				Debug.LogError("there is no sector reference on the map");
				return;
			}
			else
			{
				var array = _map.Sectors.OfType<Sector>().ToArray();

				_navigationPathCalcule = Services.Instance.Get<NavigationPathMiniMap>();
				_frustrumCamera = GetComponent<FrustumCameraMiniMap>();
				_frustrumCamera.InstanciateLineUI();
				_sectorDisplayer.DisplaySectors();
				//DrawWavePathNavigation();
			}

			if (_enemiesWaveManager == null)
			{
				Debug.LogError("No reference of waveManager on MiniMap");
			}
			else
			{
				_enemiesWaveManager.WaveStartCooldown -= WaveCooldownStart;
				_enemiesWaveManager.WaveStartCooldown += WaveCooldownStart;
			}
		}

		private void OnEnable()
		{
			if (_enemiesWaveManager != null)
			{
				_enemiesWaveManager.WaveStartCooldown -= WaveCooldownStart;
				_enemiesWaveManager.WaveStartCooldown += WaveCooldownStart;
			}
		}

		private void OnDisable()
		{
			_enemiesWaveManager.WaveStartCooldown -= WaveCooldownStart;
		}

		private void WaveCooldownStart(object sender, EnemiesWavesManager.WaveStartCooldownArgs e)
		{
			DrawWavePathNavigation();
		}

		private void Update()
		{
			SetPositionIcons();
		}

		private void SetPositionIcons()
		{
			RemoveDestroyedMinimapIcons();

			foreach (var icon in _icons)
			{
				RectTransform iconTransform = icon.Value;
				Vector3 iconWorldPosition = icon.Key.WorldPosition;
				Vector2 iconUIPosition = WordToUiPosition(iconWorldPosition);

				iconTransform.anchoredPosition = iconUIPosition;
			}
		}

		private void RemoveDestroyedMinimapIcons()
		{
			// source: https://stackoverflow.com/questions/16340818/remove-item-from-dictionary-where-value-is-empty-list
			_icons = _icons
				.Where(x => x.Key.IsInterfaceDestroyed() == false)
				.ToDictionary(x => x.Key, x => x.Value);
		}

		public Vector2 WordToUiPosition(Vector3 worldPosition)
		{
			var x = _rootTransform.rect.width * worldPosition.x / _map.MapBounds.boundsX.max;
			var y = _rootTransform.rect.height * worldPosition.z / _map.MapBounds.boundsY.max;

			return new Vector2(x, y);
		}

		public Vector2 WordToUiPosition(Vector2 worldPosition)
		{
			var x = _rootTransform.rect.width * worldPosition.x / _map.MapBounds.boundsX.max;
			var y = _rootTransform.rect.height * worldPosition.y / _map.MapBounds.boundsY.max;

			return new Vector2(x, y);
		}

		public void DrawWavePathNavigation()
		{
			_navigationPathCalcule.DisablePathLine();
			_navigationPathCalcule.DrawPathNavigation();
			//TODO DJ: draw the nav line each start of wave 
		}

		public void AddIcon(IMiniMapIcon icon)
		{
			RectTransform rectTransform = InstantiateIcon(icon);

			_icons.Add(icon, rectTransform);
		}

		private RectTransform InstantiateIcon(IMiniMapIcon icon)
		{
			var iconGameObject = GameObject.Instantiate(_prefabIcon, _iconsParent);

			RectTransform rectTransform = iconGameObject.GetComponent<RectTransform>();

			rectTransform.SetParent(_iconsParent, false);
			rectTransform.localScale = Vector3.one;
			iconGameObject.GetComponent<Image>().sprite = icon.Icon;

			return rectTransform;
		}

		public void RemoveIcon(IMiniMapIcon icon)
		{
			if (_icons.ContainsKey(icon) == true)
			{
				//Destroy(_icons[icon].gameObject);
				//_icons.Remove(icon);
			}
			else
			{
				Debug.LogErrorFormat("Trying to remove {0} icon, but it is not in minimap's icons list.", icon.ToString());
			}
		}


		private void ApplyMask()
		{
			throw new System.NotImplementedException();
		}

		private void DrawMask()
		{
			throw new System.NotImplementedException();
		}

		private void DrawPolygon()
		{
			throw new System.NotImplementedException();
		}
	}
}