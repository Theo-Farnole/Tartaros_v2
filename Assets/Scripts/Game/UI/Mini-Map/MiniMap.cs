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
		[SerializeField] private RectTransform _rootTransform = null;

		[SerializeField] private RectTransform _iconsParent = null;

		[BoxGroup("Prefabs"), SerializeField] private GameObject _prefabIcon = null;
		[SerializeField] private SectorsMiniMapDisplay _sectorDisplayer = null;

		[ShowInRuntime] private Dictionary<IMiniMapIcon, RectTransform> _icons = new Dictionary<IMiniMapIcon, RectTransform>();

		[SerializeField] private NavigationPathMiniMap _navigationPathCalcule = null;

		private IMap _map = null;
		private EnemiesWavesManager _enemiesWaveManager = null;
		private FrustumCameraMiniMap _frustrumCamera = null;
		private PingWaveMiniMap _pingWave = null;
		private MoveOnClickMiniMap _moveOnClick = null;

		public RectTransform RootTransform => _rootTransform;
		public EnemiesWavesManager WaveManager => _enemiesWaveManager;

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
				_pingWave = GetComponent<PingWaveMiniMap>();
				_moveOnClick = GetComponent<MoveOnClickMiniMap>();

				_frustrumCamera.InstanciateLineUI();
				_sectorDisplayer.DisplaySectors();
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
			_pingWave.PingStartWaveCooldown();
		}

		private void Update()
		{
			SetPositionIcons();
		}

		private void SetPositionIcons()
		{
			foreach (KeyValuePair<IMiniMapIcon, RectTransform> icon in _icons)
			{
				if (icon.Key.IsInterfaceDestroyed() == true) continue;

				RectTransform iconTransform = icon.Value;
				Vector3 iconWorldPosition = icon.Key.WorldPosition;
				Vector2 iconUIPosition = WordToUiPosition(iconWorldPosition);

				iconTransform.anchoredPosition = iconUIPosition;
			}
		}

		public Vector2 WordToUiPosition(Vector3 worldPosition)
		{
			return WorldToUiPosition(worldPosition.x, worldPosition.z);
		}

		public Vector2 WordToUiPosition(Vector2 worldPosition)
		{
			return WorldToUiPosition(worldPosition.x, worldPosition.y);
		}

		private Vector3 WorldToUiPosition(float worldX, float worldY)
		{
			Bounds1D boundsX = _map.GameplayBounds.boundsX;
			Bounds1D boundsY = _map.GameplayBounds.boundsY;
			var xPercent = (worldX - boundsX.min) / (boundsX.max - boundsX.min);
			var yPercent = (worldY - boundsY.min) / (boundsY.max - boundsY.min);

			var x = _rootTransform.rect.width * xPercent;
			var y = _rootTransform.rect.height * yPercent;

			return new Vector2(x, y);
		}

		public Vector3 UIToWorldPosition(Vector2 UIPosition)
		{
			var x = _map.MapBounds.boundsX.max / _rootTransform.rect.width * UIPosition.x;
			var z = _map.MapBounds.boundsY.max / _rootTransform.rect.height * UIPosition.y;

			return new Vector3(x, 1, z);
		}

		public void MoveCamera(Vector2 position)
		{
			_moveOnClick.MoveCameraOnPosition(position);
		}

		public void DrawWavePathNavigation()
		{
			_navigationPathCalcule.DisablePathLine();
			_navigationPathCalcule.DrawPathNavigation();
			//TODO DJ: draw the nav line each start of wave 
		}

		public void AddIcon(IMiniMapIcon icon, Vector2 size)
		{
			AddIcon(icon, size, Color.white);
		}

		public void AddIcon(IMiniMapIcon icon, Vector2 size, Color tint)
		{
			RectTransform rectTransform = InstantiateIcon(icon, size, tint);

			_icons.Add(icon, rectTransform);
		}

		private RectTransform InstantiateIcon(IMiniMapIcon icon, Vector2 size, Color tint)
		{
			var iconGameObject = GameObject.Instantiate(_prefabIcon, _iconsParent);

			RectTransform rectTransform = iconGameObject.GetComponent<RectTransform>();

			rectTransform.SetParent(_iconsParent, false);
			rectTransform.localScale = Vector3.one;
			rectTransform.sizeDelta = size;

			Image image = iconGameObject.GetComponent<Image>();
			image.sprite = icon.Icon;
			image.color = tint;

			return rectTransform;
		}

		public void RemoveIcon(IMiniMapIcon icon)
		{
			if (_icons.ContainsKey(icon) == true)
			{
				if (_icons[icon] != null)
				{
					Destroy(_icons[icon].gameObject);
				}

				_icons.Remove(icon);
			}
			else
			{
				Debug.LogErrorFormat("Trying to remove {0} icon, but it is not in minimap's icons list.", icon.ToString());
			}
		}
	}
}