namespace Tartaros.UI
{
	using Tartaros.Entities;
	using UnityEngine;
	using UnityEngine.UI;

	[RequireComponent(typeof(Button))]
	public class SpawnButton : MonoBehaviour
	{
		#region Fields
		private EntityUnitsSpawner _unitsSpawner = null;
		private ISpawnable _toSpawn = null;

		private Button _button = null;
		#endregion Fields

		#region Properties
		public ISpawnable ToSpawn { get => _toSpawn; set => _toSpawn = value; }
		public EntityUnitsSpawner UnitsSpawner { get => _unitsSpawner; set => _unitsSpawner = value; }
		#endregion Properties

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
				_button.interactable = _unitsSpawner.CanSpawn(_toSpawn);
			}
		}

		public void Construct(EntityUnitsSpawner unitsSpawner, ISpawnable toSpawn)
		{
			_unitsSpawner = unitsSpawner;
			_toSpawn = toSpawn;
		}

		private void OnButtonClick()
		{
			_unitsSpawner.EnqueueEntitySpawn(_toSpawn);
		}
		#endregion Methods
	}
}
