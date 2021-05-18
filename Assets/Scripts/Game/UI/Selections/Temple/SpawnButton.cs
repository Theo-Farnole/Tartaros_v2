namespace Tartaros.UI
{
	using Tartaros.Entities;
	using TMPro;
	using UnityEngine;
	using UnityEngine.UI;

	[RequireComponent(typeof(Button))]
	public class SpawnButton : MonoBehaviour
	{
		#region Fields
		[SerializeField] private RectTransform _rootInQueue = null;
		[SerializeField] private TextMeshProUGUI _inQueue = null;
		[SerializeField] private Slider _slider = null;
		[SerializeField] private Image _portrait = null;

		private EntityUnitsSpawner _unitsSpawner = null;
		private ISpawnable _toSpawn = null;

		private Button _button = null;
		#endregion Fields

		#region Methods
		private void Awake()
		{
			_button = GetComponent<Button>();
		}

		private void OnEnable()
		{
			_button.onClick.RemoveListener(OnButtonClick);
			_button.onClick.AddListener(OnButtonClick);
		}

		private void OnDisable()
		{
			_button.onClick.RemoveListener(OnButtonClick);
		}

		private void Update()
		{
			if (_unitsSpawner != null && _toSpawn != null)
			{
				UpdateCountSpawnableRoot();
				UpdateSlider();
			}
		}

		private void UpdateCountSpawnableRoot()
		{
			int count = _unitsSpawner.GetCountSpawnablesInQueue(_toSpawn);

			_inQueue.text = count.ToString();
			_rootInQueue.gameObject.SetActive(count > 0);
		}

		private void UpdateSlider()
		{
			if (_unitsSpawner.CurrentPrefabSpawning == _toSpawn)
			{
				_slider.value = _unitsSpawner.CurrentProgression;
			}
			else
			{
				_slider.value = 1;
			}
		}

		public void Construct(EntityUnitsSpawner unitsSpawner, ISpawnable toSpawn)
		{
			_unitsSpawner = unitsSpawner;
			_toSpawn = toSpawn;
			_portrait.sprite = toSpawn.Portrait;
		}

		private void OnButtonClick()
		{
			_unitsSpawner.EnqueueEntitySpawn(_toSpawn);
		}
		#endregion Methods
	}
}
