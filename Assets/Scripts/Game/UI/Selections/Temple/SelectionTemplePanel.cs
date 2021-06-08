namespace Tartaros.UI
{
	using Sirenix.OdinInspector;
	using Tartaros.Entities;
	using Tartaros.Selection;
	using Tartaros.ServicesLocator;
	using TMPro;
	using UnityEngine;

	public class SelectionTemplePanel : APanel
	{
		#region Fields
		[Title("Data")]
		[SerializeField] private EntityData _templeData = null;

		[Title("UI References")]
		[SerializeField] private SpawnButton[] _spawnButtons = null;
		[SerializeField] private RadialHealthSlider _radialHealthSlider = null;
		[Space]
		[SerializeField] private TextMeshProUGUI _name = null;
		[SerializeField] private TextMeshProUGUI _description = null;

		private EntityUnitsSpawner _shownSpawner = null;
		private ISelection _selection = null;

		public EntityUnitsSpawner ShownSpawner
		{
			get => _shownSpawner;

			private set
			{
				if (_shownSpawner != null)
				{
					_shownSpawner.GetComponent<Entity>().EntityKilled -= SelectionTemplePanel_EntityKilled;
				}

				_shownSpawner = value;

				if (_shownSpawner != null)
				{
					Entity entity = _shownSpawner.GetComponent<Entity>();
					entity.EntityKilled -= SelectionTemplePanel_EntityKilled;
					entity.EntityKilled += SelectionTemplePanel_EntityKilled;
				}
			}
		}
		#endregion Fields

		#region Methods
		protected override void Awake()
		{
			base.Awake();

			_selection = Services.Instance.Get<CurrentSelection>();
		}

		private void Start()
		{
			_name.text = TartarosTexts.TEMPLE_NAME;
			_description.text = TartarosTexts.TEMPLE_DESCRIPTION;
		}

		private void OnEnable()
		{
			_selection.SelectionChanged -= SelectionChanged;
			_selection.SelectionChanged += SelectionChanged;
		}

		private void OnDisable()
		{
			_selection.SelectionChanged -= SelectionChanged;
		}

		private void SelectionTemplePanel_EntityKilled(object sender, Wave.KilledArgs e)
		{
			Hide();
			ShownSpawner = null;
		}

		private void SelectionChanged(object sender, SelectionChangedArgs e)
		{
			if (_selection.ObjectsCount == 1)
			{
				ISelectable selectable = _selection.Objects[0];

				if (TryGetTemple(selectable, out EntityUnitsSpawner selectedSpawner))
				{
					ShownSpawner = selectedSpawner;
					UpdatePanel();
				}
				else
				{
					ShownSpawner = null;
				}
			}
			else
			{
				ShownSpawner = null;
			}
		}

		private bool TryGetTemple(ISelectable selectable, out EntityUnitsSpawner templeUnitsSpawner)
		{
			bool isTemple = (selectable as MonoBehaviour).TryGetComponent(out Entity entity) && entity.EntityData == _templeData;

			if (isTemple == true)
			{
				templeUnitsSpawner = entity.GetComponent<EntityUnitsSpawner>();
				return true;
			}
			else
			{
				templeUnitsSpawner = null;
				return false;
			}
		}

		private void UpdatePanel()
		{
			SetupSpawnButtons();
			_radialHealthSlider.Healthable = ShownSpawner.GetComponent<IHealthable>();
		}

		private void SetupSpawnButtons()
		{
			ISpawnable[] spawnables = ShownSpawner.Spawnables;

			for (int i = 0, length = _spawnButtons.Length; i < length; i++)
			{
				if (i < spawnables.Length)
				{
					_spawnButtons[i].Construct(ShownSpawner, spawnables[i]);
				}
				else
				{
					Debug.LogError("Spawn button has not be initialized.", this);
				}
			}
		}
		#endregion Methods
	}
}
